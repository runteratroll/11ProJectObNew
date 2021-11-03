//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BlockManager : MonoBehaviour
//{
//    public Block[] blockArray; //Block  

//    [SerializeField] int m_blockCount;
//    //public Mine[] MineArray;
//    //[SerializeField] int m_MineCount;
//    // 정보기입해가지고 초기화하기
//    int Stage = 0;
//    private void Start()
//    {
    
//        blockArray = FindObjectsOfType<Block>();
//        m_blockCount = blockArray.Length;
//        //m_MineCount = MineArray.Length;


//        SubscribeToEvent();
            
//    }
    
//    private void Update()
//    {
       
//    }
//    void SubscribeToEvent()
//    {

//        foreach(Block block in blockArray )
//        {
//            block.OnBeingHit += DecreaseBlockCount; //델리게이트에 이함수를 넣음 포인터
//        }

//        FindObjectOfType<PlayerController>().OnMouseClick += ResetAllBlocks;
//    }
//    void DecreaseBlockCount()
//    {
//        m_blockCount--;
//    }

//    void ResetAllBlocks()
//    {
//        foreach (Block block in blockArray)
//        {
//            if (block.gameObject.activeSelf == false)
//                block.gameObject.SetActive(true);
//        }

//        m_blockCount = blockArray.Length;
//    }

//    //void ResetStage()
//    //{

//    //    GameObject.Find("Item").transform.FindChild("Mine").gameObject.SetActive(true);
//    //}
//}
