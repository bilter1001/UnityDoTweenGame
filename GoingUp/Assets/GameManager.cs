using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public GameObject groundPrefab;
    public GameObject goalPrefab;
    public int spawnAmount;
    public Vector2 step = new Vector2(4.25f, 7.5f);

    // Start is called before the first frame update

    void Start()
    {
        SpawnNewWave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SpawnNewWave()
    {
        Vector2 spawnPos = Vector2.zero;

        for (int i = 0; i < spawnAmount; i++)
        {
            int ramdomDir = Random.Range(0f, 1f) > 0.5f ? 1 : -1;
            spawnPos += new Vector2(step.x * ramdomDir, step.y);

            GameObject ground = new GameObject();
            if (i != spawnAmount - 1)
            {
                //Ground
                //先生成到目标位置往下2个单位，然后再使用动画补齐到目标位置
                ground = Instantiate(groundPrefab, spawnPos - Vector2.up * 2f, Quaternion.identity); 

            }
            else
            {
                //Goal
                ground = Instantiate(goalPrefab, spawnPos - Vector2.up * 2f, Quaternion.identity);
            }

            ground.transform.parent = transform;
            ground.transform.DOMove(ground.transform.position + Vector3.up * 2f, 0.5f).SetDelay(i*0.1f);
        }

    }
}
