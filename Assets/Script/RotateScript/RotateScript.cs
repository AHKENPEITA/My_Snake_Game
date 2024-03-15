
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    private void FixedUpdate()
    {
        gameObject.transform.Rotate(0,1,0);
    }
}
