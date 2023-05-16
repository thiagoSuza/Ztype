using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAst : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ast"))
        {
            Destroy(collision.gameObject);
        }
    }
}
