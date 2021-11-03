using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public RotatePlayer rotatePlayer;
    public GameObject bullet;
    public Transform bulletPostion;
    public float speeDeceleration;
    GameObject bull;
    
    private void Start()
    {
        bull = Instantiate(bullet, bulletPostion.position, Quaternion.identity);
        bull.SetActive(false);
        rotatePlayer = FindObjectOfType<RotatePlayer>();
    }



    private void Update()
    {

        
        if (Input.GetMouseButtonUp(0) ==true)
        {
            Debug.Log("µÇÁö?");
            
            StartCoroutine(Attack());
            Vector3 dir = (bulletPostion.transform.position - rotatePlayer.transform.position);
            bull.transform.position = bulletPostion.position;
           
            bull.transform.rotation = rotatePlayer.quaternion;
            bull.transform.SetParent(this.transform);

        }
        
    }

    IEnumerator Attack()
    {

        bull.SetActive(true);

        yield return new WaitForSeconds(0.2f);
        bull.SetActive(false);

    }

}
