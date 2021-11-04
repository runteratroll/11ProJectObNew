using System.Collections;
using UnityEngine;

public class CameraShake : MonoSingleton<CameraShake>
{
    [SerializeField] float m_force = 0f;// 카메라 흔들림 세기
    [SerializeField] Vector3 m_offset = Vector3.zero; // 카메라 방향

    Quaternion m_originRot;

    public bool isShack = false;



    public IEnumerator ShakeCoroutin()
    {
        if (CameraRotation.is4Round) yield break;
        
            Vector3 t_originEuler = transform.eulerAngles; //카메라의 오일러 초기값 지정


            float t_rotZ = Random.Range(-m_offset.z, m_offset.z);


            Vector3 t_randomRot = t_originEuler + new Vector3(0f, 0f, t_rotZ);//흔들림 값 = 초기값 + 랜덤값;

            Quaternion t_rot = Quaternion.Euler(t_randomRot);

            while (Quaternion.Angle(transform.rotation, t_rot) > 0.1f) //목적값까지 움직일 때까지 반복
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, t_rot, m_force * Time.deltaTime);

                yield return null;
            }

            while (Quaternion.Angle(transform.rotation, m_originRot) > 0f)
            {
              
                transform.rotation = Quaternion.RotateTowards(transform.rotation, m_originRot, m_force * Time.deltaTime);
                yield return null;
            }
        
        
    }

    private void Start()
    {
        m_originRot = transform.rotation;
    }

    private void Update()
    {
       
    }

    
    
}
