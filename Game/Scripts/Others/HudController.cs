using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HudController : MonoBehaviour
{
    public static HudController instance;

    public Text score,higScoreTp ,higScoreTl;
    public Text charP,charV,charTl;
    public int intScore;
    public int sceneIndex;
    
    public GameObject losePanel, pauserPanel;

    public bool isMultiplyscore;

    public int moneyEar;
    [SerializeField]
    private bool isStop;


    private void Awake()
    {
        instance = this;
        Time.timeScale = 1f;
    }

    public void EarnMoney()
    {
        moneyEar = PlayerPrefs.GetInt("DinheiroBonus", 0);
        moneyEar += 200;
        PlayerPrefs.SetInt("DinheiroBonus", moneyEar);
    }


    // Start is called before the first frame update
    void Start()
    {
        isMultiplyscore = false;
        CheckScore();
        isStop = false;
    }

   


    public void CheckScore()
    {
        if(sceneIndex == 2) {
            intScore = 0;

        }
        else
        {
            intScore = PlayerPrefs.GetInt("ScoreToSave");
        }

        score.text = intScore.ToString();
    }
    public void CharInRow()
    {
        charP.text = PlayerPrefs.GetInt("charRow", 0).ToString();       
        charTl.text = PlayerPrefs.GetInt("charRow", 0).ToString();
    }

    public void HighScore()
    {
        if(intScore>= PlayerPrefs.GetInt("highscore",0))
        {
            PlayerPrefs.SetInt("highscore", intScore);
            higScoreTp.text = intScore.ToString();           
            higScoreTl.text = intScore.ToString();
        }
        else
        {
            higScoreTp.text = PlayerPrefs.GetInt("highscore", 0).ToString();
            higScoreTl.text = PlayerPrefs.GetInt("highscore", 0).ToString();
            
        }
       
    }

    public void Vitoria()
    {
        
        Time.timeScale = 0f;
        PlayerAtk.instance.isPaudes = true;
        HighScore();
        CharInRow();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isStop)
            {
                OpenPauserMenu();
                isStop = true;
            }
            else
            {
                ClosePauserMenu();
                isStop = false;
            }
            
        }     


      
    }

    

    public void OpenPauserMenu()
    {
        pauserPanel.SetActive(true);
        PlayerAtk.instance.isPaudes = true;
        Time.timeScale = 0;
        HighScore();
        CharInRow();
        
    }

    public void ClosePauserMenu()
    {
        pauserPanel.SetActive(false);
        PlayerAtk.instance.isPaudes = false;
        Time.timeScale = 1f;
        isStop = false;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        losePanel.SetActive(true);
        HighScore();
        CharInRow();
        PlayerPrefs.SetInt("MoneyAdd", intScore / 3);
        Time.timeScale = 0f;
        
    }

    public void NextScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }


    public void AddScore(int x)
    {
        if (!isMultiplyscore)
        {
            intScore += x;
            score.text = intScore.ToString();
        }
        else
        {
            intScore += x*2;
            score.text = intScore.ToString();
        }
        

    }

    public void ScoreX2()
    {
        StartCoroutine(TwoScore());
    }

    IEnumerator TwoScore()
    {
        isMultiplyscore = true;
        yield return new WaitForSeconds(10f);
        isMultiplyscore = false;
    }
}
