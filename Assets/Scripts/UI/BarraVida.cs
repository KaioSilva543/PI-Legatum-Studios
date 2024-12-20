using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    [SerializeField] Slider slider;

    public int vidaMax
    {
        get { return (int)slider.maxValue; }
        set { slider.maxValue = value; }
    }

    public int vidaAtual
    {
        set { slider.value = value; }
    }
}
