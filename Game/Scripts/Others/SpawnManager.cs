using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    public List<GameObject> bossList;


    public int enemysAccount;
    public int enemysDestroyds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        enemysAccount = 8;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add()
    {
        enemysDestroyds++;
        ActiveBoss();
    }

    public void ActiveBoss()
    {
        if(enemysAccount == enemysDestroyds)
        {
            bossList[0].SetActive(true);
        }
    }
}
