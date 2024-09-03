using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Animation : MonoBehaviour
{

    PlayerM player;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerM>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
        ataqueAnim();
    }
    void Movimento()
    {
        if (player.input.magnitude > 0.1f || player.input.magnitude < -0.1f)
        {
            anim.SetInteger("cond", 1);
        }
        else
        {
            anim.SetInteger("cond", 0);
        }
    }
    void ataqueAnim()
    {
        if (player.atacou)
        {
            anim.SetBool("ataque", true);
        }
        else
        {
            anim.SetBool("ataque", false);
        }
    }
}
