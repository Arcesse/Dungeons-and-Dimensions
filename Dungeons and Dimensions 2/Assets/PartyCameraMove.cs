using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PartyCameraMove : MonoBehaviour
{
   [SerializeField] List<GameObject> charactersInParty;
   [SerializeField] CinemachineVirtualCamera cameraObject;

   [SerializeField] GameObject enemiesHolder;
   private List<Enemy> enemies;
   public GameObject[] enemyObjects;

   private int charaTurn;
   private int lockedEnemy;

   void Start()
   {
    if(enemies == null)
    {
        enemies = new List<Enemy>();
    }

    charaTurn = 0;
    lockedEnemy = 0;

    enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
    if(enemyObjects.Length != 0)
    {
        foreach(GameObject enemyGo in enemyObjects)
        {
            Enemy e = enemyGo.GetComponent<Enemy>();
            enemies.Add(e);
        }
    }

    cameraObject.Follow = charactersInParty[0].transform;
    //cameraObject.LookAt = enemyObjects[0].transform;
   }

   void Update()
   {
    if(Input.GetKeyDown(KeyCode.X))
    {
        ChangeCharaCamera();
    }

    if(Input.GetKeyDown(KeyCode.Q))
    {
        ChangeEnemyLookAt();
    }
   }


    public void ChangeCharaCamera()
    {
        if(charaTurn < charactersInParty.Count - 1)
        {
            charaTurn += 1;
        }
        else
        {
            charaTurn = 0;
        }

        Debug.Log($"{charaTurn}");

        cameraObject.Follow = charactersInParty[charaTurn].transform;
    }

    public void ChangeEnemyLookAt()
    {
        if(lockedEnemy < enemyObjects.Length - 1)
        {
            lockedEnemy += 1;
        }
        else
        {
            lockedEnemy = 0;
        }

        Debug.Log($"{lockedEnemy}");

        cameraObject.LookAt = enemyObjects[lockedEnemy].transform;
    }
}
