using UnityEngine;

public class YellowPropScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
