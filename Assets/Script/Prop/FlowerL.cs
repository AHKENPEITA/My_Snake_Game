using UnityEngine;

public class FlowerL : MonoBehaviour
{
    private int DestroyCountDown;
    public AudioClip FlowerEat;
    private void Start()
    {
        DestroyCountDown = 2000;
    }

    private void FixedUpdate()
    {
        DestroyCountDown--;
        gameObject.transform.Rotate(0, 0.7f, 0, Space.World);
        if (DestroyCountDown == 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player"))
        {
            other.gameObject.GetComponent<PlayerScript>().score += 50;
            AudioSource.PlayClipAtPoint(FlowerEat, transform.position);
            Destroy(gameObject);
        }
    }
}
