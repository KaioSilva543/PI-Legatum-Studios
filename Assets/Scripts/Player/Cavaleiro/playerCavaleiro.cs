using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCavaleiro : MonoBehaviour
{
    #region publicVar
    [Header("Stats")]
    public Vector2 input;
    public float velocidade;
    public int vidaAtual, vidaMax, dano;
    public bool ataque;
    public BarraVida healthBar;

    public GameObject menu;
    #endregion

    #region privateVar
    private Rigidbody2D rig;
    private bool jaAtacou;
    private PlayerAnimC animPlayer;

    #endregion;

    void Start()
    {
        animPlayer = GetComponent<PlayerAnimC>();
        rig = GetComponent<Rigidbody2D>();
        
        vidaAtual = vidaMax;
        healthBar.VidaMaxima(vidaMax);
    }   

    void Update()
    {
    }

    private void FixedUpdate()
    {
        Movimento();
        Ataque();
    }

    #region VidaPlayer
    public void DanoTomado(int danoInimigo)
    {
        Debug.Log($"Player tomou {danoInimigo} de dano");
        vidaAtual -= danoInimigo;
        healthBar.MudarVida(vidaAtual);
        animPlayer.Hit();

        if (vidaAtual <= 0)
        {
            Morte();
        }
    }

    private void Morte()
    {
        Debug.Log("Player morreu");
        animPlayer.Death();
        GetComponent<Rigidbody2D>().simulated = false;
        GetComponent<PlayerInput>().enabled = false;
        menu.GetComponentInChildren<MenuControl>().ShowGameOver();
    }
    #endregion

    #region Input
    public void InputMove(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();  //Recebe o valor das teclas pressionadas
        input.Normalize();
    }

    public void InputAttack(InputAction.CallbackContext context)
    {
        if (context.started)   //Similar ao Input.GetKeyDown()
        {
            ataque = true;
        }
        else if (context.canceled)
        {
            ataque= false;
        }
    }

    #endregion

    #region Acoes
    void Movimento()
    {
        rig.velocity = input * velocidade;
        animPlayer.Movimento();
        if (input.x != 0)
        {
            transform.right = Vector2.right * input.x;  //Realiza o flip mudando a rota��o
        }
    }

    void Ataque()
    {
        if (ataque && !jaAtacou)
        {
            Debug.Log("O personagem atacou");
            jaAtacou = true;
            animPlayer.Ataque();
            StartCoroutine(Ataqueduracao());

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigo"))
        {
            Inimigo inimigo = collision.GetComponent<Inimigo>();
            inimigo.TomarDano(dano);
        }
    }

    IEnumerator Ataqueduracao()
    {
        yield return new WaitForSeconds(0.8f);
        jaAtacou = false;
        
    }
    #endregion

}