using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// T는 아무거나 넣을 수 있음
public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    //컴포넌트 아무거나 사용가능하다
    private static bool shuttingDown = false; //프로그램이 꺼졌어요!
    private static object locker = new object();
    private static T instance = null;  //아무타입이나 할 수 있다는 말?
    public static T Instance
    {
        get
        {
            if (shuttingDown)
            {
                //아 코드가 문제가 있구나!~
                Debug.LogWarning("[Instance] instance " + typeof(T) + " is already destroyed. Returning null.");
                return null;
            }

            lock (locker)
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>(); //따라가기 돈디스트로이 오류해결해야함xhs

                    if (instance == null)
                    {

                        //GameManager 만들면 그이름이 들어감
                        instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
                        DontDestroyOnLoad(instance); //컴포넌트 없애지 않을것이야 2번생성오류 최소화
                    }
                }
                return instance;
            }
        }
    }

    private void OnDestroy() //
    {
        shuttingDown = true;
    }

    private void OnApplicationQuit() //
    {
        shuttingDown = true;
    }
}
