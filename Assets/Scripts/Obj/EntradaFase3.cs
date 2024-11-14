using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.EventSystems.EventTrigger;

public class EntradaFase3 : MonoBehaviour
{
    private bool Entrou;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Entrou)
        {
            SceneManager.LoadScene("Fase3");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Entrou = true;
        }
    }
}
