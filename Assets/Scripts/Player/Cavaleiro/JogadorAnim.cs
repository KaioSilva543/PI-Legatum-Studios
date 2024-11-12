using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorAnim : MonoBehaviour
{
    private JogadorControl control;
    private Animator animator;

    private void Start()
    {
        control = GetComponent<JogadorControl>();
        animator = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        Andando();
    }

    private void Andando()
    {
        if (control.MovimentoInput.x != 0 || control.MovimentoInput.y != 0)
        {
            animator.SetInteger("Cond", 1);
        }
        else
        {
            animator.SetInteger("Cond", 0);
        }
    }

    public void Atacando()
    {
        animator.SetTrigger("Atacou");
    }

    public void ReceberDano(bool morto)
    {
        if (morto)
        {
            animator.SetBool("Morto", true);
        } else
        {
            animator.SetTrigger("RecebeuDano");
        }
        
    }
}
