using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKey : MonoBehaviour {

    private bool anyKeyDown = false;
    private GameObject StartButtons;

	void Start () {
        StartButtons = this.transform.parent.Find("StartButtons").gameObject;
	}
	

	void Update () {
        if (!anyKeyDown)
        {
            ShowButton();
        }
	}

    private void ShowButton()
    {
        if (Input.anyKey)
        {
            anyKeyDown = true;
            this.gameObject.SetActive(false);
            StartButtons.SetActive(true);
        }
    }
}
