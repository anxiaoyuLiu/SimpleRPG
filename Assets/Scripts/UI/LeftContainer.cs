﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftContainer : MonoBehaviour {

    public GameObject SkillClickItemPrefab;
    public int[] SwordmanSkills;
    public int[] MagicianSkills;
    public UIGrid Grid;

    private PlayerInformation player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerInformation>();
        int[] List = null;
        switch (player.heroType)
        {
            case HeroType.Swordman:
                List = SwordmanSkills;
                break;
            case HeroType.magician:
                List = MagicianSkills;
                break;
            default:
                break;
        }
        foreach (int id in List)
        {
            GameObject item = NGUITools.AddChild(Grid.gameObject, SkillClickItemPrefab);
            Grid.AddChild(item.transform);
            item.GetComponent<SkillClickItem>().GetById(id);
        }
    }
}
