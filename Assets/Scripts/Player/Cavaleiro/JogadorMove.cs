using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

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
    private Vector3 posicaoInicalAtaque;

    [SerializeField] private BarraVida vidaPlayer;
    [SerializeField] private SpriteRenderer sprite;
    private JogadorAnim animacoes;
    private JogadorControl controles;
    private Rigidbody2D rigidb;
    private PlayerItens playerI;

    private bool clicou;
    

    #region Inicialização
    private void Start()
    {
        atacando = false;
        velocidadeInicial = velocidade;

        vidaPlayer.vidaMax = vida;
        vidaPlayer.vidaAtual = vida;

        posicaoInicalAtaque = ataqueArea.localPosition;
    }
    private void Awake()
    {
        playerI = GetComponent<PlayerItens>();
        sprite = GetComponent<SpriteRenderer>();
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

        abrirBau();
        usarCura();

    }
    #endregion

    #region Vida
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
    #endregion

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
                sprite.flipX = false;
                ataqueArea.localPosition = posicaoInicalAtaque;
            }
            else if (controles.MovimentoInput.x < 0)
            {
                sprite.flipX = true;
                ataqueArea.localPosition = new Vector3(-posicaoInicalAtaque.x, posicaoInicalAtaque.y, posicaoInicalAtaque.z);
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


    void abrirBau()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            clicou = true;
        }
        else
        {
            clicou = false;
        }
    }
    public bool Clicou { get => clicou; set => clicou = value; }

    void usarCura()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (playerI.PocaoVida > 0 && vida < 30)
            {
                vida += 5;
                vida = Mathf.Min(vida, vidaPlayer.vidaMax);
                vidaPlayer.vidaAtual = vida;
            }
        }
    }
}

