using UnityEngine;
using UnityEngine.SceneManagement;

public class RoadToLevel1 : MonoBehaviour
{
    private float timer = 0f;
    private float timelimit = 5f;

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= timelimit)
        {
            SceneManager.LoadScene("Level1");
        }
    }

}
