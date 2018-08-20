using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfBoss : Enemy {

    public float times_move;// = 1.5f;
    public float time_move;// = 0;
    public float times_attack;// = 1.3f;
    public float time_attack;// = 0;
    public float time_anim;// = 0.63f;
    public float speed;// = 1;
    public float miss;// = 0.2f;
    //public float hp;// = 100;
    public int attack;// = 15;
    public float mixDistance;// = 1.6f;
    public float maxDistance;// = 3.8f;
    public int exp;// = 30;
    private int eff = 0;

    public string Idle;
    public string Walk;
    public string Death;
    public string Attack;
    public AudioClip misss_Audio;
    public AudioClip attack1_Audio;
    public GameObject HUDPrefab;
    private GameObject HUDS;
    private WolfBaby_Creater creater;
    private bool isMessageSend = false;
    private bool isAttackOver = true;

    private void Awake()
    {
        anim = transform.GetComponent<Animation>();
        stateNow = Idle;
        controller = transform.GetComponent<CharacterController>();
        normal = transform.Find("Wolf_Baby").GetComponent<SkinnedMeshRenderer>().material.color;
        Target = GameObject.FindGameObjectWithTag(Tags.player);
        playerInformation = Target.GetComponent<PlayerInformation>();
        playerAttack = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerAttack>();
        oldMan = GameObject.Find("Old_NPC").GetComponent<OldMan>();
        HUDS = GameObject.Find("HUDS");
        creater = GameObject.Find("WolfBoss_Creater").GetComponent<WolfBaby_Creater>();
    }

    private void Start()
    {
        HUD = GameObject.Instantiate(HUDPrefab, HUDS.transform);
        HUD.GetComponent<UIFollowTarget>().target = this.transform.Find("Target").transform;
        HUDText = HUD.GetComponent<HUDText>();
    }

    private void Update()
    {
        if (hp <= 0)
        {
            controller.enabled = false;
            playerAttack.isTargetDead = true;
            playerAttack.isEffect_normalEnd = true;
            state = WolfState.Death;
            anim.CrossFade(Death);
            Destroy(this.gameObject, 2.2f);
            Destroy(HUD, 2.2f);
            eff++;
            if (!isMessageSend)
            {
                creater.number_now--;
                isMessageSend = true;
            }
        }
        else
        {
            if (Vector3.Distance(Target.transform.position, transform.position) < maxDistance)
            {
                findPlayer = true;
            }
            else
            {
                findPlayer = false;
            }

            if (findPlayer)
            {
                AutoAttack();
            }
            else
            {
                MoveFree();
            }
        }

        if (eff == 1)
        {
            DeadEff();
        }
    }

    private void AutoAttack()
    {
        if (playerInformation.HP <= 0) return;
        if (Vector3.Distance(Target.transform.position, transform.position) > maxDistance)
        {
            state = WolfState.Idle;
            anim.CrossFade(Idle);
            findPlayer = false;
            return;
        }
        else if (Vector3.Distance(Target.transform.position, transform.position) <= mixDistance)
        {
            time_attack += Time.deltaTime;
            //if (time_attack >= times_attack)
            //{
            //    if(attack > playerInformation.Defence)
            //    {
            //        playerInformation.HP -= (attack - playerInformation.Defence);
            //    }
            //    else
            //    {
            //        playerInformation.HP -= 1;
            //    }
            //    time_attack = 0;
            //}
            if (time_attack < time_anim)
            {
                state = WolfState.Attack;
                anim.CrossFade(Attack);
                if (isAttackOver && time_attack > 0.5f * time_anim)
                {
                    if (attack > playerInformation.Defence)
                    {
                        playerInformation.HP -= (attack - playerInformation.Defence);
                    }
                    else
                    {
                        playerInformation.HP -= 1;
                    }
                    isAttackOver = false;
                }
            }
            else if (time_attack < times_attack)
            {
                state = WolfState.Idle;
                anim.CrossFade(Idle);
            }
            else
            {
                time_attack = 0;
                isAttackOver = true;
            }
        }
        else
        {
            transform.LookAt(Target.transform);
            controller.SimpleMove(transform.forward * speed);
            state = WolfState.Walk;
            anim.CrossFade(Walk);
        }
    }

    private void MoveFree()
    {
        if (state == WolfState.Attack)
        {
            anim.CrossFade(Attack);
        }
        else if (state == WolfState.Death)
        {
            anim.CrossFade(Death);
        }
        else
        {
            anim.CrossFade(stateNow);
            if (stateNow == Walk)
            {
                controller.SimpleMove(transform.forward * speed);
            }
            time_move += Time.deltaTime;
            if (time_move >= times_move)
            {
                StateRandom();
                time_move = 0;
            }
        }
    }

    private void StateRandom()
    {
        int num = Random.Range(0, 2);
        if (num == 0)
        {
            stateNow = Idle;
        }
        else
        {
            if (stateNow != Walk)
            {
                transform.Rotate(Vector3.up * Random.Range(0, 360));
            }
            stateNow = Walk;
        }
    }

    public override void TakeDamage(int attack)
    {
        if (playerInformation.HP <= 0) return;
        if (state == WolfState.Death) return;
        float value = Random.Range(0f, 1f);
        if (value < miss)
        {
            isAttacked = false;
            AudioSource.PlayClipAtPoint(misss_Audio, transform.position);
            HUDText.Add("miss", Color.white, 0.5f);
        }
        else
        {
            isAttacked = true;
            hp -= attack;
            StartCoroutine(ChangeColor());
            HUDText.Add(-attack, Color.red, 0.5f);
            AudioSource.PlayClipAtPoint(attack1_Audio, transform.position);
        }
    }

    IEnumerator ChangeColor()
    {
        transform.Find("Wolf_Baby").GetComponent<SkinnedMeshRenderer>().material.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        transform.Find("Wolf_Baby").GetComponent<SkinnedMeshRenderer>().material.color = normal;
    }

    private void OnMouseOver()
    {
        if (!playerAttack.skillReady)
        MouseType.mouseType.MouseAttack();
    }

    private void OnMouseExit()
    {
        if (!playerAttack.skillReady)
        MouseType.mouseType.MouseNormal();
    }

    private void DeadEff()
    {
        oldMan.taskCount_boss++;
        playerInformation.GetExp(exp);
        playerInformation.Coin += 10;
    }
}
