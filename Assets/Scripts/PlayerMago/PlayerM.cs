using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayerM : MonoBehaviour
{
    PlayerControl playerCon;
    Rigidbody2D rigid;
    private bool jaAtacou; 

    [Header("Atributos")]
    [SerializeField] float velocidade;
    public int vida, vidaMax;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerCon = GetComponent<PlayerControl>();

        vida = vidaMax;
    }

    void Update()
    {
        Movimento();
        Ataque();
    }

    void Movimento()
    {
        rigid.velocity = playerCon.input * velocidade;

        if (playerCon.input.x != 0) //FLIP EIXO X
        {
            transform.right = Vector2.right * playerCon.input.x;
        }
    }

    void Ataque()
    {
        if (playerCon.atacou && !jaAtacou)
        {
            jaAtacou = true;
            Instantiate(playerCon.magia, playerCon.spawnPoint.position, transform.rotation);
            StartCoroutine(ResetAtaque());
        }
    }

    public void DanoTomado(int valorDano)
    {
        Debug.Log($"Tomou {valorDano} de dano");
        vida -= valorDano;

        if (vida <= 0)
        {
            Debug.Log("Morreu");
            velocidade = 0;
        }
    }

    IEnumerator ResetAtaque()
    {
        yield return new WaitForSeconds(1.2f);
        jaAtacou = false;
    }
}
