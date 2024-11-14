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
        Instantiate(ChavePrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
