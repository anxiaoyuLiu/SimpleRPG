using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseType : MonoBehaviour {

    public static MouseType mouseType;

    public Texture2D Normal;
    public Texture2D Talk;
    public Texture2D Attack;
    public Texture2D Skill;
    public Texture2D Pick;

    private Vector2 hotspot = Vector2.zero;//光标，指针点击的目标点
    private CursorMode cursorMode = CursorMode.Auto;//设置光标的选择方式，（设成自动就行）

    private void Awake()
    {
        mouseType = this;
    }

    public void MouseNormal()
    {
        Cursor.SetCursor(Normal, hotspot, cursorMode);
    }

    public void MouseTalk()
    {
        Cursor.SetCursor(Talk, hotspot, cursorMode);
    }

    public void MouseAttack()
    {
        Cursor.SetCursor(Attack, hotspot, cursorMode);
    }

    public void MouseSkill()
    {
        Cursor.SetCursor(Skill, hotspot, cursorMode);
    }
}
