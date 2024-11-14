using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JogadorControl : MonoBehaviour, PlayerController.IPlayerActions
{
    private PlayerController playerControls;
    public Vector2 MovimentoInput { get; private set; }
    public bool AtaqueInput;
    public bool Interact;
    public bool Cura { get; private set; }

    private void OnEnable()
    {
        playerControls = new PlayerController();
        playerControls.Enable();

        playerControls.Player.SetCallbacks(this);
    }

    private void OnDisable()
    {
        playerControls.Player.RemoveCallbacks(this);
        playerControls.Disable();
    }

    public void OnMovimento(InputAction.CallbackContext context)
    {
        MovimentoInput = context.ReadValue<Vector2>();
    }

    public void OnAtaque(InputAction.CallbackContext context)
    {
        if (context.started) 
        {
            AtaqueInput = true;
        } 
        if (context.canceled)
        {
            AtaqueInput = false;
        }
    }

    public void OnInteragir(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Interact = true;
        }
        if (context.canceled)
        {
            Interact = false;
        }
    }

    public void OnCura(InputAction.CallbackContext context)
    {
      if (context.started)
        {
            Cura = true;
        }
      if (context.canceled)
        {
            Cura = false;
        }
    }
}
