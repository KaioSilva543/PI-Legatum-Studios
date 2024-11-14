using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    [SerializeField] Transform Ponto;
    [SerializeField] private float RaioPorta;
    [SerializeField] LayerMask JogadorLayer;

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
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Ponto.position, RaioPorta);
    }
}
