using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerCavaleiro : MonoBehaviour
{
    public Vector2 input;
    public bool atacou;
    private Rigidbody2D rig;

    public Inimigo inimigoScript;
    
    
    [SerializeField] private float velocidade;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
    }

    #region Movimentacao

    public void Movimento()
    {
        rig.velocity = input * velocidade;

        if (input.x != 0)
        {
            transform.right = Vector2.right * input.x;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Inimigo")
        {
            inimigoScript.TomarDano(2);
        }
    }
    #endregion
    #region Input
    public void  InputKey(InputAction.CallbackContext value)
    {
        input = value.ReadValue<Vector2>();
    }

    public void InputAttack(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            atacou = true;
        }
        else if (value.canceled)
        {
            atacou = false;
        }
    }
    #endregion
}
