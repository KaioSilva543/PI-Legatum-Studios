using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InimigoVida : MonoBehaviour
{
    [SerializeField] private Slider slider; 


    public int VidaMax { 
        set { slider.maxValue = value; }
    }

    public int VidaAtual
    {
        set { slider.value = value; }
    }

    public void Esconder()
    {
        gameObject.SetActive(false);
    }
}
