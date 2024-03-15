
using UnityEngine;

public class SnakePartScript: MonoBehaviour
{

    public GameObject prev;
    public GameObject next;
    public GameObject ScenesManager;

   
    public float Speed ;
    
    public bool atIntPosition;
    public  Vector3 Destination = Vector3.zero;
    public Vector3 MoveVector;

    //膨胀计数器
    public int ExpandCount;
    //是否开始位移
    public bool TranslateBegain;
    //位移的动画步骤
    public int TranslateStage;
    //位移的速度
    public bool SpeedUp;
    public bool SlowDown;
    //下一次改变位移方向时是否选择这四个方向中的一个
    public bool SetEast;
    public bool SetWest;
    public bool SetNorth;
    public bool SetSouth;
    //是否正在往这四个方向位移
    public bool CurrentEast;
    public bool CurrentWest;
    public bool CurrentNorth;
    public bool CurrentSouth;
    //是否凌空
    public bool Dropping;
    //是否爬坡
    public bool Climbing;


    public bool Cutted;//已经被切断

    
    public Vector2 AbstractPosition;

    Vector3 Scale;

    public bool isInt(float i)
    {
        return Mathf.Ceil(i) == Mathf.Floor(i);
    }//判断一个数是整数的方法//如果是整数，返回 是

    private void Start()
    {
        if (this.prev == null)
        {
            Destination = transform.position;

            ExpandCount = 100;
            TranslateBegain = false;//开始时静止
            TranslateStage = 0;

            SetEast = false;
            SetWest = false;
            SetNorth = false;
            SetSouth = false;


            CurrentWest = false;
            CurrentEast = false;
            CurrentNorth = false;
            CurrentSouth = false;

            Cutted = false;
            
        }
        else
        {
            Destination = prev.GetComponent<SnakePartScript>().Destination;
            ExpandCount = 0;
            Scale = gameObject.transform.localScale;
            gameObject.transform.localScale = 0 * Scale;
        }
        ScenesManager = GameObject.FindWithTag("ScenesManager");

        
    }

    private void FixedUpdate()
    {
        atIntPosition = isInt(transform.position.x) && isInt(transform.position.z);


        //蛇身生长动画
        if (prev != null)//如果是蛇身
        {
            if (ExpandCount < 100)
            {
                ExpandCount++;
                gameObject.transform.localScale = 0.01f * ExpandCount * Scale;
            }
            //if (atIntPosition)
            //{
            //    Destination=prev.GetComponent<SnakePartScript>().Destination;
            //}
        }
        


        //蛇头以外，速度通过上一节节点控制
        if (prev != null)//如果是蛇身
        {
            Speed = prev.gameObject.GetComponent<SnakePartScript>().Speed;
            
        }
        else//如果是蛇头
        {
            Speed= gameObject.GetComponent<PlayerScript>().speed.FinalValue;
        }


        //蛇头以外，蛇节点的转向通过上一节节点控制
        if ((prev != null) &&(!atIntPosition))
        {
            SetEast = prev.GetComponent<SnakePartScript>().CurrentEast;
            SetWest = prev.GetComponent<SnakePartScript>().CurrentWest;
            SetNorth = prev.GetComponent<SnakePartScript>().CurrentNorth;
            SetSouth = prev.GetComponent<SnakePartScript>().CurrentSouth;
        }

        
        


        //在整数位置上，更新目的地位置（Destination）, 更新朝向信息（四个Current） 
        if(atIntPosition)
        {
            if (SetEast)
            {
                Destination =new Vector3(transform.position.x+1 , transform.position.y, transform.position.z);
                CurrentEast = true;
                CurrentWest = false;
                CurrentNorth = false;
                CurrentSouth = false;
            }
            if (SetWest)
            {
                Destination = new Vector3(transform.position.x -1 , transform.position.y, transform.position.z);
                CurrentEast = false;
                CurrentWest = true;
                CurrentNorth = false;
                CurrentSouth = false;
            }
            if (SetNorth)
            {
                Destination = new Vector3(transform.position.x, transform.position.y, transform.position.z+1);
                CurrentEast = false;
                CurrentWest = false;
                CurrentNorth = true;
                CurrentSouth = false;
            }
            if (SetSouth)
            {
                Destination = new Vector3(transform.position.x, transform.position.y, transform.position.z-1);
                CurrentEast = false;
                CurrentWest = false;
                CurrentNorth = false;
                CurrentSouth = true;
            }


        }

        //运行位移

        MoveVector = Vector3.MoveTowards(transform.position, Destination, Speed);
        transform.position = MoveVector;

        //离场后销毁自身
        //if ((transform.position.x>16) || (transform.position.x < -16) || (transform.position.z > 16) || (transform.position.z < -16))
        //{
        //    GameObject.Destroy(gameObject);
        //}

        //下落爬坡方法
        //if (Dropping)
        //{
        //    transform.Translate(new Vector3(0, -ScenesManager.GetComponent<ScenesManagerScript>().SpeedEveryPase, 0));
        //}

        //if (Climbing)
        //{
        //    transform.Translate(new Vector3(0, ScenesManager.GetComponent<ScenesManagerScript>().SpeedEveryPase, 0));
        //}





    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boundary")
        {
            // GameObject.Destroy(gameObject);
        }

        //进入地面时爬坡
        //if (other.gameObject.tag == "Ground")
        //{
        //    Dropping = false;
        //    Debug.Log("No Drop");
        //    if (transform.position.y - other.transform.position.y < 1)
        //    {
        //        Climbing =true;
        //        Debug.Log("Climb Begain");
        //    }
        //    else
        //    {
        //        Climbing = false;
        //    }

        //}

    }
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag == "Ground")
    //    {
    //        if (transform.position.y - other.transform.position.y == 1)
    //        {
    //            Climbing = false;
    //            Dropping = false;
    //            Debug.Log(" No Drop   No  Climb");
    //        }
    //    }

    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Ground")
    //    {
    //        Dropping = true;
    //        Climbing = false;
    //        Debug.Log("Drop Begain");
    //    }
    //}


}
