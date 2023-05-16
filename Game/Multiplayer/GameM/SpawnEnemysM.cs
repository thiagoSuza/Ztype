using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnEnemysM : MonoBehaviour
{
    PhotonView view;
    public List<GameObject> enmys;
    private float timer;
    [SerializeField]
    private float timerAll;
    public GameObject boss;
    public bool boosOk;
    [SerializeField]
    private float timeToInit;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        
        timer = timerAll;
        
    }


    


    private void Update()
    {
        if(timeToInit >= 0)
        {
            timeToInit -= Time.deltaTime;
        }
        else
        {
            if (PhotonNetwork.IsMasterClient == false || PhotonNetwork.CurrentRoom.PlayerCount != 2)
        {
            return;
        }
        else
        {
                if(PhotonNetwork.IsMasterClient == false)
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
        }

        
    }


    public void Spawn()
    {

        //view.RPC("SpawnRPC", RpcTarget.All);

        if (enmys.Count > 0)
        {
            int x = Random.Range(0, enmys.Count);
            PhotonNetwork.Instantiate(enmys[x].name, new Vector2(Random.Range(-4f, 4f), 5f), transform.rotation);
            enmys.Remove(enmys[x]);
        }
        else
        {
            if (!boosOk)
            {
                StartCoroutine(Boss());
            }

        }
    }

    [PunRPC]
    void SpawnBRPC()
    {
        
    }

    IEnumerator Boss()
    {
        yield return new WaitForSeconds(10);
        
        PhotonNetwork.Instantiate(boss.name,new Vector2(0,2f),Quaternion.identity);
        boosOk = true;
        PhotonNetwork.Destroy(gameObject);

    }
    
}
