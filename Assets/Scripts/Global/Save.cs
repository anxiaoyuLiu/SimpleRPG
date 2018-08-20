using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour {

    public bool isSaving = false;
    public GameObject SaveUI;
    private GameObject player;
    private PlayerInformation playerInformation;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player);
        playerInformation = player.GetComponent<PlayerInformation>();
    }

    private void Update()
    {
        if (isSaving)
        {
            SaveUI.SetActive(true);
        }
        else
        {
            SaveUI.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.player)
        {
            isSaving = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == Tags.player)
        {
            isSaving = false;
        }
    }

    public void OnAcceptButtonClick()
    {
        if (playerInformation.heroType == HeroType.magician)
        {
            PlayerPrefs.SetInt("SelectIndex", 0);
        }
        else if(playerInformation.heroType == HeroType.Swordman)
        {
            PlayerPrefs.SetInt("SelectIndex", 1);
        }
        PlayerPrefs.SetInt("DataFromSave", 1);
        PlayerPrefs.SetString("Name", playerInformation.PlayerName);
        PlayerPrefs.SetInt("Level", playerInformation.Level);
        PlayerPrefs.SetInt("Exp", playerInformation.Exp);
        PlayerPrefs.SetInt("Coin", playerInformation.Coin);
        PlayerPrefs.SetInt("Attack", playerInformation.Attack);
        PlayerPrefs.SetInt("Defence", playerInformation.Defence);
        PlayerPrefs.SetInt("Speed", playerInformation.Speed);
        PlayerPrefs.SetInt("Point", playerInformation.Point);
        isSaving = false;
    }

    public void OnCancelButtonClick()
    {
        isSaving = false;
    }
}
