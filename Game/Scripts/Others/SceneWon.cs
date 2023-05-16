using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class SceneWon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Finsh", 17);
    }


    public void Finsh()
    {
        if(PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect();
        }
        SceneManager.LoadScene(0);
    }
    
}
