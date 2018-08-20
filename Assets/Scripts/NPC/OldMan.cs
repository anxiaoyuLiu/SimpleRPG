using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldMan : NPC {

    public GameObject AcceptButton;
    public GameObject CancleButton;
    public GameObject OKButton;
    public TweenPosition tween;
    public UILabel label;
    public int taskCount_baby = 0;
    public int taskCount_normal = 0;
    public int taskCount_boss = 0;

    public GameObject Inventroy;
    public GameObject Status;
    public GameObject Skill;
    public GameObject Equipment;
    public GameObject Setting;
    public TweenPosition DrugShop;

    private bool isInTask = false;
    public int taskLevel = 1;
    private PlayerInformation information;
    private ButtonManager manager;

    private void Start()
    {
        information = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerInformation>();
        manager = GameObject.Find("GameSetting").GetComponent<ButtonManager>();
    }

    private void ShowMessage()
    {
        if (taskLevel == 1)
        {
            if (isInTask)
            {
                if (taskCount_baby < 10)
                {
                    label.text = "任务进度：\n" + taskCount_baby + "\\10只小野狼";
                }
                else
                {
                    label.text = "感谢你，年轻的冒险者\n可恶的狼群终于离开了，你帮了我们一个大忙啊！\n\n（任务完成）\n\n获得奖励：600金币";
                }
            }
            else
            {
                label.text = "你好，年轻的冒险者\n最近村子外面的小树林不太安宁，有好几位村民都被野狼袭击了，你愿意帮助我们赶走这些野兽吗？\n\n(任务：杀死10只小野狼)\n\n奖励：600金币";
                OKButton.SetActive(false);
                AcceptButton.SetActive(true);
                CancleButton.SetActive(true);
            }
        }else if (taskLevel == 2)
        {
            if (isInTask)
            {
                if (taskCount_normal < 5)
                {
                    label.text = "任务进度：\n" + taskCount_normal + "\\5只大野狼";
                }
                else
                {
                    label.text = "感谢你，勇敢的冒险者\n除去了这几只野狼，村民再也不用担心山羊丢失了！\n\n（任务完成）\n\n获得奖励：1500金币";
                }
            }
            else
            {
                label.text = "你好，勇敢的冒险者\n昨天听村民讲，虽然狼群离开了，但还有几只孤狼在村子远处的山谷徘徊，袭击村民放养的山羊，你愿意帮助我们除去这几只野狼吗？\n\n(任务：杀死5只大野狼)\n\n奖励：1500金币";
                OKButton.SetActive(false);
                AcceptButton.SetActive(true);
                CancleButton.SetActive(true);
            }
        }else if (taskLevel == 3)
        {
            if (isInTask)
            {
                if (taskCount_boss < 1)
                {
                    label.text = "任务进度：\n" + taskCount_boss + "\\1只野狼首领";
                }
                else
                {
                    label.text = "感谢您，年轻的勇者\n可恶的狼群终于离开了，你帮了我们一个大忙啊！\n\n（任务完成）\n\n获得奖励：5000金币";
                }
            }
            else
            {
                label.text = "您好，年轻的勇者\n听说前两天有村民在大山深处远远看见了一只可怕的怪物，它的眼睛发着红光，头上燃烧着火焰。我猜测它就是最近野兽动荡不安的原因，你愿意帮我去查看一下吗？\n\n(任务：杀死1只野狼首领)\n\n奖励：5000金币";
                OKButton.SetActive(false);
                AcceptButton.SetActive(true);
                CancleButton.SetActive(true);
            }
        }
        else
        {
            label.text = "您好，尊敬的勇者\n感谢您的帮助！听说您准备离开了，祝愿你旅途顺利！";
            OKButton.SetActive(false);
            AcceptButton.SetActive(false);
            CancleButton.SetActive(false);
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Inventroy.GetComponent<TweenPosition>().PlayReverse();
            Skill.GetComponent<TweenPosition>().PlayReverse();
            Equipment.GetComponent<TweenPosition>().PlayReverse();
            Status.GetComponent<TweenPosition>().PlayReverse();
            Setting.GetComponent<TweenPosition>().PlayReverse();
            DrugShop.PlayReverse();
            tween.gameObject.SetActive(true);
            tween.PlayForward();
            ShowMessage();
            manager.UIisShowing = true;
            this.GetComponent<AudioSource>().Play();
        }
    }

    public void OnCloseButtonClick()
    {
        tween.PlayReverse();
        manager.UIisShowing = false;
    }

    public void OnAcceptButtonClick()
    {
        isInTask = true;
        OKButton.SetActive(true);
        AcceptButton.SetActive(false);
        CancleButton.SetActive(false);
        ShowMessage();
    }

    public void OnCancleButtonClick()
    {
        tween.PlayReverse();
        manager.UIisShowing = false;
    }

    public void OnOKButtonClick()
    {
        if (taskLevel == 1)
        {
            if (taskCount_baby < 10)
            {
                tween.PlayReverse();
                manager.UIisShowing = false;
            }
            else
            {
                isInTask = false;
                taskLevel++;
                ShowMessage();
                information.CoinAdd(600);
                taskCount_baby = 0;
            }
        }else if (taskLevel == 2)
        {
            if (taskCount_normal < 5)
            {
                tween.PlayReverse();
                manager.UIisShowing = false;
            }
            else
            {
                isInTask = false;
                taskLevel++;
                ShowMessage();
                information.CoinAdd(1500);
                taskCount_normal = 0;
            }
        }else if (taskLevel == 3)
        {
            if (taskCount_boss < 1)
            {
                tween.PlayReverse();
                manager.UIisShowing = false;
            }
            else
            {
                isInTask = false;
                taskLevel++;
                ShowMessage();
                information.CoinAdd(5000);
                taskCount_boss = 0;
            }
        }
    }
}
