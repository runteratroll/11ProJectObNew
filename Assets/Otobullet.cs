using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otobullet : MonoBehaviour
{
    [SerializeField] public int damage;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            collision.transform.GetComponent<StatsManager>().DecreaseHp(damage);
        }
        if(collision.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Block"))
        {
            gameObject.SetActive(false);
        }

    }

 
    private void Update()
    {
        
    }

    private void Start()
    {

    }

    void Ree()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        PoolManager.ReturnToPool(gameObject);
    }
}
