using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillItem : MonoBehaviour {

    private int id;
    private SkillInfo skillInfo;
    private PlayerInformation player;

    public UISprite uISprite;
    public GameObject mask;
    public UILabel skillName;
    public UILabel skillDes;
    public UILabel mp;
    public UILabel level_lock;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerInformation>();
    }

    private void Update()
    {
        if (player.Level < skillInfo.level_lock)
        {
            mask.SetActive(true);
        }
        else
        {
            mask.SetActive(false);
        }
    }

    public void GetById(int id)
    {
        this.id = id;
        skillInfo = SkillsInfo.skillsInfo.FindSkillInDictionary(id);
        uISprite.spriteName = skillInfo.icon_name;
        skillName.text = "技能名称：" + skillInfo.name;
        skillDes.text = "描述：" + skillInfo.des;
        mp.text = "消耗：" + skillInfo.mp_pay;
        level_lock.text = "解锁LV：" + skillInfo.level_lock;
    }
}
