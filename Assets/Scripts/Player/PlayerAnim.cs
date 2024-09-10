using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    Player playerScript;
    Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        playerScript = GetComponent<Player>();
    }

    public void Movimento()
    {
        if (playerScript.input.magnitude > 0 || playerScript.input.magnitude < 0)
        {
            anim.SetInteger("Cond", 1);
        }
        else
        {
            anim.SetInteger("Cond", 0);
        }
    }

    public void Ataque()
    {
        anim.SetTrigger("Atacou");
    }

    public void Hit()
    {
        anim.SetInteger("Cond", 2);
    }

    public void Death()
    {
        anim.SetBool("Morto", true);
    }
}
