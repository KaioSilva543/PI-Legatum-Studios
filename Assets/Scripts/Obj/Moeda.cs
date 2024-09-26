using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    [SerializeField] private int value;
    private bool trigger;
    private MoedaManager coinManager;

    private void Start()
    {
        coinManager = MoedaManager.instance;    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !trigger)
        {
            trigger = true;
            coinManager.ChangeCoins(value);
            Destroy(gameObject);
        }
    }
}
