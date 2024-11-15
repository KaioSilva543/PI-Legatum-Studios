using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    [SerializeField] Transform Ponto;
    [SerializeField] private float RaioPorta;
    [SerializeField] LayerMask JogadorLayer;
    [SerializeField] GameObject canva;
    [SerializeField] GameObject texto1;

    private Animator anim;

    JogadorControl controles;
    PlayerItens pItens;
    private void Awake()
    {
        controles = FindObjectOfType<JogadorControl>();
        pItens = FindObjectOfType<PlayerItens>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        DestruirTxt();
    }
    private void FixedUpdate()
    {
        PortaCheck();
    }

    void PortaCheck()
    {
        Collider2D CheckPorta = Physics2D.OverlapCircle(Ponto.position, RaioPorta, JogadorLayer);
        if (CheckPorta != null)
        {
            if (controles.Interact && pItens.chave1>0)
            {
                anim.SetTrigger("porta");
                pItens.chave1 = 0;
                pItens.chave.SetActive(false);
                GetComponent<BoxCollider2D>().enabled = false;
                print("teste");
            }
        }
        if (pItens.chave1 <= 0 && controles.Interact)
        {
            canva.SetActive(true);
            Invoke("sumirTexto", 2f);
        }
    }
    //DESTRUIR O TEXTO
    void DestruirTxt()
    {
        if (pItens.chave1 > 0)
        {
            Destroy(texto1);
        }
    }
    //SUMIR O TEXTO
    void sumirTexto()
    {
        canva.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Ponto.position, RaioPorta);
    }
}
