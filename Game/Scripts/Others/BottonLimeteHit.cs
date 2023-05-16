using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottonLimeteHit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerMove.instance.TakeDamege(collision.gameObject.GetComponent<EnemysScript>().data.damage);
            collision.gameObject.GetComponent<EnemysScript>().Deslimite();
            if (collision.gameObject == PlayerAtk.instance.eny)
            {
                PlayerAtk.instance.EneDead();
            }

        }
        else if (collision.gameObject.CompareTag("Ast"))
        {
            Destroy(collision.gameObject);
        }
    }
}
