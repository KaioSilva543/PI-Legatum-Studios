using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool attack;
    public Vector2 input;

    Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
        Flip();
        
    }

    public void InputKey(InputAction.CallbackContext value)
    {
        input = value.ReadValue<Vector2>();
    }
    public void InputAttack(InputAction.CallbackContext value) //Input.GetKeyDown("KeyCode.Space")
    {
        
    }

    public void Movimento()
    {
        rig.velocity = input * speed;
    }

    void Flip()
    {
        if (input.x != 0)
        {
            transform.right = Vector2.right * input.x;
        }
    }
}
