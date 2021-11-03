
using UnityEngine;
using System;


public class Block : MonoBehaviour
{

    public event Action OnBeingHit; //event Action 알기


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(OnBeingHit != null)
        {
            OnBeingHit(); //맞았을떄 호출;
        }


        gameObject.SetActive(false);
    }
}
