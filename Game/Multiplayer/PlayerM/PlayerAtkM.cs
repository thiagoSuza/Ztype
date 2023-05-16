using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerAtkM : MonoBehaviour
{
    
    
    char inputBuffer;
    public string stringToCompare;
    public int x;

    private bool isTarge;
    public bool isPaudes;

    public float distance;

    public GameObject eny = null;
    public List<GameObject> enemys;

    public GameObject bullet = null;
    public GameObject turret;
    public Transform firePos;

    public Vector2 direction;
    public Vector2 targetPosition = Vector2.zero;

    public int charInRow;

    

    // public GameObject[] picks;

   public PhotonView view;

    



    

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        charInRow = 0;
        x = 0;
        isTarge = false;
        isPaudes = false;

        

        
    }

    // Update is called once per frame
    void Update()
    {
        if( view.IsMine )
        {
            if (!isPaudes)
            {
                Action();
            }

            if (eny != null)
            {
                Aim();
                Distance();
            }
            else
            {
                turret.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }

            if(eny== null && isTarge)
            {
                EneDead();
            }
        }
        

        
    }

   

    public void Aim()
    {
        targetPosition = eny.transform.position;
        direction = targetPosition - (Vector2)transform.position;
        turret.transform.up = direction;


    }

    public void Distance()
    {
        if (eny != null)
        {
            distance = Vector3.Distance(turret.transform.position, eny.transform.position);

        }
    }


    public void Seeker(char c)
    {
        if (!isTarge && enemys != null)
        {
            foreach (var item in enemys)
            {
                if (item.GetComponent<EnemysScriptM>()._text[0] == c && item.GetComponent<EnemysScriptM>().isSelected == false)
                {

                    eny = item;
                    Aim();
                    stringToCompare = eny.GetComponent<EnemysScriptM>()._text;
                    isTarge = true;

                }
            }


        }

    }


    public void Action()
    {
        if (Input.anyKeyDown)
        {
            string inputString = Input.inputString;
            if (inputString.Length > 0)
            {
                inputBuffer += inputString[0];
                // Debug.Log("Tecla(s) digitada(s): " + inputString);
                Seeker(inputString[0]);
                CheckChar(inputString[0]);


            }


        }
    }

    public void CheckChar(char c)
    {
        if (isTarge)
        {
            
            if (stringToCompare[x] == c)
            {
                eny.GetComponent<EnemysScriptM>().ChangeWord(x);
                if (x < stringToCompare.Length)
                {
                    x++;
                    eny.GetComponent<EnemysScriptM>().SLowDown();
                    PhotonNetwork.Instantiate(bullet.name, transform.position, turret.transform.rotation); 
                   
                    


                    charInRow++;
                    if (charInRow % 10 == 0)
                    {
                       // int x = Random.Range(0, picks.Length);
                       // Instantiate(picks[x], new Vector2(Random.Range(-9.2f, 9.2f), 9f), transform.rotation);
                    }

                }
                if (x == stringToCompare.Length)
                {
                    eny.GetComponent<EnemysScriptM>().Des();
                    eny = null;
                    targetPosition = Vector2.zero;
                    stringToCompare = "";
                    isTarge = false;
                    x = 0;
                }

               
            }
            else
            {
                
                if (charInRow >= PlayerPrefs.GetInt("charRow", 0))
                {
                    PlayerPrefs.SetInt("charRow", charInRow);
                }
                charInRow = 0;
                
            }
        }
    }

   

    public void EneDead()
    {

        isTarge = false;
        eny = null;
        stringToCompare = "";
        x = 0;
    }
}
