using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoriaSceneTen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Sce", .6f);
    }

    public void Sce()
    {
        SceneManager.LoadScene(11);
    }
}
