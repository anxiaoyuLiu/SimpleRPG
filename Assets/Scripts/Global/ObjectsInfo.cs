using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    Drug,//药品
    Equip,//装备
    Mat//材料
}

public enum DressType
{
    Headgear,//帽子
    Armor,//护甲
    RightHand,//右手武器
    LeftHand,//左手武器
    Shoes,//靴子
    Accessory//饰品
}

public enum AplicationType
{
    Swordman,//剑士
    Magician,//魔法师
    Common//通用
}

public class ObjectInfo
{
    public int id;
    public string name;
    public string icon_name;//该物品对应的图集中的name
    public ObjectType objectType;
    public int hp;
    public int mp;
    public int price_sell;
    public int price_buy;
    public int attack;
    public int defence;
    public int Speed;
    public DressType dressType;
    public AplicationType aplicationType;
}

public class ObjectsInfo : MonoBehaviour
{

    public static ObjectsInfo info;
    public TextAsset ObjectsInfoText;

    private ObjectInfo obj;
    private Dictionary<int, ObjectInfo> objectDictionary = new Dictionary<int, ObjectInfo>();//将所有的Object以键值对的形式存储到字典中

    private void Awake()
    {
        info = this;
        GetObject();
        //Debug.Log(objectDictionary.Keys.Count);
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P))//测试
        //{
        //    Debug.Log(FindObjectInDictionary(205).name);
        //}
    }

    public ObjectInfo FindObjectInDictionary(int id)
    {
        ObjectInfo obj = null;
        objectDictionary.TryGetValue(id, out obj);
        return obj;
    }

    public void GetObject()
    {
        string text = ObjectsInfoText.text;
        string[] objectArray = text.Split('\n');//将Text文本中的信息按行分割，存储到字符串数组中

        //ObjectInfo objectInfo = new ObjectInfo();//问题出在这里！！！！
        //问题原因：C#语言的复制机制为浅复制，objectInfo在循环外实例的话，每次赋值都是同一个引用
        //                  所以键相同，值就会被覆盖的
        //解决：将实例放在循环中，每一次赋值，objectInfo都是不同的引用，key不同，所以value不会被覆盖掉

        foreach (string array in objectArray)
        {

            ObjectInfo objectInfo = new ObjectInfo();
            string[] information = array.Split(',');//将每一行信息按‘，’分割，存储到数组中
            //Debug.Log(information[0]);
            string _type = information[3];
            ObjectType type = ObjectType.Drug;
            switch (_type)
            {
                case "Drug":
                    type = ObjectType.Drug;
                    break;
                case "Equip":
                    type = ObjectType.Equip;
                    break;
                case "Mat":
                    type = ObjectType.Mat;
                    break;
            }
            objectInfo.objectType = type;
            if (objectInfo.objectType == ObjectType.Drug)
            {
                int _id = int.Parse(information[0]);
                string _name = information[1];
                string _icon_name = information[2];
                int _hp = int.Parse(information[4]);
                int _mp = int.Parse(information[5]);
                int _sell = int.Parse(information[6]);
                int _buy = int.Parse(information[7]);
                objectInfo.id = _id;
                objectInfo.name = _name;
                objectInfo.icon_name = _icon_name;
                objectInfo.hp = _hp;
                objectInfo.mp = _mp;
                objectInfo.price_sell = _sell;
                objectInfo.price_buy = _buy;
            }

            if (objectInfo.objectType == ObjectType.Equip)
            {
                objectInfo.id = int.Parse(information[0]);
                objectInfo.name = information[1];
                objectInfo.icon_name = information[2];
                objectInfo.attack = int.Parse(information[4]);
                objectInfo.defence = int.Parse(information[5]);
                objectInfo.Speed = int.Parse(information[6]);
                objectInfo.price_sell = int.Parse(information[9]);
                objectInfo.price_buy = int.Parse(information[10]);
                switch (information[7])
                {
                    case "Headgear":
                        objectInfo.dressType = DressType.Headgear;
                        break;
                    case "Armor":
                        objectInfo.dressType = DressType.Armor;
                        break;
                    case "LeftHand":
                        objectInfo.dressType = DressType.LeftHand;
                        break;
                    case "RightHand":
                        objectInfo.dressType = DressType.RightHand;
                        break;
                    case "Shoes":
                        objectInfo.dressType = DressType.Shoes;
                        break;
                    case "Accessory":
                        objectInfo.dressType = DressType.Accessory;
                        break;
                }

                switch (information[8])
                {
                    case "Swordman":
                        objectInfo.aplicationType = AplicationType.Swordman;
                        break;
                    case "Magician":
                        objectInfo.aplicationType = AplicationType.Magician;
                        break;
                    case "Common":
                        objectInfo.aplicationType = AplicationType.Common;
                        break;
                }
            }

            if (objectInfo.objectType == ObjectType.Mat)
            {

            }
            objectDictionary.Add(objectInfo.id, objectInfo);
        }
    }

}

