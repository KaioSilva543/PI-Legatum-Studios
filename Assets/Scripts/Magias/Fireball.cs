using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] int dano;

    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * 500);
        Destroy(gameObject, 3);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Inimigo")
        {
            Inimigo inimigo = collision.gameObject.GetComponent<Inimigo>();
            inimigo.TomarDano(dano);
            Destroy(gameObject);
        }
    }
}
