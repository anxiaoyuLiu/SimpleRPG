using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    private PlayerMove playerMove;
    private Animation anim;
    private PlayerInformation playerInformation;

    private float times_move = 0.2f;
    private float time_move = 0;
    private Vector3 begin = Vector3.zero;
    private Vector3 end = Vector3.zero;
    private float distance;

    private void Start()
    {
        playerInformation = transform.GetComponent<PlayerInformation>();
        anim = GetComponent<Animation>();
        playerMove = transform.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update () {
        if (playerInformation.heroType == HeroType.magician)
        {
            if (PlayerInformation.playerInformation.playerState == PlayerState.Idle)
            {
                anim.CrossFade("Idle");
            }
            else if (PlayerInformation.playerInformation.playerState == PlayerState.Moving)
            {
                time_move += Time.deltaTime;
                if (time_move <= 0.1f)
                {
                    begin = transform.position;
                }
                else if (time_move >= times_move)
                {
                    end = transform.position;
                    distance = Vector3.Distance(begin, end);
                    if (distance < 0.1f)
                    {
                        playerMove.targetPosition = this.transform.position;
                    }
                    time_move = 0;
                }
                anim.CrossFade("Run");
            }
            else if (PlayerInformation.playerInformation.playerState == PlayerState.Attack)
            {
                anim.CrossFade("Attack1");
            }
            else if (PlayerInformation.playerInformation.playerState == PlayerState.ReleaseSkill)
            {
                //anim.CrossFade("animName");
                anim.CrossFade("Attack2");
            }
            else if (PlayerInformation.playerInformation.playerState == PlayerState.Death)
            {
                anim.CrossFade("Death");
            }
        }
        else if(playerInformation.heroType==HeroType.Swordman)
        {
            if (PlayerInformation.playerInformation.playerState == PlayerState.Idle)
            {
                anim.CrossFade("Sword-Idle");
            }
            else if (PlayerInformation.playerInformation.playerState == PlayerState.Moving)
            {
                time_move += Time.deltaTime;
                if (time_move <= 0.1f)
                {
                    begin = transform.position;
                }
                else if (time_move >= times_move)
                {
                    end = transform.position;
                    distance = Vector3.Distance(begin, end);
                    if (distance < 0.1f)
                    {
                        playerMove.targetPosition = this.transform.position;
                    }
                    time_move = 0;
                }
                anim.CrossFade("Sword-Run");
            }
            else if (PlayerInformation.playerInformation.playerState == PlayerState.Attack)
            {
                anim.CrossFade("Sword-Attack1");
            }
            else if (PlayerInformation.playerInformation.playerState == PlayerState.ReleaseSkill)
            {
                //anim.CrossFade("animName");
                anim.CrossFade("Sword-Attack2");
            }
            else if (PlayerInformation.playerInformation.playerState == PlayerState.Death)
            {
                anim.CrossFade("Sword-Death");
            }
        }
	}
}
