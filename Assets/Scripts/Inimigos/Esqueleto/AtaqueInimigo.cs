using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueInimigo : MonoBehaviour
{
    public int dano;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            collision.GetComponent<Player>().DanoTomado(dano);
        }
        else if (collision.GetComponent<PlayerCavaleiro>() != null)
        {
            collision.GetComponent<PlayerCavaleiro>().DanoTomado(dano);
        }
    }
}
