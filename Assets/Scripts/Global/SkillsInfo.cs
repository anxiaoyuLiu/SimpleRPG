using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//适用角色类型
public enum ApplicionType
{
    Swordman,
    magician
}

//作用类型
public enum ApplyType
{
    Passive,
    Buff,
    SingleTarget,
    MultiTarget
}

//作用属性
public enum ApplyProperty
{
    Attack,
    Defence,
    Speed,
    ColdTime,
    HP,
    MP
}

//释放类型
public enum ReleaseType
{
    Self,
    Enemy,
    Position
}

//技能属性
public class SkillInfo
{
    public int id;
    public string name;
    public string icon_name;
    public string des;
    public ApplyType applyType;
    public ApplicionType applicionType;
    public float applyValue;
    public int applyTime;
    public int mp_pay;
    public int coldTime;
    public ApplyProperty applyProperty;
    public int level_lock;
    public ReleaseType releaseType;
    public float distance;
    public string efx_name;
    public string animName;
    public float animTime = 0;
}

public class SkillsInfo : MonoBehaviour {

    public static SkillsInfo skillsInfo;
    public TextAsset SkillsInfoText;

    //private SkillInfo skill;
    private Dictionary<int, SkillInfo> SkillDictionary = new Dictionary<int, SkillInfo>();

    private void Awake()
    {
        skillsInfo = this;
        GetSkillInformation();
    }

    private void Update()//For test
    {
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    SkillInfo skill = FindSkillInDictionary(504);
        //    Debug.Log(skill.name);
        //}
    }

    public SkillInfo FindSkillInDictionary(int id)
    {
        SkillInfo skill = null;
        SkillDictionary.TryGetValue(id, out skill);
        return skill;
    }

    private void GetSkillInformation()
    {
        string text = SkillsInfoText.text;
        string[] skillArray = text.Split('\n');

        foreach (string skill in skillArray)
        {
            SkillInfo skillInfo = new SkillInfo();
            string[] skillInfoArray = skill.Split(',');

            skillInfo.id = int.Parse(skillInfoArray[0]);
            skillInfo.name = skillInfoArray[1];
            skillInfo.icon_name = skillInfoArray[2];
            skillInfo.des = skillInfoArray[3];
            skillInfo.applyValue = float.Parse(skillInfoArray[6]);
            skillInfo.applyTime = int.Parse(skillInfoArray[7]);
            skillInfo.mp_pay = int.Parse(skillInfoArray[8]);
            skillInfo.coldTime = int.Parse(skillInfoArray[9]);
            skillInfo.level_lock = int.Parse(skillInfoArray[11]);
            skillInfo.distance = float.Parse(skillInfoArray[13]);
            skillInfo.efx_name = skillInfoArray[14];
            skillInfo.animName = skillInfoArray[15];
            skillInfo.animTime = float.Parse(skillInfoArray[16]);

            string applyType = skillInfoArray[4];

            switch (applyType)
            {
                case "Buff":
                    skillInfo.applyType = ApplyType.Buff;
                    break;
                case "MultiTarget":
                    skillInfo.applyType = ApplyType.MultiTarget;
                    break;
                case "Passive":
                    skillInfo.applyType = ApplyType.Passive;
                    break;
                case "SingleTarget":
                    skillInfo.applyType = ApplyType.SingleTarget;
                    break;
            }

            string applyProperty = skillInfoArray[5];

            switch (applyProperty)
            {
                case "Attack":
                    skillInfo.applyProperty = ApplyProperty.Attack;
                    break;
                case "Speed":
                    skillInfo.applyProperty = ApplyProperty.Speed;
                    break;
                case "ColdTime":
                    skillInfo.applyProperty = ApplyProperty.ColdTime;
                    break;
                case "Defence":
                    skillInfo.applyProperty = ApplyProperty.Defence;
                    break;
                case "HP":
                    skillInfo.applyProperty = ApplyProperty.HP;
                    break;
                case "MP":
                    skillInfo.applyProperty = ApplyProperty.MP;
                    break;
            }

            string applicionType = skillInfoArray[10];

            switch (applicionType)
            {
                case "magician":
                    skillInfo.applicionType = ApplicionType.magician;
                    break;
                case "Sworldman":
                    skillInfo.applicionType = ApplicionType.Swordman;
                    break;
            }

            string releaseType = skillInfoArray[12];

            switch (releaseType)
            {
                case "Enemy":
                    skillInfo.releaseType = ReleaseType.Enemy;
                    break;
                case "Position":
                    skillInfo.releaseType = ReleaseType.Position;
                    break;
                case "Self":
                    skillInfo.releaseType = ReleaseType.Self;
                    break;
            }
            SkillDictionary.Add(skillInfo.id, skillInfo);
            //Debug.Log(skillInfo.name);
        }
    }
}
