using UnityEngine;

public class CrazyTimeBuffScript : MonoBehaviour
{
    public GameObject ScenesManager;
    public int CountDown=4000;
    private void Start()
    {
        ScenesManager = GameObject.FindWithTag("ScenesManager"); 
        
        ScenesManager.GetComponent<ScenesManagerScript>().FoodInstantiateRate += 3;
        ScenesManager.GetComponent<ScenesManagerScript>().FoodNumLimit += 30;
        Debug.Log("狂热！！！");
    }
    private void FixedUpdate()
    {
        if (CountDown > 0)
        {
            CountDown--;
        }
        else
        {
            Debug.Log("狂热结束");
            ScenesManager.GetComponent<ScenesManagerScript>().FoodInstantiateRate -= 3;
            ScenesManager.GetComponent<ScenesManagerScript>().FoodNumLimit -= 30;
           // ScenesManager.GetComponent<ScenesManagerScript>().OrangePropExist = false;
            GameObject.Destroy(gameObject);
           
        }
    }
}
