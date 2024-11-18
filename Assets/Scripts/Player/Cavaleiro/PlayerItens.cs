using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.Video;

public class PlayerItens : MonoBehaviour
{
    [SerializeField] private int pocaoVida;
    [SerializeField] private int moedas;
    [SerializeField] private int Chave;

    [SerializeField] AudioClip[] sons;
    [SerializeField] AudioSource audioS;
    [SerializeField] TextMeshProUGUI moedasTxt;
    [SerializeField] TextMeshProUGUI pocaoTxt;
    public GameObject chave;

    private JogadorControl con;
    private JogadorMove Jogador;
    [SerializeField] BarraVida vida;

    void Start()
    {
        con = GetComponent<JogadorControl>();
        Jogador = GetComponent<JogadorMove>();
    }

    void Update()
    {
        usarCura();
        Atacou();
        danoSom();
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
        if (collision.gameObject.tag == "Chave")
        {
            Chave++;
            chave.SetActive(true);
            Destroy(collision.gameObject);
        }
    }

    void usarCura()
    {
        if (con.Cura && PocaoVida > 0 && Jogador.Vida < 30)
        {
            if (!Jogador.Morte)
            {
                Jogador.Vida += 5;
                pocaoVida -= 1;
                pocaoTxt.text = pocaoVida.ToString();
                Jogador.Vida = Mathf.Min(Jogador.Vida, vida.vidaMax);
                vida.vidaAtual = Jogador.Vida;
            }
        }
    }

    void Atacou()
    {
        if (con.AtaqueInput)
        {
            Invoke("atacouSom", 0.4f);
        }
    }
    void atacouSom()
    {
        audioS.clip = sons[1];
        audioS.Play();
    }

    void danoSom()
    {
        if (Jogador.RecebeuDano)
        {
            audioS.clip = sons[2];
            audioS.Play();
        }
    }

    public int PocaoVida { get => pocaoVida; set => pocaoVida = value; }
    public int chave1 { get => Chave; set => Chave = value; }
}
