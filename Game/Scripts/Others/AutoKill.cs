using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoKill : MonoBehaviour
{
    public float timeToKill;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,timeToKill);
    }

    
}
