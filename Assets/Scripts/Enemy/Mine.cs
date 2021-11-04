using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] float verticalDistance; //수직 움직임.
    [SerializeField] float horizontalDistance; //수평 움직임\

    [Range(0,1)]
    [SerializeField] float moveSpeed;

    [SerializeField] int damage = 1;
    [SerializeField] GameObject Effect;
    [SerializeField] int hp;

    Vector3 endPos1; //첫번쨰 목적지
    Vector3 endPos2; //두번째 목적지
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
        //Debug.Log("움직임");
        if ((transform.position - endPos1).sqrMagnitude <= 0.2f) //Distance나 magintude는 매프레임마다에서는 성능상 불리함
        {
            
            currentDestination = endPos2;
        }
        else if ((transform.position - endPos2).sqrMagnitude <= 0.2f) //Distance나 magintude는 매프레임마다에서는 성능상 불리함
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
            Debug.Log("부딪힘");
            collision.transform.GetComponent<StatsManager>().DecreaseHp(damage);
            Explosion();
        }
        
        
        //여기서도 지뢰 데미지를 받게해도 되지만 불렛스크립트에서 하면 관리하깋편함앙ㅁ도?
        //여기서는 총알데미지가 다를시 또 받아야하기에 불렛에서 관리

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
