using UnityEngine;

public class Ghostwatch : MonoBehaviour
{
    [SerializeField] float onTime = 1f; // 出現する時間
    [SerializeField] float offTime = 1f; // 消える時間
    [SerializeField]private GameObject ghost;
    private bool lightHit;

    private void Update()
    {
        if (lightHit == true)
        {
            onTime += Time.deltaTime;
            if (onTime >= 1f)
            {
                ghost.SetActive(true); // ゴーストが見える（表示）
                offTime = 0f;
            }
        }
        else
        {
            offTime += Time.deltaTime;
            onTime = 0f;
            if (offTime >= 1f)
            {
                ghost.SetActive(false);
                offTime = 1f;
            }
        }
    }

    public void LightHit()
    {
        lightHit = true;
    }
    public void LightExit()
    {
        lightHit = false;
    }
}