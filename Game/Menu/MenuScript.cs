using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject ldg;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        ldg.SetActive(false);
    }

    public void StartG()
    {
        ldg.SetActive(true);
        SceneManager.LoadScene(1);
    }

    public void Multiplayer()
    {
        SceneManager.LoadScene(5);
    }

    public void Store()
    {
        SceneManager.LoadScene(3);
    }

    public void Options()
    {
        SceneManager.LoadScene(4);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
