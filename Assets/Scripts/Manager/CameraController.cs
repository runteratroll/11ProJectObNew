using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("따라갈 플레이어 설정")]
    [SerializeField] Transform tf_Player;

    [Header("따라갈 스피드 조정")]
    [SerializeField] float chaseSpeed;

    float camNormalZpos; //떨어질 카메라 거리
    [SerializeField] [Header("부스터시 떨어질 z거리")]
    float camJetZpos;
    float camCurrentZPos; //변했다가 다시 돌아와야하는경우 정보를 저장하는 변수하나를 지정


    void Start()
    {

        camNormalZpos = transform.position.z;
        camCurrentZPos = camNormalZpos;
    }

    // Update is called once per frame
    void Update()
    {
        //if (thePlayer.IsJet)
        //    camCurrentZPos = camJetZpos;
        //else
        //    camCurrentZPos = camNormalZpos;
        Vector2 movePos = Vector3.Lerp(transform.position, tf_Player.position, chaseSpeed);
        float cameraPoxZ = Mathf.Lerp(transform.position.z, camCurrentZPos, chaseSpeed); // Vector3.lerp의 Float버전
        transform.position = new Vector3(movePos.x, movePos.y, cameraPoxZ);
    }
}
