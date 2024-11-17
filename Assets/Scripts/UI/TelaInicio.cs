using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaInicio : MonoBehaviour
{
    [SerializeField] AudioSource audioS;
    void Start()
    {
        
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
