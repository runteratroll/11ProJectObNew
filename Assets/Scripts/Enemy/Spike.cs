using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{

    [SerializeField] int damage;

    [SerializeField] float force; //ƨ�ܳ����� ��
    bool isHit = false;
    

    //�÷��̾� hp�� �ν��Ͻ�ȭ�սô� �̱� ����� ����� ���ӸŴ������� ����hp�� ����װŸ� �����ϸ� ���� ������?
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            if (isHit) return;
            isHit = true;
            //ContactPoint2D contactPoint2D = collision.contacts[0];
            Debug.Log("�������� ���� �� �� ��");
            

            collision.transform.GetComponent<Rigidbody2D>().AddExplosionForce(force, transform.position, 5f); //���߹ݰ�
            collision.transform.GetComponent<StatsManager>().DecreaseHp(damage);
            gameObject.SetActive(false);
        }
    }
}
