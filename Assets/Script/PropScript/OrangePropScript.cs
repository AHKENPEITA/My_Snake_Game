using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangePropScript : MonoBehaviour
{
   public  GameObject CrazyTimeBuff;
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Instantiate(CrazyTimeBuff, new Vector3(0, 0, 0), new Quaternion(0,0,0,0));
            GameObject.Destroy(gameObject);
        }
    }
}
