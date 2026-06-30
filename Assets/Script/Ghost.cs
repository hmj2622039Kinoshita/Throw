using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour
{
    [SerializeField] GameObject deathEffect;
    [SerializeField] GameManager gm;

    private bool deathnum = false; // 重複して死なないようにする（当たらないように）
    public void OnTriggerEnter(Collider other)
    {
        if (deathnum == true) return; // 処理中にもう一回発動しないようにするために必要

        if(other.CompareTag("orb")) // オーブとの当たり判定
        {
            StartCoroutine(Death());
            gm.Die();
        }
    }

    IEnumerator Death()
    {
        deathnum = true;　// 死んだかどうか

        float t = 0;
        Vector3 startScale = transform.localScale;
        
        while(t < 1f)
        {
            t += Time.deltaTime * 0.5f;
            transform.position += Vector3.up * Time.deltaTime * 0.4f;

            transform.localScale = Vector3.Lerp(startScale, new Vector3(0, 0, 0), t);
            yield return null; // １フレーム待つ
        }
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity); // 消える瞬間にエフェクト
        }
        Destroy(gameObject);
    }

}
