using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaInicio : MonoBehaviour
{
    public int number;
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

    public void Teste()
    {
        number = 1;
    }
}
