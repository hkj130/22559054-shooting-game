using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
 
    public GameObject prefabsMonster;

    float nowTime;
    public float createTime = 1f;

    void Update()
    {
        nowTime = nowTime + Time.deltaTime;

        if (nowTime > createTime)
        {
            GameObject monster = Instantiate(prefabsMonster);
            monster.transform.position = transform.position;

            nowTime = 0;
        }
    }
}
