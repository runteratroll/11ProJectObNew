using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("�ǰ� �̺�Ʈ")]
    [SerializeField] GameObject go_RicocheEffect;

    [Header("�Ѿ� ������")]
    [SerializeField] int damage;

    [Header("�ǰ� ȿ����")]
    [SerializeField] string sound_Ricochet;





    private void Start()
    {
        Invoke(nameof(DeactiveDelay), 5f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contactPoint2D = collision.contacts[0]; //���� ����� ���˸�
                                                               //�浹�� ��ü�� '���˸�'�� ���� ������ ��� Ŭ���� �浹�� ��ü�� ���˸� ������ ���
        //SoundManager.instance.PlaySE("NormalGun_Recochet"); //���������̶�� ��ȿ������ ���Ƿ� ������ �ϸ� ����
        var RecochetClone = Instantiate(go_RicocheEffect, contactPoint2D.point, Quaternion.LookRotation(contactPoint2D.normal));
            //PoolManager.SpawnFromPool("NomalGunRecoachEvent_k", contactPoint2D.point, Quaternion.LookRotation(contactPoint2D.normal));

        //�浹�� �ö��̴� ǥ����� Position ��ǥ //Ư�������� �ٶ󺸰� ����� �޼��� normal �浹�� �ö��̴��� ǥ�����
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
