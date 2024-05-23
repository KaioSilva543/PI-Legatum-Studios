using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rbPlayer;
    private Vector2 Direcao;
    private PlayerHud playerHud;

    [Header("Variaveis")]
    [SerializeField] private float Velocidade, Correr;

    private float VeloInicial;
    public bool Correu;
    void Awake()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        playerHud = GetComponent<PlayerHud>();
    }

    void Start()
    {
        VeloInicial = Velocidade;
    }
    
    void Update()
    {
        OnInput();
        CorrePlayer();
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

    void CorrePlayer()
    {
        if (playerHud.vigorPlayer > 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Velocidade = Correr;
                Correu = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                Velocidade = VeloInicial;
                Correu = false;
            }
        }
        
    }
}
