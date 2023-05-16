using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScoreAndWord : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("WordsToSave", GameController.instance.wordNumber);
        PlayerPrefs.SetInt("ScoreToSave", HudController.instance.intScore);
    }

    
}
