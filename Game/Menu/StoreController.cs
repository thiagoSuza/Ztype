using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreController : MonoBehaviour
{
    public static StoreController Instance;

    public GameObject[] buyBtns;
    public GameObject[] useBtn;


    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        CheckBuyBtns();
        CheckUseBtn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckBuyBtns()
    {
        if (PlayerPrefs.GetInt("Buy1", 0) == 1)
        {
            buyBtns[0].SetActive(false);
        }

        if (PlayerPrefs.GetInt("Buy2", 0) == 1)
        {
            buyBtns[1].SetActive(false);
        }

        if (PlayerPrefs.GetInt("Buy3", 0) == 1)
        {
            buyBtns[2].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Buy4", 0) == 1)
        {
            buyBtns[3].SetActive(false);
        }
    }


    public void CheckUseBtn()
    {

        if (PlayerPrefs.GetInt("Buy1", 0) == 1)
        {
            useBtn[0].SetActive(true);
        }

        if (PlayerPrefs.GetInt("Buy2", 0) == 1)
        {
            useBtn[1].SetActive(true);
        }

        if (PlayerPrefs.GetInt("Buy3", 0) == 1)
        {
            useBtn[2].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Buy4", 0) == 1)
        {
            useBtn[3].SetActive(true);
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void BuyBtn1()
    {
        StoreMoneyController.instance.Buy(1000);
        if(StoreMoneyController.instance.canBuy==true)
        {
            PlayerPrefs.SetInt("Buy1", 1);
            CheckBuyBtns();
            CheckUseBtn();
            StoreMoneyController.instance.canBuy=false;
        }
        
    }

    public void BuyBtn2()
    {
        StoreMoneyController.instance.Buy(2000);
        if (StoreMoneyController.instance.canBuy == true)
        {
            PlayerPrefs.SetInt("Buy2", 1);
            CheckBuyBtns();
            CheckUseBtn();
            StoreMoneyController.instance.canBuy = false;
        }
    }

    public void BuyBtn3()
    {
        StoreMoneyController.instance.Buy(8000);
        if (StoreMoneyController.instance.canBuy == true)
        {
            PlayerPrefs.SetInt("Buy3", 1);
            CheckBuyBtns();
            CheckUseBtn();
            StoreMoneyController.instance.canBuy = false;
        }
    }

    public void BuyBtn4()
    {
        StoreMoneyController.instance.Buy(4000);
        if (StoreMoneyController.instance.canBuy == true)
        {
            PlayerPrefs.SetInt("Buy4", 1);
            CheckBuyBtns();
            CheckUseBtn();
            StoreMoneyController.instance.canBuy = false;
        }
    }
}
