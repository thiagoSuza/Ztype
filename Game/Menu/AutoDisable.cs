using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisable : MonoBehaviour
{
  

    private void OnEnable()
    {
        Invoke("Dis", .8f);
    }

    public void Dis()
    {
        gameObject.SetActive(false);
    }
}
