using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class PlayerSkill1 : MonoBehaviour
{
    public GameObject destroyLay;
    private CamShake Shake;
    public List<int> skillDek = new List<int>();    // 덱 리스트 생성 - 순서대로 카드 나열
    public int skillCard = 0;                        // 획득득 카드 번호 - GetItem() 에서 랜덤 값으로 지급
    public int setSkill;                             // 현재 선택 카드 번호 

    public GameObject skill1;
    // Start is called before the first frame update
    void Start()
    {
        Shake = GameObject.Find("Main Camera").GetComponent<CamShake>();
        setSkill = 1;
        GetItem();
        GetItem();
        GetItem();
        GetItem();
        GetItem();
        GetItem();
        GetItem();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Q)) 
        {
            Skill();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(skillDek.Count == 0)
            {
                Debug.Log("선택 할 카드가 없음");
            }
            else if(setSkill < skillDek.Count)
            {
                setSkill += 1;
                Debug.Log("선택된 카드" + skillDek[setSkill - 1]);
            }
            else
            {
                setSkill = 1;
                Debug.Log("선택된 카드" + skillDek[setSkill - 1]);
            }
            
        }
    }

    public void GetItem()
    {
        skillCard = Random.Range(1, 2);
        skillDek.Add(skillCard);
        Debug.Log("획득스킬"+ skillCard);
    }
    public void Skill()
    {
        if (skillDek.Count == 0)
        {
            Debug.Log("선택 된 카드가 없음");
        }
        else
        {
            switch (skillDek[setSkill - 1])
            {
                case 1:
                    Skill1();
                    break;
                case 2:
                    Skill2();
                    break;
                case 3:
                    Skill3();
                    break;
                default:
                    Debug.Log("미구현 스킬 카드");
                    break;
            }
        }
        
    }

    public void Skill1()
    {
        Debug.Log("1번 스킬 발동");
        
        skill1.SetActive(false);
        skill1.SetActive(true);
        StartCoroutine(Shake.CamShaker());

        skillDek.RemoveAt(setSkill - 1);
        Debug.Log("지금 남은 카드");
        foreach (int i in skillDek)
        {
            Debug.Log(i);
        }
    }
    public void Skill2()
    {
        Debug.Log("2번 스킬 발동");
        skillDek.RemoveAt(setSkill - 1);
        Debug.Log("지금 남은 카드");
        foreach (int i in skillDek)
        {
            Debug.Log(i);
        }
    }
    public void Skill3()
    {
        Debug.Log("3번 스킬 발동");
        skillDek.RemoveAt(setSkill - 1);
        Debug.Log("지금 남은 카드");
        foreach (int i in skillDek)
        {
            Debug.Log(i);
        }
    }
}
