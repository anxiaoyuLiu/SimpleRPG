using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead : MonoBehaviour {


    public void OnReturnButtonClick()
    {
        SceneManager.LoadScene(2);
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
}
