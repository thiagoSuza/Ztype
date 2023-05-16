using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class EnemysScriptM : MonoBehaviour
{
    public EnemysSO data;
    public Text _word;
    public string _text;
    public int score;
    public GameObject exp;

    public Rigidbody2D rb;

    public float speed;
    public float speedMinus;

    [SerializeField]
    private int ene;

    PhotonView view;
    public HudControllerMultiplayer hud;
    PlayerAtkM[] player;

    public bool isSelected;


    
    void Start()
    {
        hud = FindFirstObjectByType<HudControllerMultiplayer>();
        view = GetComponent<PhotonView>();
        _word = GetComponentInChildren<Text>();

        rb = GetComponent<Rigidbody2D>();
        _word = GetComponentInChildren<Text>();
        _word.text = data.word;
        _text = _word.text;       
        score = _word.text.Length * 10;
        _word.transform.localScale = new Vector3(1.5f, 1.5f, 0);
        player = FindObjectsOfType<PlayerAtkM>();
        
        /* if (GameController.instance.slowDown == true)
         {
             speedMinus = 0.8f;
         }
         else
         {
             speedMinus = 0;
         }*/
        addToPlayerList();
        isSelected = false;
    }

    public void addToPlayerList()
    {
        player[0].enemys.Add(this.gameObject);
        player[1].enemys.Add(this.gameObject);

    }
    public void RemoveToPlayerList()
    {
        player[0].enemys.Remove(this.gameObject);
        player[1].enemys.Remove(this.gameObject);

    }


    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void ChangeWord(int x)
    {

        view.RPC("ChangeWordRPC", RpcTarget.All,x);
        
    }

    [PunRPC]
    void ChangeWordRPC(int x)
    {
        isSelected = true;
        _word.color = Color.red;
        char c = '_';
        string novaString = c.ToString() + _text.Substring(x + 1);
        _word.text = novaString;
        
    }


    public void SLowDown()
    {
        StartCoroutine(SlwDown());
    }

    IEnumerator SlwDown()
    {
        speedMinus = speed;
        yield return new WaitForSeconds(.2f);
        speedMinus = 0;
    }

    public void Des()
    {
        if(GetComponent<BossMultiplayer>() != null)
        {
            GetComponent<BossMultiplayer>().NextList();
        }
        view.RPC("DesRPC", RpcTarget.All);
        
    }

    [PunRPC]
    void DesRPC()
    {
        Instantiate(exp, transform.position, Quaternion.identity);        
        if(PhotonNetwork.IsMasterClient) {
            hud.AddWord();
            hud.AddScore(300);
            
        }       
        RemoveToPlayerList();
        if (PhotonNetwork.IsMasterClient || view.IsMine)
        {
            PhotonNetwork.Destroy(gameObject);
        }

    }

    public void Deslimite()
    {
        view.RPC("DeslRPC", RpcTarget.All);
    }
    [PunRPC]
    void DeslRPC()
    {
        Instantiate(exp, transform.position, Quaternion.identity);       
        if (player[0].eny == this)
        {
            player[0].EneDead();
        }
        if (player[1].eny == this)
        {
            player[1].EneDead();
        }
        RemoveToPlayerList();
        if (PhotonNetwork.IsMasterClient || view.IsMine)
        {
            PhotonNetwork.Destroy(gameObject);
        }

    }



  

    public void Movement()
    {
        transform.Translate(-Vector2.up * (speed - speedMinus) * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hud.TakeDamage();
            Deslimite();

        }


        if (collision.gameObject.CompareTag("Shield"))
        {
            collision.gameObject.GetComponent<ShieldOnPlayer>().TakeDamage(data.damage);
            Deslimite();

        }
    }
}