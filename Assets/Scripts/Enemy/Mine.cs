using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] float verticalDistance; //���� ������.
    [SerializeField] float horizontalDistance; //���� ������\

    [Range(0,1)]
    [SerializeField] float moveSpeed;

    [SerializeField] int damage = 1;
    [SerializeField] GameObject Effect;
    [SerializeField] int hp;

    Vector3 endPos1; //ù���� ������
    Vector3 endPos2; //�ι�° ������
    Vector3 currentDestination;

    private void Start()
    {
        Vector3 originPos = transform.position;
        endPos1.Set(originPos.x + horizontalDistance, originPos.y + verticalDistance, originPos.z);
        endPos2.Set(originPos.x - horizontalDistance, originPos.y - verticalDistance, originPos.z);
        currentDestination = endPos1;
    }


    private void Update()
    {
        //Debug.Log("������");
        if ((transform.position - endPos1).sqrMagnitude <= 0.2f) //Distance�� magintude�� �������Ӹ��ٿ����� ���ɻ� �Ҹ���
        {
            
            currentDestination = endPos2;
        }
        else if ((transform.position - endPos2).sqrMagnitude <= 0.2f) //Distance�� magintude�� �������Ӹ��ٿ����� ���ɻ� �Ҹ���
        {
            currentDestination = endPos1;
        }
            transform.position = Vector2.Lerp(transform.position, currentDestination, moveSpeed * Time.deltaTime);

    }

    bool isHit = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            
            if (isHit) return;
            isHit = true;
            Debug.Log("�ε���");
            collision.transform.GetComponent<StatsManager>().DecreaseHp(damage);
            Explosion();
        }
        
        
        //���⼭�� ���� �������� �ް��ص� ������ �ҷ���ũ��Ʈ���� �ϸ� �����σ����ԾӤ���?
        //���⼭�� �Ѿ˵������� �ٸ��� �� �޾ƾ��ϱ⿡ �ҷ����� ����

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Bim"))
        {
            Explosion();

        }
    }
    void issHit()
    {
        isHit = false;
    }
    public void Damage(int _num)
    {
        hp -= _num;
        if (hp <= 0)
            Explosion();


    }



    void Explosion()
    {
       
        var clone = Instantiate(Effect, transform.position, Quaternion.identity);

        
        gameObject.SetActive(false);
        Destroy(clone, 0.5f);
    }

    //private void OnDisable()
    //{
    //    PoolManager.ReturnToPool(gameObject);
        
    //}
}
