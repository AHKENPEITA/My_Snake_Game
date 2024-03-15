using UnityEngine;
public class FlowerX : MonoBehaviour
{
    private int DestroyCountDown;
    public AudioClip FlowerEat;
    private void Start()
    {
        DestroyCountDown = 1500;
    }

    private void FixedUpdate()
    {
        DestroyCountDown--;
        gameObject.transform.Rotate(0, 1, 0, Space.World);
        if (DestroyCountDown == 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player"))
        {
            other.gameObject.GetComponent<PlayerScript>().score += 250;
            AudioSource.PlayClipAtPoint(FlowerEat, transform.position);
            Destroy(gameObject);
        }
    }
}

