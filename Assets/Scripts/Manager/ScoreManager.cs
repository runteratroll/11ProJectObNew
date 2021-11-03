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
    public static int extraScore; //�������ϰ� ��𼭵�
    int distanceScore; //�Ÿ�����
    float maxDistance; //�÷��̾ �̵��� �ִ�Ÿ�
    float originPosX; // �÷��̾��� ���� ��ġ�� x��
    [SerializeField] TextMeshProUGUI txt_Score;
    [SerializeField] Transform tf_Player; //�÷��̾� ��ġ ����


    //�Լ��� ���� �̿��ϴ� ����
    //������ ���� ���� ���ϰ� ��������, & Ÿ Ŭ�������� ���� ������ �ּ�ȭ�Ϸ���

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
