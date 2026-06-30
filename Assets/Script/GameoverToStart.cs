using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverToStart : MonoBehaviour
{
    public void OverScene()
    {
        SceneManager.LoadScene("Start");
    }
}
