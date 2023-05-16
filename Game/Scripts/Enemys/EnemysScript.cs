using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemysScript : MonoBehaviour
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
   
   // public float minG, maxG;
    
    // Start is called before the first frame update
    void Start()
    {
        
        _word = GetComponentInChildren<Text>();
        
        rb = GetComponent<Rigidbody2D>();
        _word = GetComponentInChildren<Text>();
        _word.text = data.word;
        _text = _word.text;
        PlayerAtk.instance.enemys.Add(gameObject);
        score = _word.text.Length * 10;
        _word.transform.localScale = new Vector3(1.5f, 1.5f, 0);
        //rb.gravityScale = Random.Range(minG, maxG);
        if(GameController.instance.slowDown == true)
        {
            speedMinus = 0.8f;
        }
        else
        {
            speedMinus = 0;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void ChangeWord(int x)
    {
        _word.color = Color.red;
        char c = '_';
        string novaString = c.ToString() + _text.Substring(x+1);
        _word.text = novaString;
        Instantiate(data.hitEff, transform.position, Quaternion.identity);

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
        AudioSfxController.instance.Play(data.exp);
        Instantiate(exp,transform.position, Quaternion.identity);
        PlayerAtk.instance.enemys.Remove(gameObject);
        HudController.instance.AddScore(score);
        GameController.instance.AddWord();
        SpawnManager.instance.Add();
        Boss();
        Destroy(gameObject);
    }

    public void Deslimite()
    {
        Instantiate(exp, transform.position, Quaternion.identity);
        PlayerAtk.instance.enemys.Remove(gameObject);
        SpawnManager.instance.Add();
        if(gameObject == PlayerAtk.instance.eny)
        {
            PlayerAtk.instance.EneDead();
        }
        Boss();
        Destroy(gameObject);
    }

    public void Boss()
    {
        if(gameObject.GetComponent<BossScript>() != null)
        {
            SpawnManager.instance.bossList.Remove(gameObject);
            gameObject.GetComponent<BossScript>().Action();
            SpawnManager.instance.enemysAccount = ene;
        }
    }

    public void Movement()
    {
        transform.Translate(-Vector2.up * (speed-speedMinus) * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMove.instance.TakeDamege(data.damage);
            Deslimite();

        }
        if (collision.gameObject.CompareTag("Shield"))
        {
            collision.gameObject.GetComponent<ShieldOnPlayer>().TakeDamage(data.damage);
            Deslimite();

        }
    }
}
