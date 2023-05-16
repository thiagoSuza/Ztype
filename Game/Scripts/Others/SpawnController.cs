using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    //public static SpawnController instance;


    public List<GameObject> enys;
    public bool isOkToSpawn;
    public float timeToWin;   
    public float timeToSpawn;
    [SerializeField]
    private float timeToStart;
   



   /* private void Awake()
    {
        
        instance = this;
        
        
    }*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        
        SpawnManager.instance.enemysDestroyds = 0;
        isOkToSpawn = true;
        InvokeRepeating("Spawn", timeToStart, timeToSpawn);
        
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }

   

    public void Spawn()
    {
        if(isOkToSpawn && enys.Count !=0)
        {
            int x = Random.Range(0, enys.Count);
            Instantiate(enys[x], new Vector2(Random.Range(-8f, 8f), 9f), transform.rotation);
            enys.Remove(enys[x]);
        }
    }
}
