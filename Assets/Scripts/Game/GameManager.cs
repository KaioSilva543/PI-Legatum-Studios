using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] Items;
    [SerializeField] SpriteRenderer spriteJogador;
    [SerializeField] Material materialJogador;


    void Start()
    {
        Items[0].material = materialJogador;
        spriteJogador.material = materialJogador;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
