
using UnityEngine;


public class ScenesManagerScript : MonoBehaviour
{





    ////道具已存在
    //public bool RedPropExist;
    //public bool OrangePropExist;
    //public bool YellowPropExist;
    //public bool GreenPropExist;
    //public bool CyanPropExist;
    //public bool BluePropExist;
    //public bool PurplePropExist;
    //public bool DefaultPropExist;
    ////道具效果开关
    //public bool RedPropAffect;
    //public bool OrangePropAffect;
    //public bool YellowPropAffect;
    //public bool GreenPropAffect;
    //public bool CyanPropAffect;
    //public bool BluePropAffect;
    //public bool PurplePropAffect;
    //public bool DefaultPropAffect;
    ////道具效果倒计时
    //public int RedPropCountDown;
    //public int OrangePropCountDown;
    //public int YellowPropCountDown;
    //public int GreenPropCountDown;
    //public int CyanPropCountDown;
    //public int BluePropCountDown;
    //public int PurplePropCountDown;
    //public int DefaultPropCountDown;
    //全局细节
    public float fps;
    public int FoodNumLimit;//全局食物上限
    public int FoodInstantiateRate;//全局食物生成速率
    public bool CanSpeedUp;//蛇可以按前进方向键加速
    public bool CanSlowDown;//蛇是否可以按后退方向键减速
    
    public bool CanInstantiateAmanital;//是否会生成毒蘑菇
    public int AmanitalLimit;//全局毒蘑菇上限

    //public float SpeedEveryPase;//每一步的步长
    //public int SpeedEveryPaseAbstract;//每一抽象步的步长（必须能被100整除）

    private void Start()
    {
        fps = Time.fixedDeltaTime;
        //RedPropExist=false;
        //OrangePropExist=false;
        //YellowPropExist=false;
        //GreenPropExist=false;
        //CyanPropExist=false;
        //BluePropExist=false;
        //PurplePropExist=false;
        //DefaultPropExist=false;

        //RedPropAffect =false;
        //OrangePropAffect=false;
        //YellowPropAffect=false;
        //GreenPropAffect=false;
        //CyanPropAffect=false;
        //BluePropAffect=false;
        //PurplePropAffect=false;
        //DefaultPropAffect=false;

        //RedPropCountDown=0;
        //OrangePropCountDown=0;
        //YellowPropCountDown=0;
        //GreenPropCountDown=0;
        //CyanPropCountDown=0;
        //BluePropCountDown=0;
        //PurplePropCountDown=0;
        //DefaultPropCountDown=0;

        
        FoodNumLimit = 5;
        FoodInstantiateRate = 1;
        CanSpeedUp = true;
        CanSlowDown = true;
        
        CanInstantiateAmanital = true;
        AmanitalLimit = 5;

        //SpeedEveryPaseAbstract = 5;
        //SpeedEveryPase = (float)SpeedEveryPaseAbstract / 100;

       

    }

    

}
