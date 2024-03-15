using UnityEngine;

public class CherriesPropScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<SnakeManagerScript>().MySnake.SnakeLength() < 5)
            {
            }
            else if (other.gameObject.GetComponent<SnakeManagerScript>().MySnake.SnakeLength() < 7)
            {
                other.gameObject.GetComponent<SnakeManagerScript>().CutSnakeBackward(1);
            }
            else if (other.gameObject.GetComponent<SnakeManagerScript>().MySnake.SnakeLength() < 9)
            {
                other.gameObject.GetComponent<SnakeManagerScript>().CutSnakeBackward(2);
            }
            else if (other.gameObject.GetComponent<SnakeManagerScript>().MySnake.SnakeLength() < 12)
            {
                other.gameObject.GetComponent<SnakeManagerScript>().CutSnakeBackward(3);
            }
            else if (other.gameObject.GetComponent<SnakeManagerScript>().MySnake.SnakeLength() < 15)
            {
                other.gameObject.GetComponent<SnakeManagerScript>().CutSnakeBackward(5);
            }
            else if (other.gameObject.GetComponent<SnakeManagerScript>().MySnake.SnakeLength() < 21)
            {
                other.gameObject.GetComponent<SnakeManagerScript>().CutSnakeBackward(6);
            }
            else if (other.gameObject.GetComponent<SnakeManagerScript>().MySnake.SnakeLength() < 24)
            {
                other.gameObject.GetComponent<SnakeManagerScript>().CutSnakeBackward(8);
            }
            else if (other.gameObject.GetComponent<SnakeManagerScript>().MySnake.SnakeLength() < 30)
            {
                other.gameObject.GetComponent<SnakeManagerScript>().CutSnakeBackward(12);
            }
            else if (other.gameObject.GetComponent<SnakeManagerScript>().MySnake.SnakeLength() < 36)
            {
                other.gameObject.GetComponent<SnakeManagerScript>().CutSnakeBackward(15);
            }
            else if (other.gameObject.GetComponent<SnakeManagerScript>().MySnake.SnakeLength() < 40)
            {
                other.gameObject.GetComponent<SnakeManagerScript>().CutSnakeBackward(18);
            }
            else
            {
                other.gameObject.GetComponent<SnakeManagerScript>().CutSnakeBackward(other.gameObject.GetComponent<SnakeManagerScript>().MySnake.SnakeLength() / 2);
            }

            Debug.Log("分身！");

            GameObject.Destroy(gameObject);
        }


    }
}
