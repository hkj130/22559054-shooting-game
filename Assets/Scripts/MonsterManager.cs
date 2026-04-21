using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public GameObject prefabsMonster;
    float nowTime;
    public float minTime = 1f;
    public float maxTime = 5f;
    float createTime;

    void Start()
    {
        createTime = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        nowTime += Time.deltaTime;

        if (nowTime > createTime)
        {
            GameObject monster = Instantiate(prefabsMonster, transform.position, prefabsMonster.transform.rotation);

            Monster monsterScript = monster.GetComponent<Monster>();
            monsterScript.target = GameObject.Find("Character");

            nowTime = 0;
            createTime = Random.Range(minTime, maxTime);
        }
    }
}