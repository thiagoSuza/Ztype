using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiplayerGameOver : MonoBehaviour
{
    public GameObject restar, exit;
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        if(PhotonNetwork.IsMasterClient == false)
        {
            restar.SetActive(false);
            exit.SetActive(true);
        }
        
    }

    public void Disconnect()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene(0);
    }

    public void Restar()
    {
        view.RPC("RestarRPC", RpcTarget.All);
    }

    [PunRPC]
    void RestarRPC()
    {
        PhotonNetwork.LoadLevel(7);
    }

}
