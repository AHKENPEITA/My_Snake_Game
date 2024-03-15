using UnityEngine;

public class FlowerM : MonoBehaviour
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
        gameObject.transform.Rotate(0, 0.6f, 0, Space.World);
        if (DestroyCountDown == 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player"))
        {
            other.gameObject.GetComponent<PlayerScript>().score += 40;
            AudioSource.PlayClipAtPoint(FlowerEat, transform.position);
            Destroy(gameObject);
        }
    }
}