using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItens : MonoBehaviour
{
    //[SerializeField] private int PocaoVida;
    [SerializeField] private int moedas;
    //[SerializeField] private int PocaoVida;
    //[SerializeField] private int PocaoVida;

    [SerializeField] AudioClip[] sons;
    [SerializeField] AudioSource audioS;
    [SerializeField] Text moedasTxt;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag=="PocaoVida")
        //{
        //    PocaoVida++;
        //    Destroy(collision.gameObject);
        //}
        if (collision.gameObject.tag == "Moeda")
        {
            moedas++;
            moedasTxt.text = moedas.ToString();
            audioS.clip = sons[0];
            audioS.Play();
            Destroy(collision.gameObject);
        }
    }

    //public int pocaoVida { get => PocaoVida; set => PocaoVida = value; }
}
