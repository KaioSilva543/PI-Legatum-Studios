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
    }

    void Vigor()
    {
        if (player.Correu)
        {
            VigorPlayer -= 0.01f;
        }
    }

    public float vigorPlayer { get => VigorPlayer; set => VigorPlayer = value; }
}
