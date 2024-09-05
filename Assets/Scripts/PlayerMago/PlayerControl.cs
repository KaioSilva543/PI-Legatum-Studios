using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [Header("INFO:")]
    public Vector2 input;
    public bool atacou;
    public Transform magia;
    public Transform spawnPoint;

    public void InputKey(InputAction.CallbackContext value) // Vector2 (0,0) dos inputs
    {
        input = value.ReadValue<Vector2>();
        input = input.normalized;
    }

    public void InputAtaque(InputAction.CallbackContext value) //Input.GetKeyDown(KeyCode.Space);
    {
        if (value.started)
        {
            atacou = true;
        }
        else if (value.canceled) //Input.GetKeyUp(KeyCode.Space);
        {
            atacou = false;
        }
    }
}