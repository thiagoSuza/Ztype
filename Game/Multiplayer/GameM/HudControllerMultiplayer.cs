using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HudControllerMultiplayer : MonoBehaviour
{
    PhotonView view;

    public int life;
    public int scoreNumber;
    public int wordNumber;

    public Text scoreTxt, wordTxt;
    public Slider lifeBar;

    public GameObject pauserPanel, gameOverPanel;

    private int init;
    public GameObject[] panels, spawners,backgrounds;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        life = 20;
        lifeBar.maxValue = life;
        lifeBar.value = life;
        scoreNumber = 0;
        wordNumber = 0;
        scoreTxt.text = scoreNumber.ToString();
        wordTxt.text = wordNumber.ToString();
        init = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pauserPanel.SetActive(true);
        }
    }

    public void AddScore(int x)
    {
        view.RPC("AddScoreRPC", RpcTarget.All,x);
    }

    public void AddWord()
    {
        view.RPC("AddWordRPC", RpcTarget.All);
    }

    public void TakeDamage()
    {
        view.RPC("TakeDamageRPC", RpcTarget.All);
    }

    [PunRPC]
    public void TakeDamageRPC()
    {
        life -= 0;
        lifeBar.value = life;
        if(life <= 0)
        {
            gameOverPanel.SetActive(true);
        }
    }

    [PunRPC]
    void AddScoreRPC(int x)
    {
        scoreNumber += x;
        scoreTxt.text = scoreNumber.ToString();
    }

    [PunRPC]
    void AddWordRPC()
    {
        wordNumber++;
        wordTxt.text = wordNumber.ToString();
    }

    public void Disconnect()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene(0);
    }

    public void Continue()
    {
        pauserPanel.SetActive(false);
    }

    public void NextScene()
    {
        view.RPC("NextSceneRPC", RpcTarget.All);
    }

    [PunRPC]
    void NextSceneRPC()
    {
        init++;
        panels[init].SetActive(true);
        spawners[init].SetActive(true);
        backgrounds[init].SetActive(true);
    }
}
