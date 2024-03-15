using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public GameObject ScenesManager;
    public GameObject FoodInstantiator;
    public GameObject next;
    public GameObject StylePack;
    public Vector3 CurrentDirection;

    //public float SpeedFactorBase = 0.024f;
    //public float SpeedFactorControl = 1;
    //public float SpeedFactorTemperature = 1;
    //public float SpeedValue;

    public Speed speed; //速度方法

    
    
    public int score;//玩家分数
    
    public float growthCount;//成长点数

    //public int ChilyBuffOn;//目前有几颗辣椒有效

    public bool UpsideDown;//是否控制方向颠倒

    public int UpsideDownCount;//控制方向颠倒计时

    //

    

    void Start()
    {
        //Debug.Log("游戏开始了");
        score = 0;//开始分数设定为0
        growthCount = 0;

        speed = new Speed(0.024f);


        UpsideDown = false;
        UpsideDownCount = 0;

        

        
    }


    void FixedUpdate()
    {
        if (ScenesManager.GetComponent<ScenesManagerScript>().CanSpeedUp)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                speed.SpeedUp();
            }
            else if (ScenesManager.GetComponent<ScenesManagerScript>().CanSlowDown)
            {

                if (Input.GetKey(KeyCode.Mouse1))
                {
                    speed.SlowDown();
                }
                else
                {
                    speed.SpeedReturn();
                }
             }
        }

        
        

        if (Input.GetKeyDown(KeyCode.T))
        {
            //StartCoroutine(speed.doChilyBuffEffect());
        }


        speed.UpdateFinalSpeed();


        //按下WASD四个键后分别设置定向位移方向；及控制方向颠倒的处理
        if (UpsideDown == false)
        {
            if ((Input.GetKey(KeyCode.D) == true))
            {
                //转向
                if (gameObject.GetComponent<SnakePartScript>().CurrentWest == false)
                {
                    gameObject.GetComponent<SnakePartScript>().SetEast = true;
                    gameObject.GetComponent<SnakePartScript>().SetWest = false;
                    gameObject.GetComponent<SnakePartScript>().SetNorth = false;
                    gameObject.GetComponent<SnakePartScript>().SetSouth = false;
                }

            }

            if ((Input.GetKey(KeyCode.A) == true))
            {
                if (gameObject.GetComponent<SnakePartScript>().CurrentEast == false)
                {
                    gameObject.GetComponent<SnakePartScript>().SetEast = false;
                    gameObject.GetComponent<SnakePartScript>().SetWest = true;
                    gameObject.GetComponent<SnakePartScript>().SetNorth = false;
                    gameObject.GetComponent<SnakePartScript>().SetSouth = false;
                }



            }

            if ((Input.GetKey(KeyCode.W) == true))
            {
                if (gameObject.GetComponent<SnakePartScript>().CurrentSouth == false)
                {
                    gameObject.GetComponent<SnakePartScript>().SetEast = false;
                    gameObject.GetComponent<SnakePartScript>().SetWest = false;
                    gameObject.GetComponent<SnakePartScript>().SetNorth = true;
                    gameObject.GetComponent<SnakePartScript>().SetSouth = false;
                }


            }

            if ((Input.GetKey(KeyCode.S) == true))
            {
                if (gameObject.GetComponent<SnakePartScript>().CurrentNorth == false)
                {
                    gameObject.GetComponent<SnakePartScript>().SetEast = false;
                    gameObject.GetComponent<SnakePartScript>().SetWest = false;
                    gameObject.GetComponent<SnakePartScript>().SetNorth = false;
                    gameObject.GetComponent<SnakePartScript>().SetSouth = true;
                }


            }
        }
        else
        {
            if ((Input.GetKey(KeyCode.A) == true))
            {
                //转向
                if (gameObject.GetComponent<SnakePartScript>().CurrentWest == false)
                {
                    gameObject.GetComponent<SnakePartScript>().SetEast = true;
                    gameObject.GetComponent<SnakePartScript>().SetWest = false;
                    gameObject.GetComponent<SnakePartScript>().SetNorth = false;
                    gameObject.GetComponent<SnakePartScript>().SetSouth = false;
                }

            }

            if ((Input.GetKey(KeyCode.D) == true))
            {
                if (gameObject.GetComponent<SnakePartScript>().CurrentEast == false)
                {
                    gameObject.GetComponent<SnakePartScript>().SetEast = false;
                    gameObject.GetComponent<SnakePartScript>().SetWest = true;
                    gameObject.GetComponent<SnakePartScript>().SetNorth = false;
                    gameObject.GetComponent<SnakePartScript>().SetSouth = false;
                }



            }

            if ((Input.GetKey(KeyCode.S) == true))
            {
                if (gameObject.GetComponent<SnakePartScript>().CurrentSouth == false)
                {
                    gameObject.GetComponent<SnakePartScript>().SetEast = false;
                    gameObject.GetComponent<SnakePartScript>().SetWest = false;
                    gameObject.GetComponent<SnakePartScript>().SetNorth = true;
                    gameObject.GetComponent<SnakePartScript>().SetSouth = false;
                }


            }

            if ((Input.GetKey(KeyCode.W) == true))
            {
                if (gameObject.GetComponent<SnakePartScript>().CurrentNorth == false)
                {
                    gameObject.GetComponent<SnakePartScript>().SetEast = false;
                    gameObject.GetComponent<SnakePartScript>().SetWest = false;
                    gameObject.GetComponent<SnakePartScript>().SetNorth = false;
                    gameObject.GetComponent<SnakePartScript>().SetSouth = true;
                }


            }
        }
         
        if (UpsideDown)
        {
            if (UpsideDownCount > 0)
            {
                UpsideDownCount--;
            }
            else
            {
                UpsideDown = false;
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                UpsideDownCount -= 400;
            }
        }//吃到蘑菇以后控制方向颠倒倒计时
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Boundary")
        {
           // GameObject.Destroy(gameObject);
        }
        //撞墙撞蛇死亡判定
        if (other.gameObject.tag == "Wall")
        {
            // Debug.Log("撞墙了");
        }
        if (other.gameObject.tag == "Snake")
        {
            // Debug.Log("撞蛇了");
        }
        //吃食物加分判定
        if (other.GetComponent<FoodScript>()!=null)
        {
            score += (other.GetComponent<FoodScript>().nutrition);
            growthCount += other.GetComponent<FoodScript>().nutrition;
            for (; growthCount >= 10;growthCount-=10)
            {
                gameObject.GetComponent<SnakeManagerScript>().Growth();
            }

            if (other.GetComponent<FoodScript>().Chilly)
            {
               // StartCoroutine(speed.doChilyBuff());
            }

            if (other.GetComponent<FoodScript>().Icecream)
            {
                //StartCoroutine(speed.doIcecreamBuff());
            }

        }

        
    }

    public class Speed
    {

        public float BaseFactor;
        public float ControlFactor;
        public float TemperatureFactor;
        public float BuffFactor;
        public float FinalValue;

        private int onChilyBuffCountDown;

        public Speed(float basefactor)
        {
            BaseFactor = basefactor;
            ControlFactor = 1f;
            TemperatureFactor = 1f;
            BuffFactor = 1f;
            FinalValue = BaseFactor * ControlFactor * TemperatureFactor * BuffFactor;

            onChilyBuffCountDown = 0;
         }

        public  void UpdateFinalSpeed()
        {
            FinalValue = BaseFactor * ControlFactor * TemperatureFactor * BuffFactor;
        }

        //public void PlayerControl(bool doAccelerate,bool doModerate)
        //{
        //    if (doAccelerate)
        //    {
        //        this.ControlFactor = 2;
        //    }
        //    else if(doModerate)
        //    {
        //        this.ControlFactor = 0.5f;
        //    }
        //    else
        //    {
        //        this.ControlFactor = 1;
        //    }
        //}//简单的模块化加速、减速方法，只用传入两个布尔值，分别代表开启加速和开启减速

        public void SpeedUp()
        {
            this.ControlFactor = 2f;
        }//玩家控制加速

        public void SlowDown()
        {
            this.ControlFactor = 0.5f;
        }//玩家控制减速

        public void SpeedReturn()
        {
            this.ControlFactor = 1f;
        }//控制速度恢复
        
        public void HotUp()
        {
            this.TemperatureFactor += 0.02f;
        }//由炎热环境导致的加速，每次更新将因子加0.02
        public void HotUp(float HotFactor)
        {
            this.TemperatureFactor += HotFactor;
        }//重载变热函数，因子增量自定义
        public void ColdDown()
        {
            if (this.TemperatureFactor - 0.02f>=0)
            this.TemperatureFactor -= 0.02f;
        }//由于寒冷环境导致的降速，每次更新将因子减0.02，但不低于0
        public void ColdDown(float ColdFactor)
        {
            if (this.TemperatureFactor - ColdFactor >= 0)
                this.TemperatureFactor -= ColdFactor;
        }//重载变凉函数，因子减量自定义
        public void TemperatureResetInstantly()
        {
            this.TemperatureFactor = 1;
        }//立即将环境因素导致的因子改变效果去除，初始化为一
        public void TemperatureResetGradually()
        {
             float Delta(float a, float b)
            {
                if (a > b)
                {
                    return a - b;
                }
                else
                {
                    return b - a;
                }

            }//计算两个数差值的函数，返回他们差值的绝对值
            if (Delta(TemperatureFactor,1)<0.02)
            {
                TemperatureFactor = 1;
            }
            else
            {
                if (TemperatureFactor > 1)
                {
                    TemperatureFactor -= 0.02f;
                }
                else
                {
                    TemperatureFactor += 0.02f;
                }
            }
        }//缓慢地将环境因素导致的因子效果变回原位

        //public IEnumerator doChilyBuff()
        //{
            
        //    onChilyBuffCountDown++;
        //    //Debug.Log("onChilyBuffCountDown=" + onChilyBuffCountDown);
        //    while (BuffFactor < 3)
        //    {
        //        BuffFactor = FloatRoud2(BuffFactor+0.02f);
        //       // Debug.Log( BuffFactor);
        //        yield return new WaitForSeconds(0.02f);
        //     }

        //    yield return new WaitForSeconds(5);
        //    onChilyBuffCountDown--;
        //    //Debug.Log("onChilyBuffCountDown=" + onChilyBuffCountDown);
        //    while (BuffFactor >1)
        //    {
        //        if (onChilyBuffCountDown > 0)
        //        {
        //            //Debug.Log("onChilyBuffCountDown="+onChilyBuffCountDown);
        //            break;
        //        }
        //        else 
        //        {
        //            BuffFactor = FloatRoud2(BuffFactor - 0.02f);
        //            //Debug.Log(BuffFactor);
        //            yield return new WaitForSeconds(0.3f);
        //        }
                
        //    }
        //    //Debug.Log("辣椒生命周期结束");
        //}//辣椒Buff

        //public IEnumerator doIcecreamBuff()
        //{

        //    onChilyBuffCountDown++;
        //    //Debug.Log("onChilyBuffCountDown=" + onChilyBuffCountDown);
        //    while (BuffFactor >0.4)
        //    {
        //        BuffFactor = FloatRoud2(BuffFactor - 0.02f);
        //        // Debug.Log( BuffFactor);
        //        yield return new WaitForSeconds(0.02f);
        //    }

        //    yield return new WaitForSeconds(5);
        //    onChilyBuffCountDown--;
        //    //Debug.Log("onChilyBuffCountDown=" + onChilyBuffCountDown);
        //    while (BuffFactor < 1)
        //    {
        //        if (onChilyBuffCountDown > 0)
        //        {
        //            //Debug.Log("onChilyBuffCountDown="+onChilyBuffCountDown);
        //            break;
        //        }
        //        else
        //        {
        //            BuffFactor = FloatRoud2(BuffFactor + 0.02f);
        //            //Debug.Log(BuffFactor);
        //            yield return new WaitForSeconds(0.3f);
        //        }

        //    }
        //    //Debug.Log("冰淇凌生命周期结束");
        //}//冰淇凌Buff

        public void BuffManager()
        {

        }

    }

    public static float FloatRoud2 (float f)//将 float 四舍五入到最近的两位小数
    {
        int i = Mathf.RoundToInt(f*100);
        return (float)i / 100f;
    }

    
 }


