using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogadores : MonoBehaviour
{
    [SerializeField] private GameObject Cavaleiro, Mago, cameraC, cameraM;

    void Start()
    {
        Cavaleiro.SetActive(false);
        Mago.SetActive(false);

        cameraC.SetActive(false);
        cameraM.SetActive(false);
    }

    void Update()
    {
        Selecionar();
    }

    void Selecionar()
    {
        if (TelaSelect.Selecter == 1)
        {
            Cavaleiro.SetActive(true);
            cameraC.SetActive(true);
        }
        else if (TelaSelect.Selecter == 2)
        {
            Mago.SetActive(true);
            cameraM.SetActive(true);
        }
    }
}
