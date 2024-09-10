using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    #region publicVar
    [Header("Stats")]
    public Vector2 input;
    public float velocidade;
    public int vidaAtual, vidaMax;
    public bool ataque;
    #endregion

    #region privateVar
    public BarraVida healthBar;
    private Rigidbody2D rig;
    private bool jaAtacou;
    private PlayerAnim animPlayer;
    private Transform spawnPoint;

    #endregion;

    void Start()
    {
        spawnPoint = GetComponentInChildren<Transform>();
        animPlayer = GetComponent<PlayerAnim>();
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
            Debug.Log("Player morreu");
            animPlayer.Death();
        }
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
            transform.right = Vector2.right * input.x;  //Realiza o flip mudando a rotação
        }
    }

    void Ataque()
    {
        if (ataque && !jaAtacou)
        {
            Debug.Log("O personagem atacou");
            jaAtacou = true;
            animPlayer.Ataque();
            Instantiate(Resources.Load("Prefabs/Fireball"), spawnPoint.position, transform.rotation);
            StartCoroutine(Ataqueduracao());

        }
    }

    IEnumerator Ataqueduracao()
    {
        yield return new WaitForSeconds(1.2f);
        jaAtacou = false;
        
    }
    #endregion

}
