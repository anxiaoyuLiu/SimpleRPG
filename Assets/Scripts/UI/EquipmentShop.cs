using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentShop : MonoBehaviour {

    public GameObject Ring;
    public GameObject Armor0;
    public GameObject Armor2;
    public GameObject Boot0;
    public GameObject Helm;
    public GameObject Shield1;
    public GameObject Rod;
    public GameObject Sword2;
    public GameObject Tailman;

    private ButtonManager manager;
    private Inventory inventory;
    private ObjectsInfo info;
    private PlayerInformation player;

    private void Start()
    {
        manager = GameObject.Find("GameSetting").GetComponent<ButtonManager>();
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        info = GameObject.Find("GameSetting").GetComponent<ObjectsInfo>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInformation>();
    }

    public void OnCloseButtonClick()
    {
        this.GetComponent<TweenPosition>().PlayReverse();
        this.gameObject.SetActive(false);
        manager.UIisShowing = false;
        //Warn.gameObject.SetActive(false);
    }

    public void BuyRing()
    {
        int price = 2500;
        if (player.Coin > price )
        {
            player.Coin -= price;
            inventory.PutInBag(Ring);
        }
    }

    public void BuyArmor0()
    {
        int price = 2000;
        if (player.Coin > price)
        {
            player.Coin -= price;
            inventory.PutInBag(Armor0);
        }
    }

    public void BuyArmor2()
    {
        int price = 2000;
        if (player.Coin > price)
        {
            player.Coin -= price;
            inventory.PutInBag(Armor2);
        }
    }

    public void BuyBoot0()
    {
        int price = 2800;
        if (player.Coin > price)
        {
            player.Coin -= price;
            inventory.PutInBag(Boot0);
        }
    }

    public void BuyHelm()
    {
        int price = 3000;
        if (player.Coin > price)
        {
            player.Coin -= price;
            inventory.PutInBag(Helm);
        }
    }

    public void BuyShield1()
    {
        int price = 3000;
        if (player.Coin > price)
        {
            player.Coin -= price;
            inventory.PutInBag(Shield1);
        }
    }

    public void BuyRod()
    {
        int price = 3000;
        if (player.Coin > price)
        {
            player.Coin -= price;
            inventory.PutInBag(Rod);
        }
    }

    public void BuySword2()
    {
        int price = 3800;
        if (player.Coin > price)
        {
            player.Coin -= price;
            inventory.PutInBag(Sword2);
        }
    }

    public void BuyTailman()
    {
        int price = 1500;
        if (player.Coin > price)
        {
            player.Coin -= price;
            inventory.PutInBag(Tailman);
        }
    }
}
