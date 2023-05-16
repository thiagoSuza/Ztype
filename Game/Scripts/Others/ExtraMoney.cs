using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraMoney : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            HudController.instance.EarnMoney();
            Destroy(gameObject);
        }


    }
}
