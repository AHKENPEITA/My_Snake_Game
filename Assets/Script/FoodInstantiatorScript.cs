using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInstantiatorScript : MonoBehaviour
{
    public GameObject ScenesManager;


    public int FoodNum;
    public int AmanitalNum;

    
    int FoodInstantiateTimeCounter;
    int BonusInstantiateTimeCounter;
    int InstantiateAmanitalTimeCounter;



    Vector3 InstantiatePosition;

   

    public GameObject FoodPack;
    public GameObject PropPack;

 




    public GameObject WhiteBonusPrefab;
    public GameObject BlackBonusPrefab;
    public GameObject CrownPrefab;
    public GameObject CoinPrefab;
 
    public GameObject FlowerS;
    public GameObject FlowerM;
    public GameObject FlowerL;
    public GameObject FlowerX;
    public GameObject Amanital;
 


    private void Start()
    {
        FoodInstantiateTimeCounter = 0;
        BonusInstantiateTimeCounter = 0;
        InstantiateAmanitalTimeCounter = 0;

        FoodNum = 0;
        AmanitalNum = 0;
    }
    private void FixedUpdate()
    {
        ///计数器
        
        InstantiatePosition = new Vector3(Random.Range(-15,16),0.5f,Random.Range(-15,16));
        FoodInstantiateTimeCounter+=ScenesManager.GetComponent<ScenesManagerScript>().FoodInstantiateRate;
        BonusInstantiateTimeCounter += ScenesManager.GetComponent<ScenesManagerScript>().FoodInstantiateRate;
        if (ScenesManager.GetComponent<ScenesManagerScript>().CanInstantiateAmanital)
        {
            if ((AmanitalNum < ScenesManager.GetComponent<ScenesManagerScript>().AmanitalLimit)|| (InstantiateAmanitalTimeCounter < 4000))
            {
                InstantiateAmanitalTimeCounter += ScenesManager.GetComponent<ScenesManagerScript>().FoodInstantiateRate;
            }
           
        }

        //生成食物

        if ((FoodInstantiateTimeCounter >=144) )
        {
            FoodInstantiateTimeCounter -= 144;
            if ((FoodNum < ScenesManager.GetComponent<ScenesManagerScript>().FoodNumLimit))
            { 
                FoodInstantiate(FoodPack);
                //Debug.Log("生成Food于" );
                FoodNum++;
            }
        }
        //生成奖励

        if (BonusInstantiateTimeCounter >= 3200 )
        {
            BonusInstantiate();
            BonusInstantiateTimeCounter = 0;
            //Debug.Log("生成Bonus于" + InstantiatePosition.x + " , " + InstantiatePosition.z);
        }

        //生成毒蘑菇
        if (InstantiateAmanitalTimeCounter >= 4800)
        {
            if (AmanitalNum<ScenesManager.GetComponent<ScenesManagerScript>().AmanitalLimit)
            {
                InstantiateAmanital();
                AmanitalNum++;
            }
          
            InstantiateAmanitalTimeCounter = 0;
        }
    }

   
    public void BonusInstantiate()
    {
        Vector3 InstantiatePosition = new Vector3(Random.Range(-15,16),0,Random.Range(-15,16));
        int i = Random.Range(0, 5);
        
        if (i<2)
        {
            GameObject.Instantiate(FlowerS, InstantiatePosition, FlowerS.transform.rotation);
        }else if (i < 3)
        {
            GameObject.Instantiate(FlowerM, InstantiatePosition, FlowerM.transform.rotation);
        }
        else if (i < 4)
        {
            GameObject.Instantiate(FlowerL, InstantiatePosition, FlowerL.transform.rotation);
        }
        else
        {
            GameObject.Instantiate(FlowerX, InstantiatePosition, FlowerX. transform.rotation);
        }

    }
    //生成道具
    public void PropInstantiate(string PropStyle)
    {
        int i = Random.Range(-15, 16);
        int j = Random.Range(-15, 16);
        Vector3 InstantiantePoint = new Vector3(i, 0.5f, j);

        switch (PropStyle)
        {
            case "Red": GameObject.Instantiate(PropPack.transform.Find("RedProp"), InstantiantePoint, PropPack.transform.Find("RedProp").transform.rotation); break;//分身樱桃：你超超超超超超超超超超长的蛇身是否给你带来许多麻烦？如果真是这样的话，你或许该求助于分身樱桃！只要你吃掉这颗（这两颗）樱桃，你就能像它们一样，“欻——”地分成两半，把你身后的累赘给全部抛光！
            case "Orange": GameObject.Instantiate(PropPack.transform.Find("OrangeProp"), InstantiantePoint, PropPack.transform.Find("OrangeProp").transform.rotation); break;//狂热柠檬：立刻开启一场狂热派对！！！狂热时间内场上的食物会爆发式地增长！
            case "Yellow": GameObject.Instantiate(PropPack.transform.Find("YellowProp"), InstantiantePoint, PropPack.transform.Find("YellowProp").transform.rotation); break;
            case "Green": GameObject.Instantiate(PropPack.transform.Find("GreenProp"), InstantiantePoint, PropPack.transform.Find("GreenProp").transform.rotation); break;
            case "Cyan": GameObject.Instantiate(PropPack.transform.Find("CyanProp"), InstantiantePoint, PropPack.transform.Find("CyanProp").transform.rotation); break;
            case "Blue": GameObject.Instantiate(PropPack.transform.Find("BlueProp"), InstantiantePoint, PropPack.transform.Find("BlueProp").transform.rotation); break;
            case "Purple": GameObject.Instantiate(PropPack.transform.Find("PurpleProp"), InstantiantePoint, PropPack.transform.Find("PurpleProp").transform.rotation); break;
            case "Default": GameObject.Instantiate(PropPack.transform.Find("DefaultProp"), InstantiantePoint, PropPack.transform.Find("DefaultProp").transform.rotation); break;
        }


    }



    public void FoodInstantiate(GameObject FoodPack)
    {
        int Index = Random.Range(0, FoodPack.transform.childCount);
        GameObject Food = FoodPack.transform.GetChild(Index).gameObject;
       GameObject newFood= GameObject.Instantiate(Food, new Vector3(Random.Range(-15, 16), Food.transform.position.y, Random.Range(-15, 16)), Food.transform.rotation);
        newFood.GetComponent<FoodScript>().FoodInstantiator = gameObject;
        
    }

    public void InstantiateAmanital()
    {
        GameObject.Instantiate(Amanital, new Vector3(Random.Range(-15, 16), Amanital.transform.position.y, Random.Range(-15, 16)), Amanital.transform.rotation);
    }

}
