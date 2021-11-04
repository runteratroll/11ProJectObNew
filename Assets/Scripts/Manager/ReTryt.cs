using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReTryt : MonoBehaviour
{

    public Transform player;

    public Transform origin;

    public void ReTry()
    {
        player.GetComponent<PlayerController>().m_rigid2D.velocity = Vector2.zero;
        player.gameObject.transform.position = origin.position;
    }
}
