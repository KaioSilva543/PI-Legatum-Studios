using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelaTutorial : MonoBehaviour
{
    [SerializeField] GameObject ObjTutorial;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void FecharTutorial()
    {
        ObjTutorial.SetActive(false);
    }
}
