using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float spd = 1.0f;

    public GameObject target;
    public GameObject prefabsExplosion;

    Vector3 direct = Vector3.down;

    private void Start()
    {
        int rndMum = Random.Range(0, 10);
        if (rndMum % 3 == 0)
        {
            direct = target.transform.position - transform.position;
            direct.Normalize();
        }
    }

    void Update()
    {
        transform.position = transform.position + direct * spd * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GameObject gameManager = GameObject.Find("GameManager");
            ScoreManager scoreManager = gameManager.GetComponent<ScoreManager>();
            scoreManager.nowScore++;
            scoreManager.nowScoreUI.text = "Now Score : " + scoreManager.nowScore;

            if(scoreManager.nowScore > scoreManager.bestScore)
            {
                scoreManager.bestScore = scoreManager.nowScore;
                scoreManager.bestScoreUI.text = "best Score : " + scoreManager.bestScore;

                PlayerPrefs.SetInt("BestScore", scoreManager.bestScore);
            }

            GameObject explosionObj = Instantiate(prefabsExplosion);
            explosionObj.transform.position = transform.position;

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        Destroy(collision.gameObject);

        Destroy(gameObject);
    }
}