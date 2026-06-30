using UnityEngine;
using UnityEngine.SceneManagement;

public class RoadToLevel1 : MonoBehaviour
{ // Road‚©‚çLevel1ƒV[ƒ“‘JˆÚ
    private float timer = 0f;
    private float timelimit = 4f;

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= timelimit)
        {
            SceneManager.LoadScene("Level1");
        }
    }

}
