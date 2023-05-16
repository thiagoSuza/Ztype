using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private GameObject[] ast;


    public void Start()
    {
        InvokeRepeating("AST", 3f, 2f);
    }

    public void AST()
    {
       int x = Random.Range(0, ast.Length);
        Instantiate(ast[x], new Vector2(Random.Range(-8f, 8f), 9f), transform.rotation);
    }

    public void Action()
    {
        panel.SetActive(true);
        GameController.instance.NextList();
    }
}
