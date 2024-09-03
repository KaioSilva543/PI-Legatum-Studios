using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerM : MonoBehaviour
{
    [SerializeField] float speed;
    public bool atacou;
    public Vector2 input;

    Rigidbody2D rig;

    public Transform fireball;
    public Transform pivot;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
        Flip();
        Ataque();
    }

    public void InputKey(InputAction.CallbackContext value)
    {
        input = value.ReadValue<Vector2>();
    }
    public void Ataque()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            atacou = true;
            Instantiate(fireball, pivot.position, transform.rotation);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            atacou = false;
        }
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
