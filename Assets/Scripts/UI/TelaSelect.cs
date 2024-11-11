using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaSelect : MonoBehaviour
{
    public static int Selecter;

    public void IniciarCavaleiro(string cena)
    {
        SceneManager.LoadScene(cena);
        Selecter = 1;
    }

    public void IniciarMago(string cena)
    {
        SceneManager.LoadScene(cena);
        Selecter = 2;
    }
}
