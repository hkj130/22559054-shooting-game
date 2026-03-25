using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterRandom : MonoBehaviour
{
    public GameObject prefabsMoster;

    float nowTime;
    float minTime = 1f;
    float maxTime = 5f;

    public float createTime = 1f;

    private void Start()
    {
        createTime = Random.Range(minTime, maxTime);    
    }

    // Update is called once per frame
    void Update()
    {
        nowTime = nowTime + Time.deltaTime;

        if (nowTime > createTime)
        {
            GameObject monster = Instantiate(prefabsMoster);
            monster.transform.position = transform.position;

            createTime = Random.Range(minTime, maxTime);
        }
    }
}
