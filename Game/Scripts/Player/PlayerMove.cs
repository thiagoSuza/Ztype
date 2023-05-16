using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove instance;

    public PlayerSO[] data;
    public int selectedShip;

    public GameObject shd;
    
    public float speed;

    public Slider barLife;
    public int life;


    private void Awake()
    {
        instance = this;
        selectedShip = PlayerPrefs.GetInt("nave", 0);
        speed = data[selectedShip].speed;
        life = data[selectedShip].life;
    }
    // Start is called before the first frame update
    void Start()
    {
         barLife.maxValue = life;
        barLife.minValue = 0;
        barLife.value = life;
    }

    public void TakeDamege(int damage)
    {
        life -= damage;
        barLife.value = life;
        Instantiate(data[selectedShip].hitEffect,transform.position, transform.rotation);
        AudioSfxController.instance.Play(data[selectedShip].getHurt);

        if (life <= 0)
        {
            HudController.instance.GameOver();

        }
    }

    public void HealthUp()
    {
        life += 2;
        barLife.value = life;
        if (life >= 10)
        {
            life = 10;
        }
    }




    private void FixedUpdate()
    {
        Movement();
    }


    public void Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    public void SetUpShield()
    {
        shd.SetActive(true);
    }
}
