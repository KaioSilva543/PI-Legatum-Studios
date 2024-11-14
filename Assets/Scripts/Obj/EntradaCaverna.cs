using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntradaCaverna : MonoBehaviour
{
    public bool Entrou;
    public bool entrouC;

    [SerializeField] private JogadorMove jogador;
    void Start()
    {
        
    }

    
    void Update()
    {
        //BoxCollider2D teste = Physics2D.OverlapBox(ponto.position, testeRaio, teste1);
        if (Entrou && Input.GetKeyDown(KeyCode.E))
        {
            print("foi");
            SceneManager.LoadScene("Fase2");
            entrouC = true;
        }
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
