using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {

    private PlayerInformation player;

    public UILabel Attack;
    public UILabel Defence;
    public UILabel Speed;
    public UILabel Point;

    private void Start()
    {
        //player = new PlayerInformation();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInformation>();
        Attack.text = player.Attack.ToString();
        Defence.text = player.Defence.ToString();
        Speed.text = player.Speed.ToString();
        Point.text = player.Point.ToString();
    }

    private void Update()
    {
        if (this.transform.position.x==0)
        {
            UpdateMessage();
        }
    }

    public void OnAttackAddButtonClick()
    {
        if (player.Point > 0)
        {
            player.Attack++;
            player.Point--;
            Attack.text = player.Attack.ToString();
            Point.text = player.Point.ToString();
        }
    }

    public void OnDefenceAddButtonClick()
    {
        if (player.Point > 0)
        {
            player.Defence++;
            player.Point--;
            Defence.text = player.Defence.ToString();
            Point.text = player.Point.ToString();
        }
    }

    public void OnSpeedAddButtonClick()
    {
        if (player.Point > 0)
        {
            player.Speed++;
            player.Point--;
            Speed.text = player.Speed.ToString();
            Point.text = player.Point.ToString();
        }
    }

    private void UpdateMessage()
    {
        Attack.text = player.Attack.ToString();
        Defence.text = player.Defence.ToString();
        Speed.text = player.Speed.ToString();
        Point.text = player.Point.ToString();
    }
}
