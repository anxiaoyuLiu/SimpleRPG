using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDrug : UIDragDropItem {

    public string goodsName;
    public bool isHover = false;

    private UILabel Number;
    private int number = 0;
    private ObjectInfo info;
    private int id = 101;

    //protected override void Awake()
    //{
    //    number = getcomponentinchildren<uilabel>();
    //}

    protected override void Start()
    {
        base.Start();
        goodsName = this.gameObject.name;
        //Number = GetComponentInChildren<UILabel>();
        GetMessage(this.gameObject.name);
    }

    protected override void OnDragDropStart()
    {
        base.OnDragDropStart();
        this.transform.GetComponent<UISprite>().depth += 1;
    }

    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);
        if (surface.tag == Tags.grid)
        {
            this.transform.parent = surface.transform;
            this.transform.localPosition = Vector3.zero;
        }
        else if (surface.tag == Tags.goods)
        {
            Transform parent = this.transform.parent;
            this.transform.parent = surface.transform.parent;
            this.transform.localPosition = Vector3.zero;
            surface.transform.parent = parent;
            surface.transform.localPosition = Vector3.zero;
        }
        else
        {
            this.transform.parent = transform.parent;
            this.transform.localPosition = Vector3.zero;
        }
        this.transform.GetComponent<UISprite>().depth -= 1;
    }

    public void ChangeNumber(int i)
    {
        number += i;
        Number.text = number.ToString();
    }

    public int GetMessage(string name)
    {
        switch (name.Replace("(Clone)", ""))
        {
            case "HpBottle_mix":
                id = 101;
                break;
            case "HpBottle_max":
                id = 102;
                break;
            case "MpBottle":
                id = 103;
                break;
            case "armor0-icon":
                id = 201;
                break;
            case "armor1-icon":
                id = 202;
                break;
            case "armor2-icon":
                id = 203;
                break;
            case "armor3-icon":
                id = 204;
                break;
            case "icon-boot0":
                id = 205;
                break;
            case "icon-boot0-01":
                id = 206;
                break;
            case "icon-helm":
                id = 207;
                break;
            case "icon-helm-01":
                id = 208;
                break;
            case "icon-helm-02":
                id = 209;
                break;
            case "icon-helm-03":
                id = 210;
                break;
            case "icon-ring":
                id = 211;
                break;
            case "icon-ring-01":
                id = 212;
                break;
            case "icon-shield":
                id = 213;
                break;
            case "icon-shield1":
                id = 214;
                break;
            case "icon-tailman":
                id = 215;
                break;
            case "rod-icon":
                id = 216;
                break;
            case "rod-icon02":
                id = 217;
                break;
            case "rod-icon03":
                id = 218;
                break;
            case "sword0-icon":
                id = 219;
                break;
            case "sword0-icon00":
                id = 220;
                break;
            case "sword1-icon":
                id = 221;
                break;
            case "sword2-icon":
                id = 222;
                break;
        }
        return id;
    }
}
