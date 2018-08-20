using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoad : MonoBehaviour {

    public GameObject Magician;
    public GameObject Swordman;
    public GameObject Quit;
    public GameObject Dead;

    private int selectIndex;
    public GameObject player;
    public bool isShow = false;

    private PlayerInformation playerInformation;

    private void Awake()
    {
        int dataFrom = PlayerPrefs.GetInt("DataFromSave");
        if (dataFrom == 0)
        {
            selectIndex = PlayerPrefs.GetInt("SelectIndex");

            if (selectIndex == 0)
            {
                player = GameObject.Instantiate(Magician);
            }
            else if (selectIndex == 1)
            {
                player = GameObject.Instantiate(Swordman);
            }

            player.GetComponent<PlayerInformation>().PlayerName = PlayerPrefs.GetString("Name");
        }
        else
        {
            selectIndex = PlayerPrefs.GetInt("SelectIndex");
            if (selectIndex == 0)
            {
                player = GameObject.Instantiate(Magician);
            }
            else if (selectIndex == 1)
            {
                player = GameObject.Instantiate(Swordman);
            }

            player.GetComponent<PlayerInformation>().PlayerName = PlayerPrefs.GetString("Name");
            player.GetComponent<PlayerInformation>().Level = PlayerPrefs.GetInt("Level");
            player.GetComponent<PlayerInformation>().Exp = PlayerPrefs.GetInt("Exp");
            player.GetComponent<PlayerInformation>().Coin = PlayerPrefs.GetInt("Coin");
            player.GetComponent<PlayerInformation>().Attack = PlayerPrefs.GetInt("Attack");
            player.GetComponent<PlayerInformation>().Defence = PlayerPrefs.GetInt("Defence");
            player.GetComponent<PlayerInformation>().Speed = PlayerPrefs.GetInt("Speed");
            player.GetComponent<PlayerInformation>().Point = PlayerPrefs.GetInt("Point");
        }
    }

    private void Start()
    {
        playerInformation = player.GetComponent<PlayerInformation>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&!isShow)
        {
            Quit.SetActive(true);
            isShow = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            Quit.SetActive(false);
            isShow = false;
        }

        if (playerInformation.HP <= 0)
        {
            Dead.SetActive(true);
        }
    }
}
