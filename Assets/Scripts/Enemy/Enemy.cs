using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WolfState
{
    Idle,
    Walk,
    Attack,
    Death
}

public class Enemy : MonoBehaviour {

    public WolfState state = WolfState.Idle;
    public float hp;

    protected GameObject Target;
    protected Animation anim;
    protected string stateNow;
    protected CharacterController controller;
    protected bool isAttacked = false;
    protected Color normal;
    protected GameObject HUD;
    protected HUDText HUDText;
    protected bool findPlayer = false;
    protected PlayerInformation playerInformation;
    protected PlayerAttack playerAttack;
    protected OldMan oldMan;

    public virtual void TakeDamage(int attack)
    {

    }
}
