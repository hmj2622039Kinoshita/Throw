using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] int clearCount = 5; // クリア数
    [SerializeField] float timelimit = 60f; // 制限時間
    [SerializeField] TextMeshProUGUI killUI;
    [SerializeField] TextMeshProUGUI timeUI;
    private int killCount = 0; // 現在の退治数
    private float timer; // タイマー


    private void Start()
    {
        timer = timelimit; // カウントダウン方式
    }
    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        if(killUI != null)
        {
            killUI.text = "" + killCount;
        }

        if(timeUI != null)
        {
            timeUI.text = "" + Mathf.Ceil(timer); // Ceil=小数点以下を切りあげる関数
        }
    }

    public void Die()
    {
        killCount++;
        if(killCount >= clearCount) // キル数が達したらシーン遷移
        {
            SceneManager.LoadScene("Clear");
        }
    }
}
