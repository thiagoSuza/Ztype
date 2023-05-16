using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerMoveMultiplayer : MonoBehaviour
{
    public float speed = 2;
    public PhotonView view;
    public Text _name;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        _name = GetComponentInChildren<Text>();
        if(view.IsMine)
        {
            _name.text = PhotonNetwork.NickName;
        }
        else
        {
            _name.text = view.Owner.NickName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(view.IsMine) {

            Movement();
        }
        
    }


    public void Movement()
    {
        /*if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

         if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }*/

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }
}
