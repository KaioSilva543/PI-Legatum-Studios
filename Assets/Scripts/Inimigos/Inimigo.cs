using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int vida, vidaMax;
    public float velocidade, velocidadeOg;
    public bool andando;

    private Transform alvo;
    public InimigoAnim animacao;
    public BarraVida barraVida;

    Rigidbody2D rig;
    public Vector2 posicaoAtual, posicaoAlvo, direcao;

    [Header("OverlapCircle")]
    public float tamanhoDiametro;
    public bool detectouPlayer;
    public LayerMask layerArea;

    [Header("Gizmo")]
    public Color gizmoIdleColor = Color.green;
    public Color gizmoDetect = Color.red;
    public void Start()
    {

        rig = GetComponent<Rigidbody2D>();
        vida = vidaMax;
        barraVida.vidaMaxima(vidaMax);
        velocidadeOg = velocidade;
    }

    public void FixedUpdate()
    {
        ProcurarJogador();
        if (alvo != null)
        {
            Movimento();
        }
        else
        {
            PararMovimento();
        }
    }

    #region VidaInimigo
    public void TomarDano(int dano)
    {
        animacao.Hit();
        Stun();
        vida -= dano;
        barraVida.mudarvida(vida);
        Console.WriteLine($"Inimigo tomou {dano} de dano");

        if (vida <= 0)
        {
            Morte();
        }
    }

    public void Morte()
    {
        Debug.Log("Inimigo morreu");
        animacao.Morte();
        enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)   //tomar dano
    {;
        if (collision.CompareTag("Spell"))
        {
            Debug.Log("O inimigo foi atingido por um projétil!");
            Fireball magia = collision.GetComponent<Fireball>();
            if (magia != null)
            {
                TomarDano(2);
                Destroy(collision.gameObject);
            }
        }
    }
    #endregion

    #region InimigoPerseguir
    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoIdleColor;
        Gizmos.DrawWireSphere(posicaoAtual, tamanhoDiametro);
        if (detectouPlayer)
        {
            Gizmos.color = gizmoDetect;
            Gizmos.DrawWireSphere(posicaoAtual, tamanhoDiametro);
        }
    }
    void ProcurarJogador()
    {
        Collider2D colisor = Physics2D.OverlapCircle(posicaoAtual, tamanhoDiametro, layerArea); 
        if (colisor != null)
        {
            detectouPlayer = true;
            alvo = colisor.transform;
        }
        else if (colisor == null)
        {
            detectouPlayer = false;
            alvo = null;
        }
    }
    #endregion

    #region Movimentacao
    void Movimento()
    {
        andando = true;
        posicaoAlvo = alvo.transform.position;
        posicaoAtual = transform.position;
        direcao = (posicaoAlvo - posicaoAtual).normalized;
        Debug.Log(direcao);
        rig.MovePosition(Vector2.MoveTowards(posicaoAtual, posicaoAlvo, velocidade * Time.deltaTime));

        Flip();
    }

    void Flip()
    {
        if (direcao.x != 0)
        {
            transform.right = Vector2.right * direcao.x;
        }
    }

    void PararMovimento()
    {
        andando = false;
        rig.velocity = Vector2.zero;
    }

    void Stun()
    {
        velocidade = 0;
        StartCoroutine(TempoStun());
    }

    IEnumerator TempoStun()
    {
        yield return new WaitForSeconds(0.4f);
        velocidade = velocidadeOg;
    }
    #endregion
}
