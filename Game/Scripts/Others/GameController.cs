using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;   
    public Text wordCounter;
    public int wordNumber;
    public GameObject effct;
    public bool slowDown;

    public GameObject[] list;
    public GameObject[] backgrounds;
    public int indexList;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        indexList = 0;
       slowDown = false;
        CheckWords();
        wordCounter.text = wordNumber.ToString();
        backgrounds[0].SetActive(true);
    }

    public void CheckWords()
    {
        if(HudController.instance.sceneIndex == 2)
        {
            wordNumber = 0;
        }
        else
        {
            wordNumber = PlayerPrefs.GetInt("WordsToSave"); 
        }
    }

    public void NextList()
    {

        Destroy(list[indexList]);        
        indexList++;
        StartCoroutine(Change());
        list[indexList].SetActive(true);
        
    }

    IEnumerator Change()
    {
        yield return new WaitForSeconds(2.1f);
        backgrounds[indexList-1].SetActive(false);
        backgrounds[indexList].SetActive(true);
    }
    

    public void AddWord()
    {
        wordNumber++;
        wordCounter.text = wordNumber.ToString();
        Instantiate(effct,wordCounter.transform.position,transform.rotation);
    }

    public void TimeSlow()
    {
        StartCoroutine(Slw());
    }

    IEnumerator Slw()
    {
        slowDown = true;
        yield return new WaitForSeconds(10);
        slowDown = false;
    }

    
}
