using UnityEngine;

public class RedPropScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
