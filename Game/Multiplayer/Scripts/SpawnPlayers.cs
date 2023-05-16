using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject[] prefab;
    public int selectedShip;

    private void Awake()
    {
        selectedShip = PlayerPrefs.GetInt("nave", 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate(prefab[selectedShip].name,new Vector2(0,-3f),Quaternion.identity);
    }

   
}
