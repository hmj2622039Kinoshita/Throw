using UnityEngine;

public class GlowItemThrow : MonoBehaviour
{
    [SerializeField] GameObject GlowItem; // 投げるアイテム
    [SerializeField] float throwForce = 10f; // 投げる速さ
    [SerializeField] private Camera playerCamera; // カメラの位置取得

    public void Throw()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); // 画面中央にRay
        Vector3 targetPoint= ray.GetPoint(100f);
        Vector3 dir = ray.direction; // 方向ベクトル
        Vector3 spawnPos = playerCamera.transform.position + playerCamera.transform.forward * 1f;
        GameObject orb = Instantiate(GlowItem,spawnPos,Quaternion.identity); // Prefab生成
        Rigidbody rb = orb.GetComponent<Rigidbody>(); // orbの物理取得
        rb.AddForce(dir * throwForce, ForceMode.Impulse);
    }

    
}
