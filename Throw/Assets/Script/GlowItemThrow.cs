using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GlowItemThrow : MonoBehaviour
{
    [SerializeField] Transform rightHand; // 発射位置
    [SerializeField] GameObject GlowItem; // 投げるアイテム
    [SerializeField] float throwForce = 10f; // 投げる速さ
    [SerializeField] Camera camera; // カメラの位置取得

    private void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            Throw();
        }
    }

    void Throw()
    {
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); // 画面中央にRay
        Vector3 targetPoint= ray.GetPoint(100f);
        Vector3 dir = ray.direction; // 方向ベクトル
        GameObject orb = Instantiate(GlowItem,rightHand.position,Quaternion.identity); // Prefab生成
        Rigidbody rb = orb.GetComponent<Rigidbody>(); // orbの物理取得
        rb.AddForce(dir * throwForce, ForceMode.Impulse);
    }

}
