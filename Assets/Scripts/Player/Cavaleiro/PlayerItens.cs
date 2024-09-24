using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItens : MonoBehaviour
{
    [SerializeField] private int PocaoVida, Moeda;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="PocaoVida")
        {
            PocaoVida++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Moeda")
        {
            Moeda++;
            Destroy(collision.gameObject);
        }
    }

    public int pocaoVida { get => PocaoVida; set => PocaoVida = value; }
}
