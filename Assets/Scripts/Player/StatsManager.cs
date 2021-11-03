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
    [SerializeField] float blinkSpeed; //���� ���ǵ�
    [SerializeField] int blinkCount;


    [SerializeField] StageManager TheSTM;
    [SerializeField] TextMeshProUGUI[] txt_HpArray;

    [SerializeField] SpriteRenderer mesh_PlayerGraphics;//���� ��� ���� �ٸ��ִ� ����

    private void Start()
    {
        TheSTM = FindObjectOfType<StageManager>();
        currentHp = maxHp;
        UpdateHpStatus();
    }
    public void DecreaseHp(int _num) //������ ��� ��
    {
        //if (!PlayerController.canMove) return;
        currentHp -= _num;
        UpdateHpStatus();
        if (currentHp <= 0) //�߻�ȭ, �����ν�, 
            PlayerDead();


        SoundManager.instance.PlaySE("Damage");
        StartCoroutine(BlinkCoroutine());
    }
    //������ ���� ó�� ���. ��� ��� ������ �����ϴ�.
    IEnumerator BlinkCoroutine()
    {
        for(int i =0; i < blinkCount * 2; i++) //3�� �����Ӱ� ������ ���Դ� �ȳ��Դ� 2��
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
                txt_HpArray[i].gameObject.SetActive(true); //currentHp�� 2�� ��Ʈ�� 2��(i-> 0,1)������ Ȱ��ȭ��.

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
            currentHp = maxHp; //�̰� ���������ξ˾Ƴ��ߤ�����
        }
        UpdateHpStatus();

    }
    void PlayerDead()
    {
        SceneManager.LoadScene("Title");
    }
}
