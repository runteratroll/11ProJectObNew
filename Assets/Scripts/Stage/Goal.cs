using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Goal : MonoBehaviour
{

    [SerializeField] StageManager theSM;


    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("Player"))
        {
            SoundManager.instance.PlaySE("Goal");
            theSM.ShowClearUI();
        }
    }

}
