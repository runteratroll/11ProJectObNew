using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Last : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Clear;
    [SerializeField] GameObject  ddd;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            
            ddd.SetActive(true);
            Clear.text = "WOw you are Clear! hahaha Maybe...";
        }
    }
}
