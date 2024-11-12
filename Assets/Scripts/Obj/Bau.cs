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

    private void FixedUpdate()
    {
        BauCheck();
    }
    //ANIMA��O DO BA�
    public void AnimBau()
    {
        anim.SetTrigger("BauAbrindo");
    }
    //CHECANDO SE O PLAYER TA NO RAIO DO BA�
    private void BauCheck()
    {
        Collider2D CheckBau = Physics2D.OverlapCircle(Ponto.position, RaioBau, JogadorLayer);
        if (CheckBau != null)
        {
            Entrou = true;
        }
        else
        {
            Entrou = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Ponto.position, RaioBau);
    }
}
