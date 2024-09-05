using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimacao : MonoBehaviour
{
    Animator animator;
    PlayerControl playerCon;
    PlayerM playerScript;

    bool jaAtacou;
    void Start()
    {
        playerScript = GetComponent<PlayerM>();
        playerCon = GetComponent<PlayerControl>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Movimentacao();
        Ataque();
    }

    void Movimentacao()
    {
        if (playerCon.input.magnitude != 0)
        {
            animator.SetInteger("Cond", 1);
        }
        else
        {
            animator.SetInteger("Cond", 0);
        }
    }

    void Ataque()
    {
        if (playerCon.atacou)
        {
            animator.SetBool("Ataque", playerCon.atacou);

        }
        else
        {
            animator.SetBool("Ataque", playerCon.atacou);
        }
    }
}


