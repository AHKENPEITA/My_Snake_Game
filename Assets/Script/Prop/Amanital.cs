
using UnityEngine;

public class Amanital : MonoBehaviour
{
    public GameObject FoodInstantiator;

    public int ExpandCount;
    Vector3 Scale;

    public AudioClip EatClip;
    public  int DestroyCountDown;

    

    
    private void Start()
    {
        transform.Rotate(new Vector3(0, Random.Range(-180,180), 0), Space.World);
        Scale = transform.localScale;
        gameObject.transform.localScale = 0 * Scale;
        ExpandCount = 0;

        FoodInstantiator = GameObject.FindWithTag("FoodInstantiator");
        DestroyCountDown = Random.Range(16000,24000);
        
        
    }
    private void FixedUpdate()
    {
        
        if (DestroyCountDown>0)
        {
            DestroyCountDown--;
            if (ExpandCount < 100)
            {
                ExpandCount++;
                gameObject.transform.localScale = 0.01f * ExpandCount * Scale;
            }
          
        }
        else
        {
            if (ExpandCount > 0)
            {
                ExpandCount--;
                gameObject.transform.localScale = 0.01f * ExpandCount * Scale;
            }
            else
            {
                FoodInstantiator.GetComponent<FoodInstantiatorScript>().AmanitalNum--;
                Destroy(gameObject);
            }
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerScript>().UpsideDown = true;
            other.GetComponent<PlayerScript>().UpsideDownCount = 3600;
           AudioSource.PlayClipAtPoint(EatClip, gameObject.transform.position);
            FoodInstantiator.GetComponent<FoodInstantiatorScript>().AmanitalNum--;
            Destroy(gameObject);
        }
    }
}
