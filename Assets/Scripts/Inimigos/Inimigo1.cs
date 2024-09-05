using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo1 : MonoBehaviour
{

    [SerializeField] Transform alvo;
    [SerializeField] float velocidade, distanciaMin, raioVisao;
    [SerializeField] Rigidbody2D rig;
    [SerializeField] Animator anim;

    public PlayerM player;
    public int dano;

    Vector2 posAtual, posAlvo, posDir;
    private void Update()
    {
        ProcurarJogador();
        Movimento();
        Flip();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, raioVisao);
    }

    private void ProcurarJogador()
    {
        Collider2D colisor = Physics2D.OverlapCircle(transform.position, raioVisao);
        if (colisor != null)
        {
            alvo = colisor.transform;
        }
    }

    void Movimento()
    {
        posAtual = transform.position;
        posAlvo = alvo.position;
        float distancia = Vector2.Distance(posAtual, posAlvo);

        if (distancia >= distanciaMin)
        {

            posDir = (posAlvo - posAtual).normalized;

            rig.velocity = posDir * velocidade;
            anim.SetInteger("cond", 1);
        }
        else
        {
            rig.velocity = Vector2.zero;
            anim.SetInteger("cond", 0);
        }
    }
    void Flip()
    {
        if (rig.velocity.x != 0)
        {
            transform.right = Vector2.right * rig.velocity.x;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.DanoTomado(dano);
        }
    }
}
