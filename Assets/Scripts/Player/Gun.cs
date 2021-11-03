using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Normal_Gun,
}
public class Gun : MonoBehaviour
{
    [Header("�� ����")]
    public WeaponType weaponType;

    [Header("�� ����ӵ� ����")]
    public float fireRate;

    [Header("�Ѿ� ����")]
    public int bulletCount;
    public int maxBulletCount;

    [Header("�ѱ� ����")]
    public ParticleSystem ps_MuzzleFlash;

    [Header("�Ѿ� ������")]
    public GameObject go_Bullet_Frefab;

    [Header("�ִϸ�����")]
    public Animator animator;

    [Header("�Ѿ� ���ǵ�")]
    public float speed;

    [Header("�Ѿ� �߻� ����")]
    public string sound_Fire;
}
