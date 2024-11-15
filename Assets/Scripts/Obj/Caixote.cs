using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caixote : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject ChavePrefab;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void caixoteDano()
    {
        print("quebrou");
        anim.SetTrigger("Caixote");
        GetComponent<BoxCollider2D>().enabled = false;
        Instantiate(ChavePrefab, transform.position, transform.rotation);
        Invoke("destruir", 1.1f);
    }

    void destruir()
    {
        Destroy(gameObject);
    }
}
