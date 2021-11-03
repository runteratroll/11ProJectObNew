using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{

    [SerializeField] int damage;

    [SerializeField] float force; //튕겨나가는 힘
    bool isHit = false;
    

    //플레이어 hp를 인스턴스화합시다 싱글 모노톤 만들고 게임매니저에서 유저hp나 무기그거를 선언하면 되지 않을까?
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            if (isHit) return;
            isHit = true;
            //ContactPoint2D contactPoint2D = collision.contacts[0];
            Debug.Log("데미지를 입음 윽 엑 윽");
            

            collision.transform.GetComponent<Rigidbody2D>().AddExplosionForce(force, transform.position, 5f); //폭발반경
            collision.transform.GetComponent<StatsManager>().DecreaseHp(damage);
            gameObject.SetActive(false);
        }
    }
}
