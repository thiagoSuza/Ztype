using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstSpawn : MonoBehaviour
{

    public GameObject[] ast;
    public int timeToDeplyNewAst;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 3f, timeToDeplyNewAst);
    }

    public void Spawn()
    {
       
        int x = Random.Range(0, ast.Length);
        Instantiate(ast[x], new Vector2(Random.Range(-9.2f, 9.2f), 9f), transform.rotation );
    }
}
