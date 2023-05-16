using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class MultiplayerLaserLeng : MonoBehaviour
{
    PhotonView view;
    PlayerAtkM[] atk;
    private float leng;
    

    void Start()
    {
        view = GetComponent<PhotonView>();
        atk = FindObjectsOfType<PlayerAtkM>();
        if (atk[0].view.IsMine)
        {
            leng = (atk[0].distance / 6);
        }
        else
            {
            leng = (atk[1].distance / 6);
        }

        Tamanho(leng);

    }

    public void Tamanho(float y)
    {
        view.RPC("TamanhoRPC", RpcTarget.All, y);
    }

    [PunRPC]
    void TamanhoRPC(float y)
    {
        this.transform.localScale = new Vector3(0.4f, y, 0f);
    }
}
