using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLeng : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Tamanho(PlayerAtk.instance.distance/6);
       
    }

    public void Tamanho(float x)
    {
        this.transform.localScale = new Vector3(0.4f,x,0f);
    }
}
