using UnityEngine;
public class FoodScript : MonoBehaviour
{
    public GameObject FoodInstantiator;
    Vector3 Scale;

    public AudioClip EatClip;
    public int nutrition = 10;

    //Rotate Behavior
    public bool canRotate = true;
    public float RotateSpeed = 0.5f;//正为顺时针，负为逆时针

    public bool Chilly;

    public bool Icecream;




    private int ExpandCount;
    private  int DestroyCountDown;
    private void Start()
    {
        FoodInstantiator = GameObject.FindWithTag("FoodInstantiator");

        Scale = transform.localScale;
        gameObject.transform.localScale = 0 * Scale;
        ExpandCount = 0;

        DestroyCountDown = Random.Range(8000,16000);
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
            
        }else
        {
            if (ExpandCount > 0)
            {
                ExpandCount--;
                gameObject.transform.localScale = 0.01f * ExpandCount * Scale;
            }
            else
            {
                FoodInstantiator.GetComponent<FoodInstantiatorScript>().FoodNum--;
                Destroy(gameObject);
            }
        }
        
        //旋转
        if (canRotate)
        {
            gameObject.transform.Rotate(0, 0.5f, 0, Space.World);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(EatClip, gameObject.transform.position);
            FoodInstantiator.GetComponent<FoodInstantiatorScript>().FoodNum--;
            Destroy(gameObject);
        }
    }
}
