    using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Bau : MonoBehaviour
{
    Animator anim;

    public static Bau bau;

    public bool Entrou;

    JogadorMove playerCavaleiro;

    [SerializeField] Transform Ponto;
    [SerializeField] private float RaioBau;
    [SerializeField] private int totalMoedas;
    [SerializeField] LayerMask JogadorLayer;
    [SerializeField] GameObject moedaPrefab;
    [SerializeField] GameObject moedaPPrefab;
    [SerializeField] GameObject esmeraldaPrefab;
    [SerializeField] GameObject PocaoPrefab;

    JogadorControl controles;

    private void Awake()
    {

        anim = GetComponent<Animator>();

        playerCavaleiro = FindObjectOfType<JogadorMove>();
    }

    private void FixedUpdate()
    {
        BauCheck();
        //AbrirBau();
    }
    private void Update()
    {
        bauTeste();
    }
    //CHECANDO SE O PLAYER TA NO RAIO DO BAÚ
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
    
    /*private void AbrirBau()
    {
        if (controles.Interact && Entrou)
        {
            anim.SetTrigger("BauAbrindo");
        }
    }*/

    void bauTeste()
    {
        if (playerCavaleiro.Clicou)
        {
            anim.SetTrigger("BauAbrindo");
            GetComponent<BoxCollider2D>().enabled = false;
            Instantiate(PocaoPrefab, transform.position + new Vector3(Random.Range(-1.5f, 1.2f), Random.Range(-1.5f, 1.2f), 0f), transform.rotation);
            for (int i =0; i < totalMoedas; i++)
            {
                Instantiate(moedaPrefab, transform.position + new Vector3(Random.Range(-1.5f, 1.2f), Random.Range(-1.5f, 1.2f), 0f), transform.rotation);
                Instantiate(moedaPPrefab, transform.position + new Vector3(Random.Range(-1.5f, 1.2f), Random.Range(-1.5f, 1.2f), 0f), transform.rotation);
                Instantiate(esmeraldaPrefab, transform.position + new Vector3(Random.Range(-1.5f, 1.2f), Random.Range(-1.5f, 1.2f), 0f), transform.rotation);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Ponto.position, RaioBau);
    }
}
