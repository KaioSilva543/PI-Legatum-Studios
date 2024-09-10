using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCAnim : MonoBehaviour
{
    Animator anim;
    PlayerC player;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerC>();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        MoveAnim();
    }

    public void AtaqueAnim()
    {
        anim.SetTrigger("Ataque");
    }

    void MoveAnim()
    {
        if (player.direcao.sqrMagnitude > 0)
        {
            anim.SetInteger("Transicao", 1);
        }
        else
        {
            anim.SetInteger("Transicao", 0);
        }
    }
}
