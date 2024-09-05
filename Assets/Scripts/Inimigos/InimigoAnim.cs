using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoAnim : MonoBehaviour
{
    Inimigo inimigoScript;
    Animator animator;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        inimigoScript = GetComponent<Inimigo>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimentacao();
    }

    void Movimentacao()
    {
        if(inimigoScript.andando)
        {
            animator.SetInteger("cond", 1);
        }
        else
        {
            animator.SetInteger("cond", 0);
        }
    }

    public void Hit()
    {
        animator.SetTrigger("Hit");
    }

    public void Morte()
    {
        {
            animator.SetBool("Morto", true);
        }
    }

    public void Ataque()
    {
        animator.SetTrigger("Ataque");
    }
}
