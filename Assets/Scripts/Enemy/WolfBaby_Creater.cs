using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfBaby_Creater : MonoBehaviour {

    public GameObject prefab;
    public int maxNumber = 7;
    public int number_now;
    public float creatTimes;// = 6;
    public float creatTime;// = 0;
    private Vector3 pos;

    private void Update()
    {
        if (number_now < maxNumber)
        {
            creatTime += Time.deltaTime;
            if (creatTime > creatTimes)
            {
                pos = transform.position;
                pos.x += Random.Range(-2, 2);
                pos.z += Random.Range(-2, 2);
                GameObject.Instantiate(prefab, pos, Quaternion.identity);
                number_now++;
                creatTime = 0;
            }
        }
    }
}
