using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField] float destroyTime;
    [SerializeField] Animation animation;

    // Start is called before the first frame update
    void Start()
    {
        animation.Play();
        Destroy(gameObject,destroyTime);    
    }

    // Update is called once per frame
   
}
