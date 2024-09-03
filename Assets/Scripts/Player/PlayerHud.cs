using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHud : MonoBehaviour
{
    private Player player;

    [Header("Variaveis")]
    [SerializeField] private float VidaPlayer;
    [SerializeField] private float VigorPlayer;

    void Awake()
    {
        player = GetComponent<Player>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        Vigor();
        Vida();
    }

    void Vigor()
    {
        if (player.Correu && player._Direcao.sqrMagnitude > 0)
        {
            VigorPlayer -= 0.01f;
        }
        else if (!player.Correu && player.Parou && player.teste)
        {
            VigorPlayer += 0.01f;
            if (VigorPlayer == 15)
            {
                VigorPlayer = 15;
            }
        }
    }

    void Vida()
    {
        if(VidaPlayer <= 0)
        {
            print("Morreu");
        }
    }

    public float vigorPlayer { get => VigorPlayer; set => VigorPlayer = value; }
    public float vidaPlayer { get => VidaPlayer; set => VidaPlayer = value; }
}
