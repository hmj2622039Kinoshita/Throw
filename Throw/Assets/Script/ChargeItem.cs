using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ChargeItem : MonoBehaviour
{
    [SerializeField] float maxScale = 1f; // 最大サイズ
    [SerializeField] float minScale = 0f; // 出現時のサイズ
    [SerializeField] float chargeSpeed = 0.7f; // チャージスピード
    [SerializeField] GlowItemThrow throwScript;
    private float charge = 0f; // チャージ量（フル＝１）
    private bool itemstate = false; // チャージ中

    public void Update()
    {
        ChargeUp();
        CheckFire();
    }

   void ChargeUp()
    {
        if(itemstate == false)
        {
            charge += Time.deltaTime * chargeSpeed;
            charge = Mathf.Clamp01(charge);
            float t = Mathf.SmoothStep(0f, 1f, charge); // 滑らかにチャージ
            transform.localScale = new Vector3(1f, 1f, 1f) * Mathf.Lerp(minScale, maxScale, t);
        }
        if(charge >= 1f)
        {
            itemstate = true;
        }
    }

    public void CheckFire()
    {
        if (itemstate == true)
        {
            if(Mouse.current.leftButton.wasPressedThisFrame)
            {
                throwScript.Throw();
                ResetCharge();
            }
        }
    }

    void ResetCharge()
    {
        charge = 0f;
        itemstate = false;
        transform.localScale = new Vector3(1f, 1f, 1f) * minScale;
    }

}
