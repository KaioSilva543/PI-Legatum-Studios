using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoGoblin : MonoBehaviour
{
    [SerializeField] private Transform jogador;
    [SerializeField] GameObject moedaPrefab;
    [SerializeField] GameObject moedaPPrefab;
    [SerializeField] GameObject PocaoPrefab;
    [SerializeField] AudioClip[] sons;
    [SerializeField] AudioSource audioS;
    [SerializeField] private int totalMoedas;
    [SerializeField] private float velocidade;
    [SerializeField] private float distanciaMin;
    [SerializeField] int vida;

    [SerializeField] private float distanciaMaxAtaque;
    [SerializeField] private int danoAtaque;
    [SerializeField] private float intervaloAtaques;
    private float tempoEsperaAaques;

    [SerializeField] private float raioAtaque;
    [SerializeField] private LayerMask layerJogador;

    private Animator animator;
    [SerializeField] private InimigoVida inimigoVida;
    private Rigidbody2D rb;

    private void Start()
    {
        inimigoVida = GetComponentInChildren<InimigoVida>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        inimigoVida.VidaMax = vida;
        inimigoVida.VidaAtual = vida;

        tempoEsperaAaques = intervaloAtaques;
    }

    private void Update()
    {
        Procurar();
        if (jogador != null)
        {
            Perseguir();
            VerificarAreaAtaque();
        }
        else
        {
            rb.velocity = Vector2.zero;
            animator.SetInteger("Cond", 0);
        }
    }

    public void ReceberDano(int dano)
    {
        vida -= dano;
        animator.SetTrigger("Dano");
        inimigoVida.VidaAtual = vida;
        if (vida <= 0)
        {
            print("Morreu");
            //audioS.clip = sons[0];
            //audioS.Play();
            inimigoVida.Esconder();
            rb.velocity = Vector2.zero;
            enabled = false;
            animator.SetBool("Morto", true);
            Instantiate(PocaoPrefab, transform.position + new Vector3(Random.Range(-1.5f, 1.2f), Random.Range(-1.5f, 1.2f), 0f), transform.rotation);
            for (int i = 0; i < totalMoedas; i++)
            {
                Instantiate(moedaPrefab, transform.position + new Vector3(Random.Range(-1.5f, 1.2f), Random.Range(-1.5f, 1.2f), 0f), transform.rotation);
                Instantiate(moedaPPrefab, transform.position + new Vector3(Random.Range(-1.5f, 1.2f), Random.Range(-1.5f, 1.2f), 0f), transform.rotation);
            }

            foreach (var collider in GetComponents<Collider2D>())
            {
                collider.enabled = false;
            }

        }

    }

    private void VerificarAreaAtaque()
    {
        JogadorMove Jogador = jogador.GetComponent<JogadorMove>();

        if (Jogador.Morte)
        {
            return;
        }
        float distancia = Vector3.Distance(transform.position, jogador.transform.position);
        if (distancia <= distanciaMaxAtaque)
        {
            tempoEsperaAaques -= Time.deltaTime;
            if (tempoEsperaAaques <= 0)
            {
                tempoEsperaAaques = intervaloAtaques;
                Atacar();
            }
        }
    }

    private void Atacar()
    {
        animator.SetTrigger("Atacou");
        Invoke("SomAtaque", 0.5f);
    }
    void SomAtaque()
    {
        audioS.clip = sons[0];
        audioS.Play();
    }
    public void AplicarDano()
    {
        JogadorMove Jogador = jogador.GetComponent<JogadorMove>();
        Jogador.ReceberDano(danoAtaque);
    }

    private void Perseguir()
    {
        Vector2 Jogador = jogador.position;
        Vector2 Inim = transform.position;
        float Distancia = Vector2.Distance(Jogador, Inim);

        if (Distancia >= distanciaMin)
        {
            Vector2 Direcao = (Jogador - Inim).normalized;

            rb.velocity = velocidade * Direcao;
            if (Direcao.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (Direcao.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            animator.SetInteger("Cond", 1);
        }
        else
        {
            rb.velocity = Vector2.zero;
            animator.SetInteger("Cond", 0);
        }
    }
    private void Procurar()
    {
        Collider2D ColisorJogador = Physics2D.OverlapCircle(transform.position, raioAtaque, layerJogador);
        if (ColisorJogador != null)
        {
            Vector2 PosAtual = this.transform.position;
            Vector2 Jogador = ColisorJogador.transform.position;
            Vector2 Distancia = (Jogador - PosAtual).normalized;

            RaycastHit2D hit = Physics2D.Raycast(PosAtual, Distancia);
            if (hit.transform != null)
            {
                if (hit.transform.CompareTag("Player"))
                {
                    jogador = hit.transform;
                }
                else
                {
                    jogador = null;
                }
            }
            else
            {
                jogador = null;
            }
        }
        else
        {
            jogador = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, raioAtaque);
        if (jogador != null)
        {
            Gizmos.DrawLine(transform.position, jogador.position);
        }
    }
}
