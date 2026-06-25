using UnityEngine;

public class MouseView : MonoBehaviour
{
    [SerializeField] float mouseSpeed = 85f;
    [SerializeField] float mouseHigh = -90f;
    [SerializeField] float mouseLow = 90f;

    float xRotation = 0f; // カメラの初期の上下の向いている位置（正面）
    private void Start()
    {   // マウスの視点操作
        Cursor.lockState = CursorLockMode.Locked; // マウスカーソルを画面中央に固定する
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime; // マウスの移動量の取得
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, mouseHigh, mouseLow); // 見上げ範囲

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // 上下の回転

        transform.parent.Rotate(Vector3.up * mouseX); // trans.parent = Player Playerの左右回転

    }
}
