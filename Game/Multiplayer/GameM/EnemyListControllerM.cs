using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnemyListControllerM : MonoBehaviour
{
    public List<GameObject> gameObjects = new List<GameObject>();

    public PhotonView view;


    private void Start()
    {
        view = GetComponent<PhotonView>();
    }
}
