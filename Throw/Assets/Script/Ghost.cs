using UnityEngine;
using System.Collections;
using TMPro;

public class Ghost : MonoBehaviour
{]
    [SerializeField] Transform player;
    [SerializeField] float runDistance = 7f;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] GameObject deathEffect;

    private bool run = false;
    private Vector3 runDirection;
    private float runTimer;
    private Material mat;
    private bool deathnum = false; // 重複して死なないようにする（当たらないように）

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if(run == true && distance <= runDistance)
        {
            RunStart();
        }

        if (run == false)
        {
            transform.position += runDirection * moveSpeed * Time.deltaTime;
            runTimer -= Time.deltaTime;
            if(runTimer <= 0f)
            {
                run = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (deathnum == true) return; // 処理中にもう一回発動しないようにするために必要

        if(other.CompareTag("orb"))
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        deathnum = true;

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
