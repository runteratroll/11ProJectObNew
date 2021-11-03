using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("피격 이벤트")]
    [SerializeField] GameObject go_RicocheEffect;

    [Header("총알 데미지")]
    [SerializeField] int damage;

    [Header("피격 효과음")]
    [SerializeField] string sound_Ricochet;





    private void Start()
    {
        Invoke(nameof(DeactiveDelay), 5f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contactPoint2D = collision.contacts[0]; //가장 가까운 접촉면
                                                               //충돌한 객체의 '접촉면'에 대한 정보가 담긴 클래스 충돌한 객체의 접촉면 정보가 담김
        //SoundManager.instance.PlaySE("NormalGun_Recochet"); //레이저총이라면 이효과음이 나므로 변해하 하면 변수
        var RecochetClone = Instantiate(go_RicocheEffect, contactPoint2D.point, Quaternion.LookRotation(contactPoint2D.normal));
            //PoolManager.SpawnFromPool("NomalGunRecoachEvent_k", contactPoint2D.point, Quaternion.LookRotation(contactPoint2D.normal));

        //충돌한 컬라이더 표면상의 Position 좌표 //특정방향을 바라보게 만드는 메서드 normal 충돌한 컬라이더의 표면방향
        if (collision.transform.CompareTag("Mine"))
        {
            collision.transform.GetComponent<Mine>().Damage(damage);
        }
        //Invoke(nameof(ReChoChet), 0.5f);

        Destroy(RecochetClone, 0.5f);
        DeactiveDelay();
        //PoolManager.ReturnToPool(gameObject);
        
    }
    void DeactiveDelay() => gameObject.SetActive(false);


    //private void ReChoChet()
    //{
    //    RecochetClone.SetActive(false);
    //    PoolManager.ReturnToPool(RecochetClone);
    //    CancelInvoke();
    //}
    private void OnDisable()
    {
        PoolManager.ReturnToPool(gameObject);
        CancelInvoke();
    }
}
