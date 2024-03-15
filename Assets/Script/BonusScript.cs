using UnityEngine;

public class BonusScript : MonoBehaviour
{
    private int DestroyCountDown;

    private void Start()
    {
        if (gameObject.name == "Coin(Clone)")
        {
            DestroyCountDown = 2000;
            Debug.Log("生成金币");
        }else if (gameObject.name == "LargeFlower(Clone)")
        {
            DestroyCountDown = 1500;
            Debug.Log("生成大型花朵");
        }
    }

    private void FixedUpdate()
    {
        DestroyCountDown--;
        if(DestroyCountDown == 0)
        {
            Destroy(gameObject);
            Debug.Log("奖励销毁了");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if ((other.gameObject.tag == "Player"))
        {
            if (gameObject.name == "Coin(Clone)")
            {
                other.gameObject.GetComponent<PlayerScript>().score += 50;
            }
            else if (gameObject.name == "Large Flower(Clone)")
            {
                other.gameObject.GetComponent<PlayerScript>().score += 250;
            }
            Debug.Log("现在得分：" + other.gameObject.GetComponent<PlayerScript>().score);
            Destroy(gameObject);
            

        }
    }
}
