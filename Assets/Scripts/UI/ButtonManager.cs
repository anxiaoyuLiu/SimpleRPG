using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

    public GameObject Inventroy;
    public GameObject Status;
    public GameObject Skill;
    public GameObject Equipment;
    public GameObject Setting;
    public TweenPosition QuestTween;
    public TweenPosition DrugTween;
    public TweenPosition WeaponTween;
    public bool UIisShowing = false;

    private void Start()
    {
        //Inventroy.transform.position = new Vector3(700, 15, 0);
    }

    public void OnStatusButtonClick()
    {
        if (UIisShowing)
        {
            if(Status.transform.position.x == 0)
            {
                Status.GetComponent<TweenPosition>().PlayReverse();
                UIisShowing = false;
            }
            else
            {
                Inventroy.GetComponent<TweenPosition>().PlayReverse();
                Skill.GetComponent<TweenPosition>().PlayReverse();
                Equipment.GetComponent<TweenPosition>().PlayReverse();
                Setting.GetComponent<TweenPosition>().PlayReverse();
                QuestTween.PlayReverse();
                Status.GetComponent<TweenPosition>().PlayForward();
                DrugTween.PlayReverse();
                WeaponTween.PlayReverse();
                UIisShowing = true;
            }
        }
        else
        {
            Status.GetComponent<TweenPosition>().PlayForward();
            UIisShowing = true;
        }
    }

    public void OnBagButtonClick()
    {
        if (UIisShowing)
        {
            if (Inventroy.transform.position.x == 0)
            {
                Inventroy.GetComponent<TweenPosition>().PlayReverse();
                UIisShowing = false;
            }
            else
            {
                Status.GetComponent<TweenPosition>().PlayReverse();
                Skill.GetComponent<TweenPosition>().PlayReverse();
                Equipment.GetComponent<TweenPosition>().PlayReverse();
                Setting.GetComponent<TweenPosition>().PlayReverse();
                QuestTween.PlayReverse();
                Inventroy.GetComponent<TweenPosition>().PlayForward();
                DrugTween.PlayReverse();
                WeaponTween.PlayReverse();
                UIisShowing = true;
            }
        }
        else
        {
            Inventroy.GetComponent<TweenPosition>().PlayForward();
            UIisShowing = true;
        }
    }

    public void OnSkillButtonClick()
    {
        if (UIisShowing)
        {
            if (Skill.transform.position.x == 0)
            {
                Skill.GetComponent<TweenPosition>().PlayReverse();
                UIisShowing = false;
            }
            else
            {
                Inventroy.GetComponent<TweenPosition>().PlayReverse();
                Status.GetComponent<TweenPosition>().PlayReverse();
                Equipment.GetComponent<TweenPosition>().PlayReverse();
                Setting.GetComponent<TweenPosition>().PlayReverse();
                QuestTween.PlayReverse();
                Skill.GetComponent<TweenPosition>().PlayForward();
                DrugTween.PlayReverse();
                WeaponTween.PlayReverse();
                UIisShowing = true;
            }
        }
        else
        {
            Skill.GetComponent<TweenPosition>().PlayForward();
            UIisShowing = true;
        }
    }

    public void OnEquipmentButtonClick()
    {
        if (UIisShowing)
        {
            if (Equipment.transform.position.x == 0)
            {
                Equipment.GetComponent<TweenPosition>().PlayReverse();
                UIisShowing = false;
            }
            else
            {
                Inventroy.GetComponent<TweenPosition>().PlayReverse();
                Skill.GetComponent<TweenPosition>().PlayReverse();
                Status.GetComponent<TweenPosition>().PlayReverse();
                Setting.GetComponent<TweenPosition>().PlayReverse();
                QuestTween.PlayReverse();
                Equipment.GetComponent<TweenPosition>().PlayForward();
                DrugTween.PlayReverse();
                WeaponTween.PlayReverse();
                UIisShowing = true;
            }
        }
        else
        {
            Equipment.GetComponent<TweenPosition>().PlayForward();
            UIisShowing = true;
        }
    }

    public void OnSettingButtonClick()
    {
        if (UIisShowing)
        {
            if (Setting.transform.position.x == 0)
            {
                Setting.GetComponent<TweenPosition>().PlayReverse();
                UIisShowing = false;
            }
            else
            {
                Inventroy.GetComponent<TweenPosition>().PlayReverse();
                Skill.GetComponent<TweenPosition>().PlayReverse();
                Equipment.GetComponent<TweenPosition>().PlayReverse();
                Status.GetComponent<TweenPosition>().PlayReverse();
                QuestTween.PlayReverse();
                Setting.GetComponent<TweenPosition>().PlayForward();
                DrugTween.PlayReverse();
                WeaponTween.PlayReverse();
                UIisShowing = true;
            }
        }
        else
        {
            Setting.GetComponent<TweenPosition>().PlayForward();
            UIisShowing = true;
        }
    }
}
