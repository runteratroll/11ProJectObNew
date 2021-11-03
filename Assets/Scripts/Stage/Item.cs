using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Score,
    NormalGun_Bullet,
}
public class Item : MonoBehaviour
{
    public ItemType itemType;

    public int extraBullet;
    public int extraScore;

    private void Update() {
        transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime); //1초에 y축을 90씩 회전시키겠다.
    }
}
