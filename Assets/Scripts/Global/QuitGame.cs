using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour {

    public GameObject Quit;
    public GameObject gameSetting;

    private GameLoad gameLoad;

    private void Start()
    {
        gameLoad = gameSetting.GetComponent<GameLoad>();
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }

    public void OnCancelButtonClick()
    {
        Quit.SetActive(false);
        gameLoad.isShow = false;
    }
}
