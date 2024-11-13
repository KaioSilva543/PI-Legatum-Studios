using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Potion : MonoBehaviour
{
    [SerializeField] private int potions;


    [SerializeField] TextMeshProUGUI textoP;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            potions++;
            textoP.text = potions.ToString();
            Destroy(gameObject);
        }
    }


}
