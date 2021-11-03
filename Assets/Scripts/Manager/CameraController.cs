using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("���� �÷��̾� ����")]
    [SerializeField] Transform tf_Player;

    [Header("���� ���ǵ� ����")]
    [SerializeField] float chaseSpeed;

    float camNormalZpos; //������ ī�޶� �Ÿ�
    [SerializeField] [Header("�ν��ͽ� ������ z�Ÿ�")]
    float camJetZpos;
    float camCurrentZPos; //���ߴٰ� �ٽ� ���ƿ;��ϴ°�� ������ �����ϴ� �����ϳ��� ����


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
        float cameraPoxZ = Mathf.Lerp(transform.position.z, camCurrentZPos, chaseSpeed); // Vector3.lerp�� Float����
        transform.position = new Vector3(movePos.x, movePos.y, cameraPoxZ);
    }
}
