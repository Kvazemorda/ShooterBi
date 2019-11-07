using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreTable : MonoBehaviour
{
    private GameObject scoreContainer;
    private void Awake()
    {
        scoreContainer = GameObject.Find("ScoreContainer");
      //  scoreContainer.gameObject.SetActive(false);
       

  //      float templateHeight = 80f;
  //      GameObject entryTransform = Instantiate(scoreContainer);
   //     entryTransform.transform.position = 
    //        new Vector3(entryTransform.transform.position.x, entryTransform.transform.position.y - templateHeight, entryTransform.transform.position.z);

     //   scoreContainer.gameObject.SetActive(true);
    //    entryTransform.gameObject.SetActive(true);
    }
}
