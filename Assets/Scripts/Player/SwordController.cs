using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordController : MonoBehaviour
{

    float axis = 0;

    [Header("현재 장착된 총")]
    [SerializeField] Gun currentGun;

    [SerializeField] GameObject thePlayer;
    [SerializeField] Text bulletCount;
    [SerializeField] Transform poolBullet;
    [SerializeField] GameObject bullet;
    float currentFireRate;


    public void BulletUISetting()
    {
        bulletCount.text = "x " + currentGun.bulletCount; 
    }
    //float angle;
    //Vector2 target, mouse;

    private void Start()
    {
        
        currentFireRate = 0;
        BulletUISetting();
       // target = transform.position;
    }
    private void Update()
    {
        FireRateCalc();
        TryFire();
        LockOnMouse();
        
       
    }

    void FireRateCalc()
    {
        if(currentFireRate > 0)
        {
            currentFireRate -= Time.deltaTime; //60분의 1의 값
        }
    }
    void LockOnMouse()
    {
        Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        dir.Normalize();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        
        if(angle < -90 || angle > 90) //왼쪽
        {
            if(thePlayer.transform.eulerAngles.y == 0)
            {
                transform.localRotation = Quaternion.Euler(180f, 0, -angle); //상하 반전이됨 flipY와 같음

            }
            else if(thePlayer.transform.eulerAngles.y == 180)
            {
                transform.localRotation = Quaternion.Euler(180f, 180f, -angle); 
            }
        }
        //오일러각 은 180이 넘어가면 그 값에 대한 네거티브값으로 취급한다
        //Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        //var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //Quaternion.AngleAxis(angle, Vector3.forward * currentGun.speed);
        
        
        
    }

    void TryFire()
    {
        if(Input.GetButtonDown("Fire1") && currentGun.bulletCount > 0 && PlayerController.canMove)
        {
            if(currentFireRate <= 0)
            {
                currentFireRate = currentGun.fireRate;
                Fire();
            }
          
        }
    }

    void Fire()
    {
        currentGun.bulletCount--;
        currentGun.ps_MuzzleFlash.Play();
        BulletUISetting();
        currentGun.animator.SetTrigger("Fire");
        SoundManager.instance.PlaySE(currentGun.sound_Fire);

        //if (poolChating.childCount > 0)
        //{
        //    twichUser = poolChating.GetChild(0).GetComponent<TwichUser>();
        //    twichUser.RandomColor();
        //    twichUser.UpdateShow();
        //    twichUser.Show();
        //}
        var clone = PoolManager.SpawnFromPool("Bullet", currentGun.ps_MuzzleFlash.transform.position, Quaternion.identity);




        clone.GetComponent<Rigidbody2D>().AddForce(transform.right * currentGun.speed, ForceMode2D.Impulse);


        

    }
    
    
}
