
using UnityEngine;

public class CameralScript : MonoBehaviour
{
    Vector3 CameralOffset;
    public Transform PlayerTransform;
   
    void Start()
    {
        PlayerTransform = GameObject.Find("Player").transform;
        CameralOffset = transform.position-PlayerTransform.position;
    }

    void FixedUpdate()
    {
        transform.position = PlayerTransform.position + CameralOffset;
    }
}
