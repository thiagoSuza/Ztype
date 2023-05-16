using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectedShip : MonoBehaviour
{
    public GameObject[] selectedShip;
    public int x;


    private void Awake()
    {
        x = PlayerPrefs.GetInt("nave", 0);
        ChossenShip(x);
    }

    public void ChossenShip(int x)
    {
        foreach (var ship in selectedShip)
        {
            ship.gameObject.SetActive(false);
        }

        switch (x)
        {
            case 0:
                selectedShip[0].SetActive(true);
                break;
            case 1:
                selectedShip[1].SetActive(true);
                break;
            case 2:
                selectedShip[2].SetActive(true);
                break;
            case 3:
                selectedShip[3].SetActive(true);
                break;
            case 4:
                selectedShip[4].SetActive(true);
                break;
            
        }
    }
}
