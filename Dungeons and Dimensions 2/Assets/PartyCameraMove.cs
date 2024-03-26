using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PartyCameraMove : MonoBehaviour
{
   [SerializeField] List<GameObject> charactersInParty;
   [SerializeField] CinemachineVirtualCamera cameraObject;

   private int charaTurn;

   void Start()
   {
    charaTurn = 0;
   }

   void Update()
   {
    if(Input.GetKeyDown(KeyCode.X))
    {
        ChangeCharaCamera();
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
        //cameraObject.LookAt = charactersInParty[charaTurn].transform;
    }
}
