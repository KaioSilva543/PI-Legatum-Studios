using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    PlayerCAnim playerAnim;

    [SerializeField] private float Velocidade;
    private Rigidbody2D rbPlayer;
    private Vector2 Direcao;


    void Awake()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerCAnim>(); 
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        Ataque();
        OnInput();
    }

    void FixedUpdate()
    {
        MovePlayer();
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
    void OnInput()
    {
        Direcao = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    //ATAQUE DO PLAYER
    void Ataque()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerAnim.AtaqueAnim();
        }
    }


    //PROPIEDADES
    public Vector2 direcao
    {
        get { return Direcao; }
        set { Direcao = value; }
    }
}
