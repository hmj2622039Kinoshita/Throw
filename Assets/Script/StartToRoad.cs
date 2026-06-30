using UnityEngine;
using UnityEngine.SceneManagement;

public class StartToRoad : MonoBehaviour
{
   public void PlayButton()
    {
        SceneManager.LoadScene("Road");
    }
}
