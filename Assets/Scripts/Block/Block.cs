
using UnityEngine;
using System;


public class Block : MonoBehaviour
{

    public event Action OnBeingHit; //event Action �˱�


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(OnBeingHit != null)
        {
            OnBeingHit(); //�¾����� ȣ��;
        }


        gameObject.SetActive(false);
    }
}
