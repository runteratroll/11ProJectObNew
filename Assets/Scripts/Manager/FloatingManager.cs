using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FloatingManager : MonoBehaviour
{
    public static FloatingManager instance;
    [SerializeField] GameObject go_Prefab_FloatingText;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void CreateFloatingText(Vector3 pos, string _text)
    {
        GameObject clone = Instantiate(go_Prefab_FloatingText, pos, go_Prefab_FloatingText.transform.rotation);
        clone.GetComponentInChildren<Text>().text = _text;
    }
}
