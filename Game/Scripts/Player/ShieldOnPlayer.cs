using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldOnPlayer : MonoBehaviour
{
    public int life;


    private void OnEnable()
    {
        life = 5;
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        if(life<=0)
        {
            gameObject.SetActive(false);
        }
    }
}
