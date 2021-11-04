using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtoTerret : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] GameObject BulletFrefab;
    GameObject clone;
    [SerializeField] float Range = 5f;
    public LayerMask layerMask;
    Collider2D contect;
    [SerializeField] float delay;
    Vector3 dir;

    public int damage = 1;
    private void Update()
    {
        
    }

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.GetComponent<StatsManager>().DecreaseHp(damage);
        }
    }

    IEnumerator Shoot()
    {
        while (true)
        {

            contect = Physics2D.OverlapCircle(transform.position, Range, layerMask);

            if (contect)
            {
                dir = contect.transform.position - transform.position;

                clone = PoolManager.SpawnFromPool("OtoBullet", transform.position, Quaternion.identity);

                clone.GetComponent<Rigidbody2D>().AddForce(dir * speed, ForceMode2D.Impulse);
                //clone.GetComponent<Rigidbody2D>().AddForce(transform.right * speed, ForceMode2D.Impulse);
                yield return new WaitForSeconds(delay);
            }
            yield return null;
        }
        
    }
}
