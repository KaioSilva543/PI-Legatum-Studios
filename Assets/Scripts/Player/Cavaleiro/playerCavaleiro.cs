using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerCavaleiro : MonoBehaviour
{
    #region publicVar
    [Header("Stats")]
    public Vector2 input;
    public float velocidade;
    public int vidaAtual, vidaMax, dano;
    public bool ataque, Abriu;
    public BarraVida healthBar;

    public static PlayerCavaleiro playerCavaleiro;
    public GameObject menu;
    #endregion

    #region privateVar
    private Rigidbody2D rig;
    private bool jaAtacou;
    private PlayerAnimC animPlayer;
    private EntradaCaverna entradacaverna;
    private float velocidadeInicial;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Transform _hitBox;
    #endregion;

    Bau bau;

    private void Awake()
    {
        //bau = FindObjectOfType<Bau>();
        bau = FindAnyObjectByType<Bau>();
        entradacaverna = FindObjectOfType<EntradaCaverna>();
        velocidadeInicial = velocidade;
    }
    void Start()
    {
        animPlayer = GetComponent<PlayerAnimC>();
        
        rig = GetComponent<Rigidbody2D>();
        
        vidaAtual = vidaMax;
        healthBar.VidaMaxima(vidaMax);
    }   

    void Update()
    {
        EntrarCaverna();
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

    public void InputAction(InputAction.CallbackContext context)
    {
        if (context.started && bau.Entrou)
        {
            bau.AnimBau();
            Debug.Log("Teste");
        }
        else if (context.canceled)
        {
            Abriu = false;
        }
    }

    #endregion

    #region Acoes
    void Movimento()
    {
        rig.velocity = input * velocidade;
        animPlayer.Movimento();
        if (input.x > 0)
        {
            // transform.right = Vector2.right * input.x;  //Realiza o flip mudando a rotação
            spriteRenderer.flipX = false;
            _hitBox.transform.localScale = new Vector2(1, _hitBox.transform.localScale.y);  
        }
        else if (input.x < 0)
        {
            spriteRenderer.flipX = true;
            _hitBox.transform.localScale = new Vector2(-1, _hitBox.transform.localScale.y);    //realiza a rotação do player
        }
    }

    void Ataque()
    {
        if (ataque && !jaAtacou)
        {
            Debug.Log("O personagem atacou");
            jaAtacou = true;
            animPlayer.Ataque();
            velocidade = 0;
            StartCoroutine(Ataqueduracao());

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigo"))
        {
            Inimigo inimigo = collision.GetComponent<Inimigo>();
            inimigo.TomarDano(dano);


            inimigoGoblin inimigoG = collision.GetComponent<inimigoGoblin>();
            inimigoG.TomarDano(dano);
        }
    }

    void EntrarCaverna()
    {
        if (entradacaverna.Entrou && Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("Fase2");
        }
    }

    IEnumerator Ataqueduracao()
    {
        yield return new WaitForSeconds(0.8f);
        jaAtacou = false;
        velocidade = velocidadeInicial;
    }
    #endregion

}
