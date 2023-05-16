using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreMoneyController : MonoBehaviour
{
    public static StoreMoneyController instance;
    public Text moneyT;
    public int myMoney,aux;
    public GameObject noMoneyPanel;
    public bool canBuy;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpDadeMoney();


        canBuy = false;

    }

    public void UpDadeMoney()
    {
        aux = PlayerPrefs.GetInt("MoneyAdd", 0);
        myMoney = PlayerPrefs.GetInt("Money", 0);
        myMoney += aux + PlayerPrefs.GetInt("DinheiroBonus", 0);
        PlayerPrefs.SetInt("Money", myMoney);
        moneyT.text = myMoney.ToString();
        PlayerPrefs.SetInt("MoneyAdd", 0);
        PlayerPrefs.SetInt("DinheiroBonus", 0);
    }

  

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Buy(int x)
    {
        if(x<= myMoney)
        {
            myMoney -= x;
            PlayerPrefs.SetInt("Money", myMoney);
            moneyT.text = myMoney.ToString();
            canBuy = true;


        }
        else
        {
            noMoneyPanel.SetActive(true);
            canBuy = false;
        }
    }
}
