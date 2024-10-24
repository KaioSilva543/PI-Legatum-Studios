using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAnim : MonoBehaviour
{
    Animator animator;
    inimigoGoblin inimigoG;
    void Start()
    {
        inimigoG = GetComponent<inimigoGoblin>();
        animator = GetComponentInChildren<Animator>();
    }


    public void Movimento()
    {
        if (inimigoG.alvo != null)
        {
            animator.SetInteger("Cond", 1);
        }
        else if (inimigoG.alvo == null)
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
