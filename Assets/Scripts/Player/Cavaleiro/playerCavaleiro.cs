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
    private bool jaAtacou, entrouC, clicou;
    private PlayerAnimC animPlayer;
    private EntradaCaverna entradacaverna;
    private PlayerItens playerI;
    private float velocidadeInicial;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Transform _hitBox;
    [SerializeField] Material materialC;
    
    //[SerializeField] AudioClip[] sons;
    //[SerializeField] AudioSource audioS;

    #endregion;

    Bau bau;

    private void Awake()
    {
        //bau = FindObjectOfType<Bau>();
        bau = FindAnyObjectByType<Bau>();
        entradacaverna = FindObjectOfType<EntradaCaverna>();
        playerI = GetComponent<PlayerItens>();
        animPlayer = GetComponent<PlayerAnimC>();
        velocidadeInicial = velocidade;
    }
    void Start()
    {
        
        rig = GetComponent<Rigidbody2D>();
        // healthBar.VidaMaxima(vidaMax);
    }   

    void Update()
    {
        EntrarCaverna();
        MudarMaterial();
        abrirBau();
        usarCura();
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
        //healthBar.MudarVida(vidaAtual);
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

    void usarCura()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (playerI.PocaoVida > 0 && vidaAtual < 30)
            {
                vidaAtual += 5;
            }
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
    //PLAYER ABRINDO O BAÚ
    public void InputAction(InputAction.CallbackContext context)
    {
        if (context.started && bau.Entrou)
        {
            
        }
        else if (context.canceled)
        {

        }
    }

    void MudarMaterial()
    {
        if (entrouC)
        {
            spriteRenderer.material = materialC;
        }
        
    }

    #endregion

    #region Acoes
    //MOVIMENTO DO PLATER
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
    //ATAQUE DO PLAYER
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
        //PLAYER COLIDIU COM O INIMIGO
        if (collision.CompareTag("Inimigo"))
        {
            Inimigo inimigo = collision.GetComponent<Inimigo>();
            inimigo.TomarDano(dano);


            inimigoGoblin inimigoG = collision.GetComponent<inimigoGoblin>();
            inimigoG.TomarDano(dano);
        }
    }
    //ABRIR BAU
    void abrirBau()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            clicou = true;
        }
        else
        {
            clicou = false;
        }
    }
    //PLAYER ENCONSTOU NA CAVERNA
    void EntrarCaverna()
    {
        if (entradacaverna.Entrou && Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("Fase2");
            entrouC = true;
        }
    }

    IEnumerator Ataqueduracao()
    {
        yield return new WaitForSeconds(0.8f);
        jaAtacou = false;
        velocidade = velocidadeInicial;
    }
    #endregion

    public bool Clicou { get => clicou; set => clicou = value; }
}
