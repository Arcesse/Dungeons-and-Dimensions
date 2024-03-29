using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeamManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int enemyCount;

    private float spreadCalc;

    void Awake()
    {
        for(int i = 0; i < enemyCount; i++)
        {
            if(i % 2 == 0)
            {
                spreadCalc = (Mathf.Pow(-1, i) * 2) * i;
            }
            else
            {
                spreadCalc = (Mathf.Pow(-1, i) * 2) * (i + 1);
            }

             
            Vector3 enemyPos = new Vector3(0, 0, spreadCalc);
            GameObject enemyGo = Instantiate(enemyPrefab, gameObject.transform, false);
            enemyGo.transform.localPosition = enemyPos;
        }
    }
}
