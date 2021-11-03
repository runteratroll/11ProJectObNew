using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    public Transform point;
    public float moveSpeed;
    public Quaternion quaternion;
    PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
           // moveSpeed = 100;
            Time.timeScale = 0.5f;
        }

        if(Input.GetMouseButtonUp(0))
        {
            //moveSpeed = 300;
            Time.timeScale = 1f;
        }

        quaternion.eulerAngles += new Vector3(0f, 0f, 1f * Time.deltaTime * moveSpeed);
        transform.rotation = quaternion; 

            //transform.RotateAround(point.position, new Vector3(0,0,1f), 
            //Time.deltaTime * moveSpeed);
    }
}
