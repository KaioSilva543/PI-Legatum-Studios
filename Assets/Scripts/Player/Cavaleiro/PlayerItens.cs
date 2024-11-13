using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItens : MonoBehaviour
{
    [SerializeField] private int pocaoVida;
    [SerializeField] private int moedas;

    [SerializeField] AudioClip[] sons;
    [SerializeField] AudioSource audioS;
    [SerializeField] Text moedasTxt;
    [SerializeField] Text pocaoTxt;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PocaoVida")
        {
            pocaoVida++;
            Destroy(collision.gameObject);
            pocaoTxt.text = pocaoVida.ToString();
        }
        if (collision.gameObject.tag == "Moeda")
        {
            moedas++;
            moedasTxt.text = moedas.ToString();
            audioS.clip = sons[0];
            audioS.Play();
            Destroy(collision.gameObject);
        }
    }

    public int PocaoVida { get => pocaoVida; set => pocaoVida = value; }
}
