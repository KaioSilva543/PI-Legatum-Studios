using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Bau : MonoBehaviour
{
    Animator anim;

    public static Bau bau;

    public bool Entrou;

    PlayerCavaleiro playerCavaleiro;

    [SerializeField] Transform Ponto;
    [SerializeField] public float RaioBau;
    [SerializeField] LayerMask JogadorLayer;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        playerCavaleiro = FindObjectOfType<PlayerCavaleiro>();
    }

    void Start()
    {
        
    }
  
    
    void Update()
    {
        AnimBau();
    }

    private void FixedUpdate()
    {
        BauCheck();
    }

    public void AnimBau()
    {
        if (playerCavaleiro.Abriu)
        {
            anim.SetTrigger("BauAbrindo");
        }
    }

    private void BauCheck()
    {
        Collider2D CheckBau = Physics2D.OverlapCircle(Ponto.position, RaioBau, JogadorLayer);
        if (CheckBau != null)
        {
            Entrou = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Ponto.position, RaioBau);
    }
}