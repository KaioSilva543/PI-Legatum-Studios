using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteJogador;
    [SerializeField] Material materialJogador;


    void Start()
    {
        spriteJogador.material = materialJogador;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
