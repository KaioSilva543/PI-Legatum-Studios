using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelaTutorial : MonoBehaviour
{
    [SerializeField] GameObject ObjTutorial;
    [SerializeField] AudioSource audioSo;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void FecharTutorial()
    {
        audioSo.Play();
        ObjTutorial.SetActive(false);
    }
}
