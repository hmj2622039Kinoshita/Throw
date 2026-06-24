using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GlowItemThrow : MonoBehaviour
{
    [SerializeField] GameObject GlowItem; // 投げるアイテム
    [SerializeField] float throwForce = 10f; // 投げる速さ
    [SerializeField] Camera camera; // カメラの位置取得

    public void Throw()
    {
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); // 画面中央にRay
        Vector3 targetPoint= ray.GetPoint(100f);
        Vector3 dir = ray.direction; // 方向ベクトル
        Vector3 spawnPos = camera.transform.position + camera.transform.forward * 1f;
        GameObject orb = Instantiate(GlowItem,spawnPos,Quaternion.identity); // Prefab生成
        Rigidbody rb = orb.GetComponent<Rigidbody>(); // orbの物理取得
        rb.AddForce(dir * throwForce, ForceMode.Impulse);
    }
}
