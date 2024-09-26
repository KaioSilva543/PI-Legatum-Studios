using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanel : MonoBehaviour
{
    [SerializeField] Image CorBorda;
    [SerializeField] Color corDefault = Color.white;
    [SerializeField] bool selecionado = false;

    void Start()
    {
        if (selecionado)
        {
            CorBorda.color = corDefault;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
