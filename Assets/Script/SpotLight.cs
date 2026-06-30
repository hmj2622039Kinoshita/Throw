using UnityEngine;

public class SpotLight : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit;" + other.name);
        if(other.CompareTag("Ghost"))
        {
            Ghostwatch ghostwatch = GetComponentInParent<Ghostwatch>();
            if(ghostwatch != null)
            {
                ghostwatch.LightHit();
                Debug.Log("On");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Ghost"))
        {
            Ghostwatch ghostwatch = GetComponent<Ghostwatch>();
            if(ghostwatch != null)
            {
                ghostwatch.LightExit();
                Debug.Log("Off");
            }
        }
    }
}
