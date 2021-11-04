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
        if(collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Last"))
        {
            
            ddd.SetActive(true);
            Clear.text = "WOw you are Clear! hahaha Maybe...";


            Invoke(nameof(Osdsd), 5f);
        }

        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Last2"))
        {

            ddd.SetActive(true);
            Clear.text = "You You You good!";


            Invoke(nameof(Osdsd), 5f);
        }
    }


    void Osdsd()
    {
        ddd.SetActive(false);
    }
}
