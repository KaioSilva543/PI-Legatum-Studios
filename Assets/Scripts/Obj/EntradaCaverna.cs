using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntradaCaverna : MonoBehaviour
{
    public bool Entrou;
    void Start()
    {
        
    }

    
    void Update()
    {
        //BoxCollider2D teste = Physics2D.OverlapBox(ponto.position, testeRaio, teste1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Entrou = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Entrou = false;
        }
    }
}
