using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TelaInicio : MonoBehaviour
{
    [SerializeField] AudioSource audioS;
    [SerializeField] Button botao;
    void Start()
    {
        botao.Select();
    }

    
    void Update()
    {
        
    }

    public void Iniciar(string cena)
    {
        SceneManager.LoadScene(cena);
        audioS.Play();
    }

    public void Sair()
    {
        Application.Quit();
        audioS.Play();
    }
}
