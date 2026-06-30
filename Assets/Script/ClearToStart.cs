using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearToStart : MonoBehaviour
{
   public void ClearScene()
    {
        SceneManager.LoadScene("Start");
    }
}
