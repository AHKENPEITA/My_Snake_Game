using UnityEngine;

public class DefaultPropScript : MonoBehaviour
{
    public GameObject FoodInstantiator;
    private void Start()
    {
        FoodInstantiator = GameObject.FindWithTag("FoodInstantiator");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FoodInstantiator.GetComponent<FoodInstantiatorScript>().BonusInstantiate();
            Debug.Log("生成奖励！");
            GameObject.Destroy(gameObject);
        }
    }
}
