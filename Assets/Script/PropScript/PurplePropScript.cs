using UnityEngine;

public class PurplePropScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
