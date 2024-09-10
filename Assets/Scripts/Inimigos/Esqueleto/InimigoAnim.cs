using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoAnim : MonoBehaviour
{
    Animator animator;
    Inimigo inimigo;
    void Start()
    {
        inimigo = GetComponent<Inimigo>();
        animator = GetComponentInChildren<Animator>();
    }
    

    public void Movimento()
    {
        if (inimigo.alvo != null)
        {
            animator.SetInteger("Cond", 1);
        }
        else if (inimigo.alvo == null)
        {
            animator.SetInteger("Cond", 0);
        }
    }

    public void Ataque()
    {
        animator.SetTrigger("Atacou");
    }

    public void Hit()
    {
        animator.SetTrigger("Dano");
    }

    public void Morte()
    {
        animator.SetBool("Morto", true);
    }
}
