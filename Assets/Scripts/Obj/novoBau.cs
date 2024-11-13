using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class novoBau : MonoBehaviour
{
    [SerializeField] private float distanciaMax;
    [SerializeField] private GameObject[] itensPrefabs; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnItens()
    {
        int indiceItem = Random.Range(0, itensPrefabs.Length);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, distanciaMax);
    }
}
