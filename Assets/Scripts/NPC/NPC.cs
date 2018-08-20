using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    private void OnMouseEnter()
    {
        MouseType.mouseType.MouseTalk();
    }

    private void OnMouseExit()
    {
        MouseType.mouseType.MouseNormal();
    }
}
