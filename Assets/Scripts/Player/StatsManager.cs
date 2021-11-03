using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class StatsManager : MonoBehaviour
{


    [SerializeField] int maxHp;
    public int currentHp;

    [SerializeField] public GameObject reTry;
    [SerializeField] float blinkSpeed; //깜빡 스피드
    [SerializeField] int blinkCount;


    [SerializeField] StageManager TheSTM;
    [SerializeField] TextMeshProUGUI[] txt_HpArray;

    [SerializeField] SpriteRenderer mesh_PlayerGraphics;//점과 면과 선을 꾸며주는 역할

    private void Start()
    {
        TheSTM = FindObjectOfType<StageManager>();
        currentHp = maxHp;
        UpdateHpStatus();
    }
    public void DecreaseHp(int _num) //데미지 닳게 함
    {
        //if (!PlayerController.canMove) return;
        currentHp -= _num;
        UpdateHpStatus();
        if (currentHp <= 0) //추상화, 패턴인식, 
            PlayerDead();


        SoundManager.instance.PlaySE("Damage");
        StartCoroutine(BlinkCoroutine());
    }
    //일종의 병렬 처리 기법. 대기 기능 구현이 간단하다.
    IEnumerator BlinkCoroutine()
    {
        for(int i =0; i < blinkCount * 2; i++) //3번 깜빡임고 싶으니 나왔다 안나왔다 2배
        {
            mesh_PlayerGraphics.enabled = !mesh_PlayerGraphics.enabled;
            yield return new WaitForSeconds(blinkSpeed);
        }
    }

    public void UpdateHpStatus()
    {
        for(int  i =0; i< txt_HpArray.Length; i++)
        {
            if (i < currentHp)
            {
                txt_HpArray[i].gameObject.SetActive(true); //currentHp가 2면 하트도 2개(i-> 0,1)까지만 활성화됨.

            }
            else
                txt_HpArray[i].gameObject.SetActive(false);
        }
        
    }


    public void IncreaseHp(int _num)
    {
        if(currentHp == maxHp)
        {
            return;
        }
        currentHp += _num;
        if(currentHp > maxHp)
        {
            currentHp = maxHp; //이건 시행착오로알아내야ㅏㄴㅁ
        }
        UpdateHpStatus();

    }
    void PlayerDead()
    {
        SceneManager.LoadScene("Title");
    }
}
