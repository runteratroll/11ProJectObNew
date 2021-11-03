using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] Gun[] guns;
    SwordController theGc;

    private void Start()
    {
        theGc = FindObjectOfType<SwordController>();
    }

    const int NORMAL_GUN = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Item"))
        {
            Item item = collision.GetComponent<Item>();

            int extra = 0;


            if(item.itemType == ItemType.Score)
            {
                SoundManager.instance.PlaySE("Score");
                extra = item.extraScore;
                ScoreManager.extraScore += extra;
            }
            else if (item.itemType == ItemType.NormalGun_Bullet)
            {
        
                extra = item.extraBullet;
                guns[NORMAL_GUN].bulletCount += extra;
                theGc.BulletUISetting();
            }

            string message = "+" + extra;
            
            FloatingManager.instance.CreateFloatingText(collision.transform.position,message );

            Destroy(collision.gameObject);
        }
    }
}
