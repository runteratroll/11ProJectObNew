using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StageManager : MonoBehaviour
{


    [SerializeField] TextMeshProUGUI txt_CurrentScore;
    [SerializeField] GameObject go_Ui;
    [SerializeField] ScoreManager theSM;

    [SerializeField] Camera camera;
    [SerializeField] Rigidbody2D playerRigid;
    [SerializeField] GameObject[] go_Stages;
    [SerializeField] StatsManager stats;
    public int currentStage = 0;



    [SerializeField] Transform tf_OriginPos;

    public void ShowClearUI()
    {
        PlayerController.canMove = true;

        go_Ui.SetActive(true);
        txt_CurrentScore.text = string.Format("{0:000,000}", theSM.GetCurrentScore());
    }

    public void NextBtn()
    {
        if (currentStage < go_Stages.Length - 1)
        {
            

            PlayerController.canMove = false;
            stats.currentHp = 3;
            stats.UpdateHpStatus();
            theSM.ResetCurrentScore();

            playerRigid.gameObject.transform.position = tf_OriginPos.position;
            go_Stages[currentStage++].SetActive(false); //현재후 ++
            go_Stages[currentStage].SetActive(true);

            //if(currentStage == 6)
            //{
            //    camera.orthographicSize = 30;
            //}
            
            blockArray = FindObjectsOfType<Block>();
            

            go_Ui.SetActive(false);
            SubscribeToEvent();
        }
        else
        {
            Debug.Log("모든 스테이지를 클리어함");
        }
    }

    //public void RetryButton()
    //{
    //    statsManager.reTry.SetActive(false);
    //    go_Stages
    //}


    public Block[] blockArray; //Block  

    [SerializeField] int m_blockCount;
    //public Mine[] MineArray;
    //[SerializeField] int m_MineCount;
    // 정보기입해가지고 초기화하기
    int Stage = 0;
    private void Start()
    {

        blockArray = FindObjectsOfType<Block>();
        m_blockCount = blockArray.Length;
        //m_MineCount = MineArray.Length;


        SubscribeToEvent();

    }

    private void Update()
    {

    }
    void SubscribeToEvent()
    {
        
        foreach (Block block in blockArray)
        {
            
            block.OnBeingHit += DecreaseBlockCount; //델리게이트에 이함수를 넣음 포인터
        }

        FindObjectOfType<PlayerController>().OnMouseClick += ResetAllBlocks;
    }
    void DecreaseBlockCount()
    {
        m_blockCount--;
    }

    void ResetAllBlocks()
    {
        foreach (Block block in blockArray)
        {
            if (block.gameObject.activeSelf == false)
                block.gameObject.SetActive(true);
        }

        m_blockCount = blockArray.Length;
    }
}
