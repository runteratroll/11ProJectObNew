using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] Camera camera;
    public float moveSpeed = 5f;

    public static bool is4Round = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.RotateAround(transform.position, new Vector3(0,0,1f), 
        Time.deltaTime * moveSpeed);
    }
}
