using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Header("���� ���")]
    [SerializeField]protected Transform tf_Player;

    [Header("���󰥼ӵ�")]
    [Range(0, 1)]
    [SerializeField]protected float speed;

    protected Vector3 currentPos;

    private void Start()
    {
        currentPos = tf_Player.position - transform.position;

    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, tf_Player.position - currentPos, speed);
        
    }
}
