using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BossMultiplayer : MonoBehaviour
{             
    HudControllerMultiplayer controller;
    public List<GameObject> enmys;
    private float timer, timerAll;

    // Start is called before the first frame update
    void Start()
    {
        
       controller = FindFirstObjectByType<HudControllerMultiplayer>();
        timerAll = .9f;
        timer = timerAll;
    }

    

    public void NextList()
    {
        controller.NextScene();
       
    }

    private void Update()
    {
        if (PhotonNetwork.IsMasterClient == false)
        {
            return;
        }
        else
        {
            if (timer <= 0)
            {
                Spawn();
                timer = timerAll;
            }
            else
            {
                timer -= Time.deltaTime;
            }

        }
    }

    public void Spawn()
    {                     
       int x = Random.Range(0, enmys.Count);
       PhotonNetwork.Instantiate(enmys[x].name, new Vector2(Random.Range(-4f, 4f), 5f), transform.rotation);         
        
    }


}
