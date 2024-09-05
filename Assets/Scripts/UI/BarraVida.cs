using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    Slider slider;

    public void mudarvida(int vida)
    {
        slider = GetComponent<Slider>();
        slider.value = vida;
    }

    public void vidaMaxima(int vida)
    {
        slider = GetComponent<Slider>();
        slider.maxValue = vida;
        slider.value = vida;
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
    }
}
