using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiplayerPanelQuit : MonoBehaviour
{
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
