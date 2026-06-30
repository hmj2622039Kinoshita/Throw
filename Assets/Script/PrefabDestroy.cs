using UnityEngine;

public class PrefabDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)  // “–‚½‚Á‚½‚çƒI[ƒuíœ
    {
        Destroy(gameObject);
    }
}
