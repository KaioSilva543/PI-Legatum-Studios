using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private playerCavaleiro player;

    private Animator animPlayer;

    public bool teste;

    private void Awake()
    {
        animPlayer = GetComponentInChildren<Animator>();
        player = GetComponentInParent<playerCavaleiro>();
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
        if (player.input.sqrMagnitude > 0)
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
        if (player.atacou)
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
