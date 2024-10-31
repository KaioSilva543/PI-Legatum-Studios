using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public Transform alvo;

    [Header("Stats")]
    public float velocidade;
    public float velocidadeOg;
    public int vidaAtual, vidaMax;

    private Rigidbody2D rig;
    private InimigoAnim anim;
    [SerializeField] private SpriteRenderer Sr;
    [SerializeField] private Transform HitBox;

    [Header("Attack Settings")]
    public float tempoEntreAtaques = 1.5f;
    private bool podeAtacar = true;

    #region AttRange
    [Header("OverlapCircle")]
    public bool inRange;
    public LayerMask maskPlayer;
    public float raio;
    public float raioAtaque;

    [Header("GIZMOS")]
    public Color defaultColor = Color.green;
    public Color rangeColor = Color.red;
    public Color attackRangeColor = Color.yellow;
    #endregion

    void Start()
    {
        anim = GetComponent<InimigoAnim>();
        rig = GetComponent<Rigidbody2D>();
        vidaAtual = vidaMax;
        velocidadeOg = velocidade;
    }

    void FixedUpdate()
    {
        ProcurarJogador();
        anim.Movimento();

        if (alvo != null)
        {
            Movimento();

            
            if (inRange && podeAtacar)
            {
                Collider2D playerNoAtaque = Physics2D.OverlapCircle(transform.position, raioAtaque, maskPlayer);
                if (playerNoAtaque != null)
                {
                    
                    Atacar();
                }
            }
        }
    }

    #region VidaInimigo
    public void TomarDano(int dano)
    {
        anim.Hit();
        Debug.Log($"Inimigo tomou {dano} de dano");
        vidaAtual -= dano;
        Stun();
        if (vidaAtual <= 0)
        {
            Morte();
        }
    }

    public void Morte()
    {
        anim.Morte();
        enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        Debug.Log("Morreu");
    }

    private void Stun()
    {
        velocidade = 0;
        StartCoroutine(StunReset());
    }

    IEnumerator StunReset()
    {
        yield return new WaitForSeconds(0.4f);
        velocidade = velocidadeOg;
    }
    #endregion

    #region PerseguirJogador
    private void OnDrawGizmos()
    {
        Gizmos.color = defaultColor;
        Gizmos.DrawWireSphere(transform.position, raio);
        if (inRange)
        {
            Gizmos.color = rangeColor;
            Gizmos.DrawWireSphere(transform.position, raio);
        }

        // Gizmo raio ataque
        Gizmos.color = attackRangeColor;
        Gizmos.DrawWireSphere(transform.position, raioAtaque);
    }

    private void ProcurarJogador()
    {
        Collider2D colisor = Physics2D.OverlapCircle(transform.position, raio, maskPlayer);
        if (colisor != null)
        {
            inRange = true;
            alvo = colisor.transform;
        }
        else
        {
            inRange = false;
            alvo = null;
        }
    }
    #endregion

    public void Movimento()
    {
        Vector2 posAtual = transform.position;
        Vector2 alvoPos = alvo.transform.position;
        Vector2 direcao = Vector2.MoveTowards(posAtual, alvoPos, velocidade * Time.deltaTime);
        rig.MovePosition(direcao);

        if (direcao.x > 0)
        {
            //transform.right = Vector2.right * (alvoPos - posAtual);
            Sr.flipX = false;
            HitBox.transform.localScale = new Vector2(0.2f, HitBox.transform.localScale.y);
        }
        else if (direcao.x < 0)
        {
            Sr.flipX = true;
            HitBox.transform.localScale = new Vector2(-0.2f, HitBox.transform.localScale.y);
        }
    }

    // Função de ataque
    private void Atacar()
    {
        velocidade = 0;
        anim.Ataque();
        Debug.Log("Inimigo atacou!");
        StartCoroutine(ResetaAtaque());
    }

    // Coroutine para controlar o tempo entre os ataques
    IEnumerator ResetaAtaque()
    {
        podeAtacar = false;
        yield return new WaitForSeconds(tempoEntreAtaques);
        podeAtacar = true;
        velocidade = velocidadeOg;
    }
}
