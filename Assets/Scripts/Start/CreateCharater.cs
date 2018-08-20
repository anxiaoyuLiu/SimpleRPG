using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateCharater : MonoBehaviour {

    public GameObject[] charaterPrefabs;
    public UIInput nameInput;
    public UILabel nameLabel;
    private GameObject[] charaters;
    private int length;
    private int selectIndex = 0;

    private void Awake()
    {
        length = charaterPrefabs.Length;
        charaters = new GameObject[length];

        for (int i = 0; i < length; i++)
        {
            charaters[i] = GameObject.Instantiate(charaterPrefabs[i], transform.position, transform.rotation);
        }
        UpdateCharaterShow();
    }

    private void UpdateCharaterShow()
    {
        for (int i = 0; i < length; i++)
        {
            if (i == selectIndex)
            {
                charaters[i].SetActive(true);
            }
            else
            {
                charaters[i].SetActive(false);
            }
        }
    }

    public void OnNextButtonClick()
    {
        selectIndex++;
        selectIndex %= length;
        UpdateCharaterShow();
    }

    public void OnPrevButtonClick()
    {
        selectIndex--;
        selectIndex %= length;
        if (selectIndex < 0)
        {
            selectIndex = length - 1;
        }
        UpdateCharaterShow();
    }

    public void OnOKButtonClick()
    {
        PlayerPrefs.SetInt("SelectIndex", selectIndex);
        PlayerPrefs.SetString("Name", nameInput.value);
        PlayerPrefs.SetInt("Level", 1);
        if (nameLabel.text!= "点击输入角色昵称"&&nameLabel.text!=null)
        {
            SceneManager.LoadScene(2);
        }
    }
}
