using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Title : MonoBehaviour
{
    public void sTartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void eXitButton()
    {
        Application.Quit();
    }
}
