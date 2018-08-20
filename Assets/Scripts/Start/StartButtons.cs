using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtons : MonoBehaviour {

	public void OnNewGameButtonClick()
    {
        //加载新的游戏场景
        PlayerPrefs.SetInt("DataFromSave", 0);
        SceneManager.LoadScene(1);
    }

    public void OnLoadGameButtonClick()
    {
        //加载已经保存的游戏场景
        PlayerPrefs.SetInt("DataFromSave", 1);
        SceneManager.LoadScene(2);
    }
}
