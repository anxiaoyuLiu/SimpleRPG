using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugShop : MonoBehaviour {

    public UILabel Number;
    public UISprite IntNumber;
    public TweenAlpha tween;
    public UILabel Warn;
    public int id = 0;
    public int number = 1;

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
        this.GetComponent<TweenPosition>() .PlayReverse();
        IntNumber.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
        manager.UIisShowing = false;
        Warn.gameObject.SetActive(false);
    }

    public void BuyMixBottleHP()
    {
        IntNumber.gameObject.SetActive(true);
        id = 101;
        Warn.gameObject.SetActive(false);
    }

    public void BuyMaxBottleHP()
    {
        IntNumber.gameObject.SetActive(true);
        id = 102;
        Warn.gameObject.SetActive(false);
    }

    public void BuyBottleMP()
    {
        IntNumber.gameObject.SetActive(true);
        id = 103;
        Warn.gameObject.SetActive(false);
    }

    public void OnOKButtonClick()
    {
        if(int.Parse(Number.text)>0&& int.Parse(Number.text) < 1000)
        {
            number = int.Parse(Number.text);
        }
        else
        {
            number = 1;
        }
        int price = info.FindObjectInDictionary(id).price_buy;
        if (player.Coin>price*number)
        {
            player.Coin -= (price * number);
            inventory.CreatGoods(id, number);
            IntNumber.gameObject.SetActive(false);
            Warn.gameObject.SetActive(false);
        }
        else
        {
            Warn.gameObject.SetActive(true);
        }
        Number.text = "1";
    }
}
