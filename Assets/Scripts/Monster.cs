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
        // 타겟이 설정되어 있다면 타겟 방향으로, 없으면 아래로
        if (target != null)
        {
            direct = (target.transform.position - transform.position).normalized;
        }
    }

    void Update()
    {
        transform.position += direct * spd * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 1. 총알에 부딪힌 경우에만 실행되는 구간
        if (collision.gameObject.CompareTag("Bullet"))
        {
            GameObject gameManager = GameObject.Find("ScoreManager"); // 이름 주의!
            if (gameManager != null)
            {
                ScoreManager scoreManager = gameManager.GetComponent<ScoreManager>();
                if (scoreManager != null)
                {
                    scoreManager.nowScore++;
                    scoreManager.nowScoreUI.text = "Now Score : " + scoreManager.nowScore;

                    if (scoreManager.nowScore > scoreManager.bestScore)
                    {
                        scoreManager.bestScore = scoreManager.nowScore;
                        scoreManager.bestScoreUI.text = "Best Score : " + scoreManager.bestScore;
                        PlayerPrefs.SetInt("BestScore", scoreManager.bestScore);
                    }
                }
            }

            if (prefabsExplosion != null)
            {
                Instantiate(prefabsExplosion, transform.position, Quaternion.identity);
            }

            // 총알 삭제 (몬스터 삭제는 맨 아래 공통 구간에서 처리)
            Destroy(collision.gameObject);
        }

        // 2. [사용자님 요청] 어떤 충돌이든 발생하면 몬스터 자신을 삭제
        // if문 바깥에 있으므로 총알이든 벽이든 부딪히면 무조건 실행됩니다.
        Destroy(gameObject);
    }
}