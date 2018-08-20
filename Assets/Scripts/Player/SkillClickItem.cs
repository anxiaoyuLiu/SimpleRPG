using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillClickItem : MonoBehaviour {

    private SkillInfo skillInfo;
    private KeyCode key;
    private float coldTimes;
    private float coldTime = 0;
    private float speed;
    private PlayerInformation player;
    private PlayerAttack playerAttack;
    private PlayerInformation playerInformation;
    private float readyTimes = 3;
    private float readyTime = 0;

    public UILabel uILabel;
    public UISprite uISprite;
    public UISprite mask;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerInformation>();
        playerAttack= GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerAttack>();
        playerInformation = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerInformation>();
        speed = 1 / coldTimes;
    }

    private void Update()
    {
        if (player.Level >= skillInfo.level_lock)
        {
            if (Input.GetKeyDown(key) && mask.fillAmount == 0)
            {
                if (skillInfo.applyType == ApplyType.SingleTarget)
                {
                    //Debug.Log("Skill Ready...");
                    MouseType.mouseType.MouseSkill();
                    readyTime = readyTimes;
                }
                else if (skillInfo.applyType == ApplyType.MultiTarget)
                {
                    playerAttack.MultiTargetSkill(skillInfo);
                }
                else
                {
                    //1.获得mp
                    bool success = player.TakeMp(skillInfo.mp_pay);
                    if (success)
                    {
                        //2.释放技能
                        playerAttack.ReleaseSkill(skillInfo);
                        mask.fillAmount = 1;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            if (mask.fillAmount > 0)
            {
                mask.fillAmount -= Time.deltaTime * speed;
            }

            if (readyTime > 0)
            {
                playerAttack.skillReady = true;
                readyTime -= Time.deltaTime;
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    bool isHit = Physics.Raycast(ray, out hit);
                    if (hit.transform.tag == Tags.enemy)
                    {
                        //1.获得mp
                        bool success = player.TakeMp(skillInfo.mp_pay);
                        if (success)
                        {
                            //2.释放技能
                            playerAttack.GetTarget(hit.transform);
                            playerAttack.ReleaseSkill(skillInfo);
                            //hit.transform.GetComponent<Enemy>().hp -= skillInfo.applyValue * playerInformation.Attack;
                            mask.fillAmount = 1;
                            MouseType.mouseType.MouseNormal();
                            readyTime = 0;
                            playerAttack.skillReady = false;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        readyTime = 0;
                        MouseType.mouseType.MouseNormal();
                    }
                }
            }
            else
            {
                readyTime = 0;
                if (playerAttack.skillReady)
                {
                    //MouseType.mouseType.MouseNormal();
                }
                playerAttack.skillReady = false;
            }
        }
        else
        {
            mask.fillAmount = 1;
        }
    }

    public void GetById(int id)
    {
        skillInfo = SkillsInfo.skillsInfo.FindSkillInDictionary(id);
        coldTimes = skillInfo.coldTime;
        switch (id)
        {
            case 401:
                uILabel.text = "Q";
                key = KeyCode.Q;
                break;
            case 402:
                uILabel.text = "W";
                key = KeyCode.W;
                break;
            case 403:
                uILabel.text = "E";
                key = KeyCode.E;
                break;
            case 404:
                uILabel.text = "R";
                key = KeyCode.R;
                break;
            case 405:
                uILabel.text = "T";
                key = KeyCode.T;
                break;
            case 406:
                uILabel.text = "Y";
                key = KeyCode.Q;
                break;
            case 501:
                uILabel.text = "Q";
                key = KeyCode.Q;
                break;
            case 502:
                uILabel.text = "W";
                key = KeyCode.W;
                break;
            case 503:
                uILabel.text = "E";
                key = KeyCode.E;
                break;
            case 504:
                uILabel.text = "R";
                key = KeyCode.R;
                break;
            case 505:
                uILabel.text = "T";
                key = KeyCode.T;
                break;
            case 506:
                uILabel.text = "Y";
                key = KeyCode.Y;
                break;
            default:
                break;
        }
        uISprite.spriteName = skillInfo.icon_name;
    }
}
