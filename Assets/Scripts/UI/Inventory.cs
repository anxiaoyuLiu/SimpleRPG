using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public GameObject[] Grids = new GameObject[] { };
    public GameObject[] GoodsPrefabs;
    public UILabel CoinLabel;

    private bool isFound = false;
    private int index;
    private PlayerInformation player;
    //private GameObject[] GoodsArray;
    private int goods_index = 0;
    //private GameObject NewGoods;
    private ObjectsInfo objects;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInformation>();
        objects = GameObject.Find("GameSetting").GetComponent<ObjectsInfo>();
    }

    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInformation>();
    }

    private void Update()
    {
        
        if (this.transform.position.x == 0)
        {
            CoinLabel.text = player.Coin.ToString();
        }
        else
        {
            //Debug.Log(0);
        }
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    PickUp();
        //}
    }

    public void PickUp()
    {
        int index = Random.Range(0, GoodsPrefabs.Length);
        GameObject goods = GoodsPrefabs[index];
        //Debug.Log(objects.FindObjectInDictionary(0).name);
        //Debug.Log(objects.FindObjectInDictionary(1).name);
        //Debug.Log(objects.FindObjectInDictionary(2).name);
        //Debug.Log(objects.FindObjectInDictionary(3).name);
        //Debug.Log(objects.FindObjectInDictionary(4).name);
        /// <summary>
        /// 方案一，弃用（没有首先遍历一遍判断该物品是否已存在，当拾取的物品已经存在，且该物品前有空的格子时，）
        ///                       （拾取的物品会直接添加到该空格）
        /// </summary>

        //for (int i = 0; i < Grids.Length; i++)
        //{
        //    if (Grids[i].transform.childCount > 0)
        //    {
        //        string getName = Grids[i].GetComponentInChildren<MyDrag>().goodsName.Replace("(Clone)", "");
        //        if (goods.name == getName)
        //        {
        //            Grids[i].GetComponentInChildren<MyDrag>().ChangeNumber(1);
        //            break;
        //        }
        //    }
        //    else
        //    {
        //        NGUITools.AddChild(Grids[i], goods);
        //        goods.transform.localPosition = Vector3.zero;
        //        break;
        //    }
        //}

        /// <summary>
        /// 方案二
        /// </summary>

        for (int i = 0; i < Grids.Length; i++)
        {
            if(Grids[i].transform.childCount > 0)
            {
                string getName = Grids[i].GetComponentInChildren<MyDrag>().goodsName.Replace("(Clone)", "");
                if (goods.name == getName)
                {
                    index = i;
                    isFound = true;
                    break;
                }
            }
        }
        if (isFound)
        {
            Grids[index].GetComponentInChildren<MyDrag>().ChangeNumber(1);
            isFound = false;
        }
        else
        {
            for (int i = 0; i < Grids.Length; i++)
            {
                if (Grids[i].transform.childCount == 0)
                {
                    NGUITools.AddChild(Grids[i], goods);
                    goods.transform.localPosition = Vector3.zero;
                    break;
                }
            }
        }
    }

    public void TakeBack(string name)
    {
        foreach (var goods in GoodsPrefabs)
        {
            if (goods.name == name.Replace("(Clone)",""))
            {
                GameObject gameObject = goods;
                //goods.GetComponent<MyDrag>().UpdatePorperty_red();
                PutInBag(gameObject);
            }
        }
    }

    public void CreatGoods(int id,int number)
    {
        if (id == 101)
        {
            GameObject goods = GoodsPrefabs[0];
            //GoodsArray[goods_index] = goods;
            //goods_index++;
            PutInBag(goods,number);
        }else if (id == 102)
        {
            GameObject goods = GoodsPrefabs[1];
            //GoodsArray[goods_index] = goods;
            //goods_index++;
            PutInBag(goods, number);
        }
        else if (id == 103)
        {
            GameObject goods = GoodsPrefabs[2];
            //GoodsArray[goods_index] = goods;
            //goods_index++;
            PutInBag(goods, number);
        }

    }

    private void PutInBag(GameObject goods,int number)
    {
        for (int i = 0; i < Grids.Length; i++)
        {
            if (Grids[i].transform.childCount > 0)
            {
                string getName = Grids[i].GetComponentInChildren<MyDrag>().goodsName.Replace("(Clone)", "");
                if (goods.name == getName)
                {
                    index = i;
                    isFound = true;
                    break;
                }
            }
        }
        if (isFound)
        {
            Grids[index].GetComponentInChildren<MyDrag>().ChangeNumber(number);
            isFound = false;
        }
        else
        {
            for (int i = 0; i < Grids.Length; i++)
            {
                if (Grids[i].transform.childCount == 0)
                {
                    NGUITools.AddChild(Grids[i], goods);
                    goods.transform.localPosition = Vector3.zero;
                    Grids[i].GetComponentInChildren<MyDrag>().ChangeNumber(number);
                    break;
                }
            }
        }
    }

    public void PutInBag(GameObject goods)
    {
        for (int i = 0; i < Grids.Length; i++)
        {
            if (Grids[i].transform.childCount == 0)
            {
                NGUITools.AddChild(Grids[i], goods);
                goods.transform.localPosition = Vector3.zero;
                break;
            }
        }
    }
}
