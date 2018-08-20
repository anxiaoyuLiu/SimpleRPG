using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour {

    public static Equipment equipment;
    public GameObject Headgear;
    public GameObject Armor;
    public GameObject RightHand;
    public GameObject LeftHand;
    public GameObject Shoes;
    public GameObject Accessory;
    public GameObject[] GoodsPrefabs;
    public string TakeOffName;

    private ObjectsInfo objects;
    private PlayerInformation player;
    private Inventory inventory;
    private MyDrag myDrag;

    private void Awake()
    {
        equipment = this;
        objects = GameObject.Find("GameSetting").GetComponent<ObjectsInfo>();
        player = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerInformation>();
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        myDrag = this.transform.GetComponentInChildren<MyDrag>();
    }

    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerInformation>();
    }

    public bool Dress(int id)
    {
        ObjectInfo info = objects.FindObjectInDictionary(id);
        if (info.objectType != ObjectType.Equip)
        {
            return false;
        }
        if (player.heroType == HeroType.magician)
        {
            if (info.aplicationType == AplicationType.Swordman)
            {
                return false;
            }
        }
        if (player.heroType == HeroType.Swordman)
        {
            if (info.aplicationType == AplicationType.Magician)
            {
                return false;
            }
        }//以上处理穿戴不成功情况
        //穿戴成功分两种情况：当前没有穿戴同类型装备/已经穿戴同类型装备
        if (info.dressType == DressType.Headgear)
        {
            if (Headgear.transform.childCount == 0)
            {
                AddEquip(id);
            }
            else
            {
                AddEquip(id);
                TakeOffName = Headgear.transform.GetChild(0).name;
                inventory.TakeBack(TakeOffName);
                Headgear.GetComponentInChildren<MyDrag>().UpdatePorperty_red();
                Destroy(Headgear.GetComponentInChildren<MyDrag>().gameObject);
            }
        }

        if (info.dressType == DressType.Armor)
        {
            if (Armor.transform.childCount == 0)
            {
                AddEquip(id);
            }
            else
            {
                AddEquip(id);
                TakeOffName = Armor.transform.GetChild(0).name;
                inventory.TakeBack(TakeOffName);
                Armor.GetComponentInChildren<MyDrag>().UpdatePorperty_red();
                Destroy(Armor.GetComponentInChildren<MyDrag>().gameObject);
            }
        }

        if (info.dressType == DressType.LeftHand)
        {
            if (LeftHand.transform.childCount == 0)
            {
                AddEquip(id);
            }
            else
            {
                AddEquip(id);
                TakeOffName = LeftHand.transform.GetChild(0).name;
                inventory.TakeBack(TakeOffName);
                LeftHand.GetComponentInChildren<MyDrag>().UpdatePorperty_red();
                Destroy(LeftHand.GetComponentInChildren<MyDrag>().gameObject);
            }
        }

        if (info.dressType == DressType.RightHand)
        {
            if (RightHand.transform.childCount == 0)
            {
                AddEquip(id);
            }
            else
            {
                AddEquip(id);
                TakeOffName = RightHand.transform.GetChild(0).name;
                inventory.TakeBack(TakeOffName);
                RightHand.GetComponentInChildren<MyDrag>().UpdatePorperty_red();
                Destroy(RightHand.GetComponentInChildren<MyDrag>().gameObject);
            }
        }

        if (info.dressType == DressType.Shoes)
        {
            if (Shoes.transform.childCount == 0)
            {
                AddEquip(id);
            }
            else
            {
                AddEquip(id);
                TakeOffName = Shoes.transform.GetChild(0).name;
                inventory.TakeBack(TakeOffName);
                Shoes.GetComponentInChildren<MyDrag>().UpdatePorperty_red();
                Destroy(Shoes.GetComponentInChildren<MyDrag>().gameObject);

            }
        }

        if (info.dressType == DressType.Accessory)
        {
            if (Accessory.transform.childCount == 0)
            {
                AddEquip(id);
            }
            else
            {
                AddEquip(id);
                TakeOffName = Accessory.transform.GetChild(0).name;
                inventory.TakeBack(TakeOffName);
                Accessory.GetComponentInChildren<MyDrag>().UpdatePorperty_red();
                Destroy(Accessory.GetComponentInChildren<MyDrag>().gameObject);
            }
        }
        return true;
    }

    public void TakeOff(GameObject gameObject)
    {
        inventory.TakeBack(gameObject.name);
        Destroy(gameObject);
    }

    private void AddEquip(int id)
    {
        int index=0;
        GameObject equip;
        GameObject dressType = Headgear;
        switch (id)
        {
            case 201:
                index = 0;
                dressType = Armor;
                break;
            case 202:
                index = 1;
                dressType = Armor;
                break;
            case 203:
                index = 2;
                dressType = Armor;
                break;
            case 204:
                index = 3;
                dressType = Armor;
                break;
            case 205:
                index = 4;
                dressType = Shoes;
                break;
            case 206:
                index = 5;
                dressType = Shoes;
                break;
            case 207:
                index = 6;
                dressType = Headgear;
                break;
            case 208:
                index = 7;
                dressType = Headgear;
                break;
            case 209:
                index = 8;
                dressType = Headgear;
                break;
            case 210:
                index = 9;
                dressType = Headgear;
                break;
            case 211:
                index = 10;
                dressType = Accessory;
                break;
            case 212:
                index = 11;
                dressType = Accessory;
                break;
            case 213:
                index = 12;
                dressType = LeftHand;
                break;
            case 214:
                index = 13;
                dressType = LeftHand;
                break;
            case 215:
                index = 14;
                dressType = Accessory;
                break;
            case 216:
                index = 15;
                dressType = RightHand;
                break;
            case 217:
                index = 16;
                dressType = RightHand;
                break;
            case 218:
                index = 17;
                dressType = RightHand;
                break;
            case 219:
                index = 18;
                dressType = RightHand;
                break;
            case 220:
                index = 19;
                dressType = RightHand;
                break;
            case 221:
                index = 20;
                dressType = RightHand;
                break;
            case 222:
                index = 21;
                dressType = RightHand;
                break;
        }
        NGUITools.AddChild(dressType, equip=GoodsPrefabs[index]);
        //equip.transform.localPosition = Vector3.zero;
    }
}
