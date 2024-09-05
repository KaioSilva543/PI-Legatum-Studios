using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public int dano;

    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * 500);
        Destroy(gameObject, 3);
    }

}
    