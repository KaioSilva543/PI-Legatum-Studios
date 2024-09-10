using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    Slider slider;
    public void MudarVida(int vida)
    {
        slider = GetComponent<Slider>();
        slider.value = vida;
    }

    public void VidaMaxima(int vida)
    {
        slider = GetComponent<Slider>();
        slider.maxValue = vida;
        slider.value = vida;
    }
}
