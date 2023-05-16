using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AstkillM : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ast"))
        {
            collision.gameObject.GetComponent<EnemysScriptM>().Deslimite();
           
        }
    }
}
