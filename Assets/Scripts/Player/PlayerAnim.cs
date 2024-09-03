using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;

    private Animator animPlayer;

    private void Awake()
    {
        animPlayer = GetComponent<Animator>();
        player = GetComponent<Player>();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        MoveAnim();
        MoveAtaque();
    }

    void MoveAnim()
    {
        if (player._Direcao.sqrMagnitude > 0)
        {
            animPlayer.SetInteger("Transicao", 1);
        }
        else
        {
            animPlayer.SetInteger("Transicao", 0);
        }
    }
    void MoveAtaque()
    {
        if (player.Atacou)
        {
            animPlayer.SetBool("Ataque", true);

            print("Clicou");
        }
        else
        {
            animPlayer.SetBool("Ataque", false);
        }
    }
}
