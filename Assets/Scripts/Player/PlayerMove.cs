using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour {

    public GameObject clickEffect;
    //public PlayerState state = PlayerState.Idle;
    public Vector3 targetPosition;
    //public string targetTag;
    //public GameObject target;

    private bool isChange = false;//鼠标点击位置是否发生变化
    private CharacterController character;
    private float distance;
    private float speed = 3f;
    private PlayerInformation playerInformation;
    private PlayerAttack playerAttack;

    private void Start()
    {
        character = transform.GetComponent<CharacterController>();
        targetPosition = transform.position;
        playerInformation = transform.GetComponent<PlayerInformation>();
        //targetTag = Tags.ground;
        playerAttack = transform.GetComponent<PlayerAttack>();
        //target = this.gameObject;
    }

    private void Update()
    {
        //Debug.Log(playerInformation.playerState);
        if (playerInformation.HP <= 0)
        {
            playerInformation.playerState = PlayerState.Death;
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && UICamera.isOverUI == false)
            {
                //Debug.Log(UICamera.hoveredObject);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitinfo;
                bool isHit = Physics.Raycast(ray, out hitinfo);
                if (isHit && hitinfo.collider.tag == Tags.ground)
                {
                    targetPosition = hitinfo.point;
                    //targetTag = Tags.ground;
                    CreateEffect(hitinfo.point);
                    Look(hitinfo.point);
                    isChange = true;
                    playerAttack.isAttack = false;
                    playerAttack.target = this.transform;
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isChange = false;
            }

            if (isChange)//鼠标保持按下状态，角色的转向
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitinfo;
                bool isHit = Physics.Raycast(ray, out hitinfo);
                if (isHit && hitinfo.collider.tag == Tags.ground)
                {
                    targetPosition = hitinfo.point;
                    //targetTag = Tags.ground;
                    Look(hitinfo.point);
                    //playerAttack.isAttack = false;
                }
            }
            if (playerAttack.isAttack == false)
            {
                distance = Vector3.Distance(transform.position, targetPosition);
                if (distance > 0.3f)
                {
                    Move(targetPosition);
                    //state = PlayerState.Moving;
                    PlayerInformation.playerInformation.playerState = PlayerState.Moving;
                }
                else
                {
                    //state = PlayerState.Idle;
                    PlayerInformation.playerInformation.playerState = PlayerState.Idle;
                }
            }
        }
    }

    private void CreateEffect(Vector3 hitposition)
    {
        hitposition = new Vector3(hitposition.x, hitposition.y + 0.1f, hitposition.z);
        GameObject.Instantiate(clickEffect, hitposition, Quaternion.identity);
    }

    public void Look(Vector3 targetpos)
    {
        targetPosition = new Vector3(targetpos.x, transform.position.y, targetpos.z);
        transform.LookAt(targetPosition);
    }

    public void Move(Vector3 targetpos)
    {
        Look(targetpos);
        targetpos = new Vector3(targetpos.x, transform.position.y, targetpos.z);
        float speed_now = speed + playerInformation.Speed * 0.01f;
        character.SimpleMove(transform.forward * speed_now);
        //Debug.Log(targetpos);
    }
}
