using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HeroType
{
    Swordman,
    magician
}

public enum PlayerState
{
    Moving,
    Idle,
    Attack,
    ReleaseSkill,
    Death
}

public class PlayerInformation : MonoBehaviour {

    public static PlayerInformation playerInformation;

    public HeroType heroType;
    public int HP_max=100;
    public int MP_max=100;
    public float HP = 100;
    public float MP = 100; 
    public int Level=1;
    public int Exp = 0;
    private int Exp_max;
    public string PlayerName = "安小予";
    public int Coin=500;//金币
    public PlayerState playerState;

    public int Attack=25;
    public int Defence=10;
    public int Speed=5;
    public int Point=5;

    public int attack_add = 0;
    public int defence_add = 0;
    public int speed_add = 0;

    private GameObject Status;
    private UISlider ExpSlider;

    private void Awake()
    {
        playerState = PlayerState.Idle;
        playerInformation = this;
        Status = GameObject.Find("Status");
        Exp_max = Level * 10 + 90;
        ExpSlider = GameObject.Find("Exp").GetComponent<UISlider>();
        GetExp(0);
    }

    private void Update()
    {

    }

    public void CoinAdd(int count)
    {
        Coin += count;
    }

    public void CoinReduce(int count)
    {
        Coin -= count;
    }

    public void GetExp(int exp)
    {
        Exp += exp;
        this.Exp_max = Level * 20 + 90;
        while (Exp >= Exp_max)
        {
            Level++;
            //TODO 播放升级特效
            Exp -= Exp_max;
            this.Exp_max = Level * 20 + 90;
            this.HP = HP_max;
            this.MP = MP_max;
            Point += 5;
        }
        float value = (Exp * 10 / Exp_max) * 0.1f;
        ExpSlider.value = value;
    }

    public bool TakeMp(int mp)
    {
        if (mp <= this.MP)
        {
            this.MP -= mp;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddHp(float value)
    {
        if (HP + value <= HP_max)
        {
            HP += value;
        }
        else
        {
            HP = HP_max;
        }
    }

    public void AddMp(float value)
    {
        if (MP + value <= MP_max)
        {
            MP += value;
        }
        else
        {
            MP = MP_max;
        }
    }
}
