using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MultiplayerAutoKill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Dest", .2f);
    }

   void Dest()
    {
        PhotonNetwork.Destroy(gameObject);
    }
}
