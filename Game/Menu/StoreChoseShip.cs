using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreChoseShip : MonoBehaviour
{
    public Text[] title;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateTextLabel(PlayerPrefs.GetInt("nave", 0));
    }

   public void UpdateTextLabel(int x)
    {
        foreach (var item in title)
        {
            item.text = "USAR";
        }

        title[x].text = "USANDO";
        PlayerPrefs.SetInt("nave", x);
    }
}
