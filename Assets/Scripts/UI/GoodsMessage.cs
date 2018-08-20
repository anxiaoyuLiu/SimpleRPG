using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsMessage : MonoBehaviour {

    public static GoodsMessage message;

    private UILabel label;
    private string str;
    private MyDrag drag;

    private void Start()
    {
        message = this;
        label = GetComponentInChildren<UILabel>();
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        this.transform.position = UICamera.currentCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    public void Show(int id)
    {
        this.gameObject.SetActive(true);
        ObjectInfo info = ObjectsInfo.info.FindObjectInDictionary(id);
        //Debug.Log(info.name);
        switch (info.objectType)
        {
            case ObjectType.Drug:
                str = Drug_Show(info);
                break;
            case ObjectType.Equip:
                str = Equipment_Show(info);
                break;
            case ObjectType.Mat:
                str = Mat_Show(info);
                break;
        }
        label.text = str;
    }

    private string Drug_Show(ObjectInfo info)
    {
        string str = "";
        str += "名称：" + info.name + "\n";
        str += "血量回复：" + info.hp + "\n";
        str += "魔法回复：" + info.mp + "\n";
        str += "售出价格：" + info.price_sell + "\n";
        str += "购买价格：" + info.price_buy + "\n";
        return str;
    }

    private string Equipment_Show(ObjectInfo info)
    {
        string str = "";
        str += "名称： " + info.name + "\n";
        str += "穿戴类型： " + info.dressType + "\n";
        str += "适用类型：" + info.aplicationType + "\n";
        str += "攻击力：" + info.attack + "\n";
        str += "防御力：" + info.defence + "\n";
        str += "速度值：" + info.Speed + "\n";
        str += "售出价格：" + info.price_sell + "\n";
        str += "购买价格：" + info.price_buy + "\n";
        return str;
    }

    private string Mat_Show(ObjectInfo info)
    {
        string str = "";
        str += "名称： " + info.name + "\n";
        str += "售出价格：" + info.price_sell + "\n";
        str += "购买价格：" + info.price_buy + "\n";
        return str;
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }
}
