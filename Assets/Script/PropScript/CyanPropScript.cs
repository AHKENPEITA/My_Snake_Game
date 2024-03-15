using UnityEngine;

public class CyanPropScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
