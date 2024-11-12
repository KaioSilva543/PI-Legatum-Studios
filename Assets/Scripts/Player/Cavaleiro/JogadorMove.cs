using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorMove : MonoBehaviour
{
    [SerializeField] private int vida;

    [SerializeField] private float velocidade;
    [SerializeField] private float velocidadeInicial;
    [SerializeField] private int dano;
    [SerializeField] private bool atacando;

    [Header("Componentes Ataque")]
    [SerializeField] private Transform ataqueArea;
    [SerializeField] private float raioAtaque;
    [SerializeField] private LayerMask layerAtaque;

    private JogadorAnim animacoes;
    private JogadorControl controles;
    [SerializeField] private BarraVida vidaPlayer;
    private Rigidbody2D rigidb;

    #region Inicialização
    private void Start()
    {
        atacando = false;
        velocidadeInicial = velocidade;

        vidaPlayer.vidaMax = vida;
        vidaPlayer.vidaAtual = vida;
    }
    private void Awake()
    {
        rigidb = GetComponent<Rigidbody2D>();
        controles = GetComponent<JogadorControl>();
        animacoes = GetComponent<JogadorAnim>();
    }
    #endregion

    #region Logica Update
    void Update()
    {
        if (Morte){
            rigidb.velocity = Vector2.zero;
            return;
        }
        Movimento();
        Atacar();

    }
    #endregion

    public void ReceberDano(int dano)
    {
        vida -= dano;
        vidaPlayer.vidaAtual = vida;
        Debug.Log("Persoangem tomou dano");
        animacoes.ReceberDano(Morte);
    }

    public bool Morte
    {
        get {
            return (vida <= 0);
        }
    }

    #region LogicaMovimento
    private void Movimento()
    {
        if (atacando)
        {
            rigidb.velocity = Vector2.zero;
        } else {
            rigidb.velocity = controles.MovimentoInput * velocidade;
            if (controles.MovimentoInput.x > 0)
            {
                transform.right = Vector2.right * controles.MovimentoInput.x;
            }
            else if (controles.MovimentoInput.x < 0)
            {
                transform.right = Vector2.right * controles.MovimentoInput.x;
            }
        }
    }
    #endregion

    #region Logica Ataque
    private void Atacar()
    {
        if (controles.AtaqueInput && !atacando)
        {
            atacando = true;
            velocidade = 0;
            animacoes.Atacando();
            controles.AtaqueInput = false;
            
            StartCoroutine(ResetarAtaque());
        }
    }
    private void AplicarDano()
    {
        Collider2D colliderInimigo = Physics2D.OverlapCircle(ataqueArea.position, raioAtaque, layerAtaque);
        if (colliderInimigo != null)
        {

            Debug.Log("Atacando objeto:  " + colliderInimigo.name);
            //Dano ao inimigo
            InimEsqueleto inimigo = colliderInimigo.GetComponent<InimEsqueleto>();
            if (inimigo != null)
            {
                inimigo.ReceberDano(dano);
            }
        }
    }

    IEnumerator ResetarAtaque()
    {
        yield return new WaitForSeconds(0.8f);
        atacando = false;
        velocidade = velocidadeInicial;
    }
    #endregion

    #region Visuals
    private void OnDrawGizmos()
        {
            if (ataqueArea != null) {
                Gizmos.DrawWireSphere(ataqueArea.position, raioAtaque);
            }
        }
        #endregion
}

