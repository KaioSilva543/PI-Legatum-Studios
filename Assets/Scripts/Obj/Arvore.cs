using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arvore : MonoBehaviour
{
    private SpriteRenderer sprite;
    public float alpha = 0.5f;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Color corAtual = sprite.color;

            corAtual.a = alpha;
            sprite.color = corAtual;
        }
    }
     private void OnTriggerExit2D(Collider2D collision)
     {
            if (collision.CompareTag("Player"))
            {
                
                Color corAtual = sprite.color;
                corAtual.a = 1f;
                sprite.color = corAtual;
            }   
     }
}
