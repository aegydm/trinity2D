using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class PlayerSkill1 : MonoBehaviour
{
    public GameObject destroyLay;
    private CamShake Shake;
    public List<int> skillDek = new List<int>();    // �� ����Ʈ ���� - ������� ī�� ����
    public int skillCard = 0;                        // ȹ��� ī�� ��ȣ - GetItem() ���� ���� ������ ����
    public int setSkill;                             // ���� ���� ī�� ��ȣ 

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
                Debug.Log("���� �� ī�尡 ����");
            }
            else if(setSkill < skillDek.Count)
            {
                setSkill += 1;
                Debug.Log("���õ� ī��" + skillDek[setSkill - 1]);
            }
            else
            {
                setSkill = 1;
                Debug.Log("���õ� ī��" + skillDek[setSkill - 1]);
            }
            
        }
    }

    public void GetItem()
    {
        skillCard = Random.Range(1, 2);
        skillDek.Add(skillCard);
        Debug.Log("ȹ�潺ų"+ skillCard);
    }
    public void Skill()
    {
        if (skillDek.Count == 0)
        {
            Debug.Log("���� �� ī�尡 ����");
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
                    Debug.Log("�̱��� ��ų ī��");
                    break;
            }
        }
        
    }

    public void Skill1()
    {
        Debug.Log("1�� ��ų �ߵ�");
        
        skill1.SetActive(false);
        skill1.SetActive(true);
        StartCoroutine(Shake.CamShaker());

        skillDek.RemoveAt(setSkill - 1);
        Debug.Log("���� ���� ī��");
        foreach (int i in skillDek)
        {
            Debug.Log(i);
        }
    }
    public void Skill2()
    {
        Debug.Log("2�� ��ų �ߵ�");
        skillDek.RemoveAt(setSkill - 1);
        Debug.Log("���� ���� ī��");
        foreach (int i in skillDek)
        {
            Debug.Log(i);
        }
    }
    public void Skill3()
    {
        Debug.Log("3�� ��ų �ߵ�");
        skillDek.RemoveAt(setSkill - 1);
        Debug.Log("���� ���� ī��");
        foreach (int i in skillDek)
        {
            Debug.Log(i);
        }
    }
}
