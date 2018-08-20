using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private float distance_mix = 3.8f;
    private float distance_max = 6;
    private PlayerMove playerMove;
    private PlayerInformation playerInformation;
    private PlayerAnimation playerAnimation;
    private float distance;
    private float times_attack = 1.5f;
    private float times_anim = 0.83f;
    private float time_attack = 0;
    private float applyTimes_attack;
    private float applyTimes_speed;
    private float applyTime_attack = 0;
    private float applyTime_speed = 0;
    private bool buff_attack = false;
    private bool buff_speed = false;
    private float addAttack;
    private float addSpeed;
    private float redColdTime;
    public bool skillReady = false;

    public bool isEffect_normalEnd = true;

    public Transform target;
    public bool isAttack = false;
    public bool isTargetDead = false;
    public GameObject effect_normal;
    public GameObject[] efxArray;
    private Dictionary<string, GameObject> efxDictionary = new Dictionary<string, GameObject>();
    private Transform hit;

    private void Awake()
    {
        playerMove = this.GetComponent<PlayerMove>();
        playerInformation = this.GetComponent<PlayerInformation>();
        playerAnimation = this.GetComponent<PlayerAnimation>();
        target = this.transform;
        foreach (GameObject item in efxArray)
        {
            efxDictionary.Add(item.name, item);
        }
    }

    private void Update()
    {
        if (playerInformation.HP <= 0) return;
        if (isTargetDead)
        {
            target = this.transform;
            PlayerInformation.playerInformation.playerState = PlayerState.Idle;
            isTargetDead = false;
            time_attack = 0;
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && UICamera.isOverUI == false)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isHit = Physics.Raycast(ray, out hit);
                if (isHit && hit.collider.tag == Tags.enemy)
                {
                    if (skillReady) return;
                    target = hit.transform;
                    this.transform.LookAt(target.position);
                    isAttack = true;
                    isTargetDead = false;
                }
            }
            distance = Vector3.Distance(target.position, this.transform.position);
            if (distance > distance_mix && target.tag == Tags.enemy)
            {
                //角色向敌人方向移动
                PlayerInformation.playerInformation.playerState = PlayerState.Moving;
                playerMove.Move(target.position);
            }
            else if (target.tag == Tags.enemy)
            {
                time_attack += Time.deltaTime;
                //普通攻击方案一（弃用）
                //if (isEffect_normalEnd)
                //{
                //    GameObject.Instantiate(effect_normal, target.position, Quaternion.identity);//播放普通攻击特效
                //}
                //if (time_attack > times_anim&&time_attack<times_attack)
                //{
                //    PlayerInformation.playerInformation.playerState = PlayerState.Idle;
                //    isEffect_normalEnd = true;
                //}
                //else if (time_attack >= times_attack)//开始攻击
                //{
                //    PlayerInformation.playerInformation.playerState = PlayerState.Attack;
                //    target.GetComponent<Enemy>().TakeDamage(playerInformation.Attack);
                //    time_attack = 0;
                //    isEffect_normalEnd = false;
                //}
                //方案一

                //方案二
                if (time_attack < times_anim)
                {
                    PlayerInformation.playerInformation.playerState = PlayerState.Attack;
                    if(time_attack > 0.5f * times_anim&&isEffect_normalEnd)
                    {
                        //Debug.Log(isEffect_normalEnd);
                        target.GetComponent<Enemy>().TakeDamage(playerInformation.Attack);
                        GameObject.Instantiate(effect_normal, target.position, Quaternion.identity);//播放普通攻击特效
                        isEffect_normalEnd = false;
                    }
                }
                else if (time_attack < times_attack)
                {
                    PlayerInformation.playerInformation.playerState = PlayerState.Idle;
                }
                else
                {
                    time_attack = 0;
                    isEffect_normalEnd = true;
                }
                //方案二
            }
        }

        if (buff_attack)
        {
            applyTime_attack += Time.deltaTime;
            if (applyTime_attack >= applyTimes_attack)
            {
                playerInformation.Attack -= (int)addAttack;
                applyTime_attack = 0;
                buff_attack = false;
            }
        }

        if (buff_speed)
        {
            applyTime_speed += Time.deltaTime;
            if (applyTime_speed >= applyTimes_speed)
            {
                playerInformation.Speed -= (int)addSpeed;
                applyTime_speed = 0;
                buff_speed = false;
            }
        }

        //if (isSingleSkillReady && Input.GetMouseButtonDown(0))
        //{
        //    isGetKeyDown = true;
        //}
    }

    public void ReleaseSkill(SkillInfo info)
    {
        PlayerInformation.playerInformation.playerState = PlayerState.ReleaseSkill;
        //playerAnimation.GetSkillAnim(info.animName);
        switch (info.applyType)
        {
            case ApplyType.Passive:
                StartCoroutine(PassiveSkill(info));
                break;
            case ApplyType.Buff:
                StartCoroutine(BuffSkill(info));
                break;
            case ApplyType.SingleTarget:
                SingleTargetSkill(info);
                break;
            case ApplyType.MultiTarget:
                MultiTargetSkill(info);
                break;
            default:
                break;
        }
    }

    IEnumerator PassiveSkill(SkillInfo info)
    {
        GameObject efxPrefab = null;
        efxDictionary.TryGetValue(info.efx_name, out efxPrefab);
        GameObject.Instantiate(efxPrefab, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(info.animTime);
        PlayerInformation.playerInformation.playerState = PlayerState.Idle;
        if (info.applyProperty == ApplyProperty.HP)
        {
            playerInformation.AddHp(info.applyValue);
        }else if (info.applyProperty == ApplyProperty.MP)
        {
            playerInformation.AddMp(info.applyValue);
        }
    }

    IEnumerator BuffSkill(SkillInfo info)
    {
        GameObject efxPrefab = null;
        efxDictionary.TryGetValue(info.efx_name, out efxPrefab);
        GameObject.Instantiate(efxPrefab, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(info.animTime);
        PlayerInformation.playerInformation.playerState = PlayerState.Idle;
        if (info.applyProperty == ApplyProperty.Attack)
        {
            applyTimes_attack = info.applyTime;
            buff_attack = true;
            addAttack = playerInformation.Attack * info.applyValue;
            playerInformation.Attack += (int)addAttack;
        }else if (info.applyProperty == ApplyProperty.Speed)
        {
            applyTimes_speed = info.applyTime;
            buff_speed = true;
            addSpeed = playerInformation.Speed * info.applyValue;
            playerInformation.Speed += (int)addSpeed;
        }
    }

    public void GetTarget(Transform target)
    {
        hit = target;
    }

    public void SingleTargetSkill(SkillInfo info)
    {
        this.transform.LookAt(hit.position);
        GameObject efxPrefab = null;
        efxDictionary.TryGetValue(info.efx_name, out efxPrefab);
        GameObject.Instantiate(efxPrefab, hit.transform.position, Quaternion.identity);
        hit.transform.GetComponent<Enemy>().TakeDamage((int)info.applyValue * playerInformation.Attack);
        //hit.transform.GetComponent<Enemy>().hp -= info.applyValue * playerInformation.Attack;
    }

    public void MultiTargetSkill(SkillInfo info)
    {

    }
}
