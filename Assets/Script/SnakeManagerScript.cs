using UnityEngine;
using System.Collections;


public class SnakeManagerScript : MonoBehaviour
{
    public SnakeList MySnake;

    int StyleIndex;
    
    public class SnakeNode//定义了一个以GameObject为值的抽象Snake节点类
    {
        public GameObject SnakePart;
        public SnakeNode Next;
        public SnakeNode Prev;
        public SnakeNode(GameObject SnakePart)//构造一个蛇节点
        {
            this.SnakePart = SnakePart;
        }
    }
    public class SnakeList//用Snake节点做一个链表
    {
        public SnakeNode SnakeHead;//链表需要一个表头


        public SnakeList(SnakeNode Head)//构造一个蛇链表
        {
            this.SnakeHead = Head;
        }

        public int SnakeLength()//返回蛇身长度（包括蛇头）
        {
            int Length;
            SnakeNode i = SnakeHead;//遍历指针
            for (Length = 0; i.Next != null; Length++)
            {
                i = i.Next;
            }
            return Length;
        }

        public SnakeNode getLast()//返还最后一截蛇身
        {
            SnakeNode i = this.SnakeHead;
            while (i.Next != null)
            {
                i = i.Next;
            }
            return i;
        }

        public void AddSnakeNode(SnakeNode Add)//为链表末尾增添一截蛇身
        {
            Add.Prev = this.getLast();
            this.getLast().Next = Add;
           


        }
    }

    private void Start()
    {
        SnakeNode SnakeHead = new SnakeNode(gameObject);
        MySnake = new SnakeList(SnakeHead);
        StyleIndex = 0;
        
    }
    //生长的方法
    public void Growth()
    {
        Vector3 OrigialPosition = MySnake.getLast().SnakePart.transform.position;//上一节蛇身的位置
        Vector3 setPosition = new Vector3(0, 0.5f, 0); //新生成的蛇身位置，默认将新的蛇身加在（0，50，0）的位置
       // Vector2 OriginalAbstractPosition = MySnake.getLast().SnakePart.GetComponent<SnakePartScript>().AbstractPosition;
       // Vector2 setAbstractPosition = new Vector2(0, 0);

        //如果末尾的蛇身正在往东南西北任意方向走，则新加的蛇身会出现在他们目前位置沿前进方向往后一个单位的位置
        if (MySnake.getLast().SnakePart.GetComponent<SnakePartScript>().CurrentEast )
        {
            setPosition = OrigialPosition - new Vector3(1, 0, 0);
            //setAbstractPosition = OriginalAbstractPosition - new Vector2(100, 0);
            
        }

        if (MySnake.getLast().SnakePart.GetComponent<SnakePartScript>().CurrentWest )
        {
            setPosition = OrigialPosition - new Vector3(-1, 0, 0);
           // setAbstractPosition = OriginalAbstractPosition - new Vector2(-100, 0);
        }

        if (MySnake.getLast().SnakePart.GetComponent<SnakePartScript>().CurrentNorth )
        {
            setPosition = OrigialPosition - new Vector3(0, 0, 1);
            //setAbstractPosition = OriginalAbstractPosition - new Vector2(0, 100);
        }

        if (MySnake.getLast().SnakePart.GetComponent<SnakePartScript>().CurrentSouth )
        {
            setPosition = OrigialPosition - new Vector3(0, 0, -1);
            //setAbstractPosition = OriginalAbstractPosition - new Vector2(0, -100);
        }

        //bool setTranslateBegain = MySnake.getLast().SnakePart.GetComponent<SnakePartScript>().TranslateBegain;
        bool setatIntPosition = MySnake.getLast().SnakePart.GetComponent<SnakePartScript>().atIntPosition;

        //int setTranslateStage = MySnake.getLast().SnakePart.GetComponent<SnakePartScript>().TranslateStage;

        bool SetEast = MySnake.getLast().SnakePart.GetComponent<SnakePartScript>().CurrentEast;
        bool SetWest = MySnake.getLast().SnakePart.GetComponent<SnakePartScript>().CurrentWest;
        bool SetNorth = MySnake.getLast().SnakePart.GetComponent<SnakePartScript>().CurrentNorth;
        bool SetSouth = MySnake.getLast().SnakePart.GetComponent<SnakePartScript>().CurrentSouth;

        bool CurrentEast = MySnake.getLast().SnakePart.GetComponent<SnakePartScript>().CurrentEast;
        bool CurrentWest = MySnake.getLast().SnakePart.GetComponent<SnakePartScript>().CurrentWest;
        bool CurrentNorth = MySnake.getLast().SnakePart.GetComponent<SnakePartScript>().CurrentNorth;
        bool CurrentSouth = MySnake.getLast().SnakePart.GetComponent<SnakePartScript>().CurrentSouth;

        //连续反转接下来生成的蛇身的造型
        //GameObject justAdd=SnakePartProverbStyle1;
        
        //switch (MySnake.getLast().SnakePart.name)
        //{
        //    case "SnakePartStyle1(Clone)":justAdd =SnakePartProverbStyle2; break;
        //    case "SnakePartStyle2(Clone)":justAdd = SnakePartProverbStyle1;break;
        //}

        
        //如果启用变色蛇身则
        
        if (gameObject.GetComponent<PlayerScript>().StylePack.transform.childCount > 1)
        {
            if (StyleIndex+1< gameObject.GetComponent<PlayerScript>().StylePack.transform.childCount)
            {
                StyleIndex++;
            }
            else
            {
                StyleIndex = 0;
            }
        }
        GameObject JustAdd = gameObject.GetComponent<PlayerScript>().StylePack.transform.GetChild(StyleIndex).gameObject;







        //生成新的蛇身把它粘在最后一截蛇身后面，并赋予它初速度的大小、方向
        
        GameObject newSnakePart = GameObject.Instantiate(JustAdd, setPosition, transform.rotation);
        
        


        //newSnakePart.GetComponent<SnakePartScript>().TranslateBegain = setTranslateBegain;

       // newSnakePart.GetComponent<SnakePartScript>().TranslateStage = setTranslateStage;

        newSnakePart.GetComponent<SnakePartScript>().SetEast = SetEast;
        newSnakePart.GetComponent<SnakePartScript>().SetWest = SetWest;
        newSnakePart.GetComponent<SnakePartScript>().SetNorth = SetNorth;
        newSnakePart.GetComponent<SnakePartScript>().SetSouth = SetSouth;

        newSnakePart.GetComponent<SnakePartScript>().CurrentEast = CurrentEast;
        newSnakePart.GetComponent<SnakePartScript>().CurrentWest = CurrentWest;
        newSnakePart.GetComponent<SnakePartScript>().CurrentNorth = CurrentNorth;
        newSnakePart.GetComponent<SnakePartScript>().CurrentSouth = CurrentSouth;

        newSnakePart.GetComponent<SnakePartScript>().prev = MySnake.getLast().SnakePart;
        
           
        MySnake.getLast().SnakePart.GetComponent<SnakePartScript>().next = newSnakePart;
        MySnake.AddSnakeNode(new SnakeNode(newSnakePart));
        

        //完成
    }

    //删除蛇身的方法
    public void CutSnakeForward(int CutNodeNum)
    {
        int Length = MySnake.SnakeLength();
        int Current=0;//指针位置
        SnakeNode CurrentNode = MySnake.SnakeHead;
        for (int i = 0; i < CutNodeNum; i++)
        {
            if (CurrentNode.Next != null)
            {
                CurrentNode = CurrentNode.Next;
                Current++;
            }
        }
        if (Current == CutNodeNum)
        {
            CurrentNode.SnakePart.GetComponent<SnakePartScript>().prev.GetComponent<SnakePartScript>().next = null;
            CurrentNode.SnakePart.GetComponent<SnakePartScript>().prev = null;
            CurrentNode.Prev.Next = null;
           
            CurrentNode.Prev = null;
            CurrentNode.SnakePart.GetComponent<SnakePartScript>().Cutted = true;
            CurrentNode.SnakePart.GetComponent<SnakePartScript>().SpeedUp = false;
            CurrentNode.SnakePart.GetComponent<SnakePartScript>().SlowDown = true;
        }
       
    }

    public void CutSnakeBackward(int CutNodeNum)
    {
        int Length = MySnake.SnakeLength();
        int Current = Length;
        SnakeNode CurrentNode = MySnake.getLast();
        for (int i=0; i<CutNodeNum; i++)
        {
            if (CurrentNode.Prev != null)
            {
                CurrentNode = CurrentNode.Prev;
                Current--;
            }
        }
        if ((Current == Length - CutNodeNum))
        {
            CurrentNode.SnakePart.GetComponent<SnakePartScript>().next.GetComponent<SnakePartScript>().prev = null;
            CurrentNode.SnakePart.GetComponent<SnakePartScript>().next = null;
            CurrentNode.Next.Prev = null;
            CurrentNode.Next.SnakePart.GetComponent<SnakePartScript>().Cutted = true;
            CurrentNode.Next.SnakePart.GetComponent<SnakePartScript>().SpeedUp = false;
            CurrentNode.Next.SnakePart.GetComponent<SnakePartScript>().SlowDown = true;
            CurrentNode.Next = null;
            
        }
    }

}
