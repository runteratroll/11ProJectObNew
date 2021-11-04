using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title22 : MonoBehaviour
{
    

    public void Ntn()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    public void Exit()
    {
        Application.Quit();
    }


    
}
