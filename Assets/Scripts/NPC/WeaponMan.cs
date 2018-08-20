using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMan : NPC {

    public TweenPosition shop;
    public GameObject Inventroy;
    public GameObject Status;
    public GameObject Skill;
    public GameObject Equipment;
    public GameObject Setting;
    public GameObject DrugShop;
    public TweenPosition QuestTween;

    private ButtonManager manager;

    private void Start()
    {
        manager = GameObject.Find("GameSetting").GetComponent<ButtonManager>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.GetComponent<AudioSource>().Play();
            shop.gameObject.SetActive(true);
            shop.PlayForward();
            manager.UIisShowing = true;
            Inventroy.GetComponent<TweenPosition>().PlayReverse();
            Skill.GetComponent<TweenPosition>().PlayReverse();
            Equipment.GetComponent<TweenPosition>().PlayReverse();
            Setting.GetComponent<TweenPosition>().PlayReverse();
            QuestTween.PlayReverse();
            Status.GetComponent<TweenPosition>().PlayReverse();
            DrugShop.GetComponent<TweenPosition>().PlayReverse();
        }
    }
}
