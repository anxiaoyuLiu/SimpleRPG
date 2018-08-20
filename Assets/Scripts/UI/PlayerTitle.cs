using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTitle : MonoBehaviour {

    private UILabel Name;
    private UISlider HPSlider;
    private UISlider MPSlider;
    private PlayerInformation player;

    private void Awake()
    {
        Name = transform.Find("Name").GetComponentInChildren<UILabel>();
        HPSlider = transform.Find("HP").GetComponent<UISlider>();
        MPSlider = transform.Find("MP").GetComponent<UISlider>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInformation>();
        UpdatePlayerMessage();
    }
    private void Update()
    {
        UpdatePlayerMessage();
    }
    private void UpdatePlayerMessage()
    {
        Name.text = "LV." + player.Level + "  " + player.PlayerName;
        HPSlider.value = player.HP / player.HP_max;
        MPSlider.value = player.MP / player.MP_max;
    }
}
