using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rbPlayer;
    public Vector2 Direcao;
    private PlayerHud playerHud;

    [Header("Variaveis")]
    [SerializeField] private float Velocidade, Correr;

    private float VeloInicial;
    public bool Correu, Atacou, Parou, teste;
    void Awake()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        playerHud = GetComponent<PlayerHud>();
    }

    void Start()
    {
        teste = false;
        VeloInicial = Velocidade;
    }
    
    void Update()
    {
        OnInput();
        CorrePlayer();
        Ataque();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void OnInput()
    {
        Direcao = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    //MOVIMENTO DO PLAYER
    void MovePlayer()
    {
        rbPlayer.MovePosition(rbPlayer.position + Direcao * Velocidade * Time.fixedDeltaTime);

        if (Direcao.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else if (Direcao.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
    //PLAYER CORRENDO
    void CorrePlayer()
    {
        if(playerHud.vigorPlayer > 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Velocidade = Correr;
                Correu = true;
                Parou = false;
                teste = true;
            }
        }else if (playerHud.vigorPlayer <= 0)
        {
            Velocidade = VeloInicial;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Velocidade = VeloInicial;
            Correu = false;
            Parou = true;
        }
    }
    //ATAQUE DO PLAYER
    void Ataque()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Atacou = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Atacou = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //PLAYER PERDENDO VIDA
        if (collision.CompareTag("Inimigo"))
        {
            playerHud.vidaPlayer -= 2;
            print("perdeu vida");
        }
    }
    //
    public Vector2 _Direcao
    {
        get { return Direcao; }
        set { Direcao = value; }
    }
}
