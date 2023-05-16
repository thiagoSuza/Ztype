using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEffect : MonoBehaviour
{
    public GameObject space;
    private float timer, timeBase;
    public bool over;

    private void Start()
    {
        timeBase = 3f;
        timer = timeBase;
        over = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (over)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                over = false;
                timer = timeBase;
            }
        }
        
    }


    private void OnMouseEnter()
    {
        if (!over)
        {
            Instantiate(space, new Vector2(-13.8f, 2f), transform.rotation);
            over = true;
        }
       
    }
}
