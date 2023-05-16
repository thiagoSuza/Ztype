using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerAtk : MonoBehaviour
{
    public static PlayerAtk instance;
    public PlayerSO[] data;
    char inputBuffer;
    public string stringToCompare;
    public int x;

    private bool isTarge;
    public bool isPaudes;

    public float distance;

    public GameObject eny = null;
    public List<GameObject> enemys;

    public GameObject bullet = null;
    public GameObject[] turret;
    public Transform firePos;

    public Vector2 direction;
    public Vector2 targetPosition= Vector2.zero;

    public int charInRow;

    public int selectedShip;

    public GameObject[] picks;

    private int bombNumber;
    [SerializeField]
    private Text bomb;
    [SerializeField]
    private GameObject bomber;
    [SerializeField]
    private GameObject pS;



    private void Awake()
    {
        instance = this;
        selectedShip = PlayerPrefs.GetInt("nave", 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        bullet = PlayerMove.instance.data[PlayerPrefs.GetInt("nave", 0)].laser;
        charInRow = 0;
        x = 0;
        isTarge = false;
        isPaudes = false;
        bombNumber = 2;
        bomb.text = 2.ToString();

       // stringToCompare = "lua"; /*eny.GetComponentInChildren<Text>().text;*/
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaudes)
        {
            Action();
        }

        if(eny != null)
        {
            Aim();
            Distance();
        }
        else
        {
            turret[selectedShip].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            UseBomb();
        }
    }

    public void UseBomb()
    {
        if(bombNumber >0)
        {
            bombNumber--;
            bomb.text = bombNumber.ToString();
             Instantiate(bomber, new Vector2(0f, 0f), transform.rotation);
            Instantiate(pS, new Vector2(0f, 0f), transform.rotation);
        }
        
    }

    public void Aim()
    {
        targetPosition = eny.transform.position;
        direction = targetPosition - (Vector2)transform.position;
        turret[selectedShip].transform.up = direction;

        
    }

    public void Distance()
    {
        if(eny != null)
        {
           distance = Vector3.Distance(turret[selectedShip].transform.position,eny.transform.position);
           
        }
    }


    public void Seeker(char c)
    {
        if (!isTarge)
        {
            foreach (var item in enemys)
            {
                if (item.GetComponent<EnemysScript>()._text[0] == c)
                {
                    
                    eny = item;
                    Aim();
                    stringToCompare = eny.GetComponent<EnemysScript>()._text;
                    isTarge=true;
                    
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
        if(isTarge)
        {
           /* Debug.Log(stringToCompare);
            Debug.Log(inputBuffer);
            Debug.Log(stringToCompare[x]);*/
            if (stringToCompare[x] == c)
            {
                eny.GetComponent<EnemysScript>().ChangeWord(x);
                if (x<stringToCompare.Length)
                {
                    x++;
                    eny.GetComponent<EnemysScript>().SLowDown();
                    Instantiate(bullet,transform.position, turret[selectedShip].transform.rotation);
                    AudioSfxController.instance.Play(data[selectedShip].laserSong);
                    charInRow++;
                    if(charInRow % 10 == 0)
                    {
                        int x = Random.Range(0,picks.Length);
                        Instantiate(picks[x], new Vector2(Random.Range(-9.2f, 9.2f), 9f), transform.rotation);
                    }
                    
                }
                if (x==stringToCompare.Length) 
                {
                    eny.GetComponent<EnemysScript>().Des();
                    eny = null;
                    targetPosition = Vector2.zero;
                    stringToCompare = "";
                    isTarge = false;
                    x = 0;
                }
                
               /* Debug.Log("Ok");
                Debug.Log(x);*/
            }
            else
            {
                AudioSfxController.instance.Play(data[selectedShip].miss);
                if (charInRow >= PlayerPrefs.GetInt("charRow", 0))
                {
                    PlayerPrefs.SetInt("charRow", charInRow);
                }
                charInRow = 0;
               /* Debug.Log("Errou seu safadinho");
                Debug.Log(x);*/
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
