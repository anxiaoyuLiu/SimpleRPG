using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDrag : UIDragDropItem {

    public string goodsName;
    public bool isHover = false;
    public UILabel Number;

    private GameObject inventory;
    private int number = 0;
    private ObjectInfo objectInfo;
    private ObjectsInfo objectsInfo;
    private int id = 101;
    private Equipment equipment;
    private PlayerInformation information;

    //protected override void Awake()
    //{
    //    
    //}

    protected override void Start()
    {
        base.Start();
        goodsName = this.gameObject.name;
        GetMessage(this.gameObject.name);
        equipment = GameObject.Find("Equipment").GetComponent<Equipment>();
        inventory = GameObject.Find("Inventory");
        objectsInfo = GameObject.Find("GameSetting").GetComponent<ObjectsInfo>();
        information = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerInformation>();
        GetMessage(this.gameObject.name);
        objectInfo = objectsInfo.FindObjectInDictionary(id);
    }

    protected override void Update()
    {
        base.Update();
        if (isHover&&Input.GetMouseButtonDown(1))
        {
            if (id == 101)
            {
                HpBottle_mix();
            }else if (id == 102)
            {
                HpBottle_max();
            }else if (id == 103)
            {
                MpBottle();
            }
            if (inventory.transform.position.x == 0)
            {
                TryDress();
                OnHoverOut();
            }else if (equipment.transform.position.x == 0)
            {
                UpdatePorperty_red();
                equipment.TakeOff(this.gameObject);
                OnHoverOut();
            }
            //UpdatePorperty_add();
        }
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

    public void OnHoverOver()
    {
        GoodsMessage.message.Show(id);
        isHover = true;
    }

    public void OnHoverOut()
    {
        GoodsMessage.message.Close();
        isHover = false;
    }

    private void TryDress()
    {
        bool dressOver = equipment.Dress(id);
        if (dressOver)
        {
            UpdatePorperty_add();
            Destroy(this.gameObject);
        }
    }

    public void HpBottle_max()
    {
        information.AddHp(100);
        Destroy(this.gameObject);
    }

    public void HpBottle_mix()
    {
        information.AddHp(100);
        Destroy(this.gameObject);
    }

    public void MpBottle()
    {
        information.AddMp(50);
        Destroy(this.gameObject);
    }

    public void UpdatePorperty_add()//更新角色属性
    {
        information.Attack += objectInfo.attack;
        information.Defence += objectInfo.defence;
        information.Speed += objectInfo.Speed;
        information.attack_add += objectInfo.attack;
        information.defence_add += objectInfo.defence;
        information.speed_add += objectInfo.Speed;
    }

    public void UpdatePorperty_red()//更新角色属性
    {
        information.Attack -= objectInfo.attack;
        information.Defence -= objectInfo.defence;
        information.Speed -= objectInfo.Speed;
        information.attack_add -= objectInfo.attack;
        information.defence_add -= objectInfo.defence;
        information.speed_add -= objectInfo.Speed;
    }
}
