using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreX2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HudController.instance.ScoreX2();
            Destroy(gameObject);
        }
    }
}
