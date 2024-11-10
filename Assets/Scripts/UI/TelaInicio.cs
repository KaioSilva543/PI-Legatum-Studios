using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaInicio : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Iniciar(string cena)
    {
        SceneManager.LoadScene(cena);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
