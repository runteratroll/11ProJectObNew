using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    int currentScore;


    public int GetCurrentScore() {return currentScore;}
    public void ResetCurrentScore(){currentScore  =0;distanceScore = 0; maxDistance = 0; extraScore= 0; }
    public static int extraScore; //접근편하게 어디서든
    int distanceScore; //거리점수
    float maxDistance; //플레이어가 이동한 최대거리
    float originPosX; // 플레이어의 최초 위치의 x값
    [SerializeField] TextMeshProUGUI txt_Score;
    [SerializeField] Transform tf_Player; //플레이어 위치 정보


    //함수를 굳이 이용하는 이유
    //변수의 값을 변경 못하게 막으려고, & 타 클래스로의 변수 노출을 최소화하려고

    // Start is called before the first frame update
    void Start()
    {
        //originPosX = tf_Player.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //if(tf_Player.position.x > maxDistance)
        //{
        //    maxDistance = tf_Player.position.x;
        //    distanceScore = Mathf.RoundToInt(maxDistance - originPosX);
        //}
        currentScore = extraScore; //+ distanceScore;
        txt_Score.text = string.Format("{0:000,000}", currentScore);
    }
}
