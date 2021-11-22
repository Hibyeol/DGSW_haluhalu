using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public static StoreManager instance;

    public GameObject storeUI;
    public bool fieldPurchase2; // �� 2 ���� ����
    public bool fieldPurchase3; // �� 3 ���� ����
    NoticeUI _notice;

    public GameObject[] StoreUI = new GameObject[4];
    void Awake()
    {
        instance = this;
        _notice = FindObjectOfType<NoticeUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        storeUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            storeUI.SetActive(true);
    }

    public void Exit()
    {
        storeUI.SetActive(false);
    }

    public void fieldClick() // �� ����
    {
        StoreUI[0].SetActive(true);
    }

    public void itemsClick() // ������ ����
    {
        StoreUI[1].SetActive(true);
    }
    public void barnClick() // ����� ����
    {
        StoreUI[2].SetActive(true);
    }
    public void healthClick() // ü�»���
    {
        StoreUI[2].SetActive(true);
    }

    public void fieldpurchase1() // �� 2 ����
    {
        if (fieldPurchase2 == false)
        {
            if (MoneyManager.instance.funds >= 30000)
            {
                MoneyManager.instance.funds -= 30000;
                _notice.SUB("��2�� �����ϼ̽��ϴ�");
                fieldPurchase2 = true;
            }
            else
            {
                _notice.SUB("���� �����մϴ�");
            }
        }
        else
        {
            _notice.SUB("�̹� ���� �ϼ̽��ϴ�");
        }

    }


    public void fieldpurchase2() // �� 3 ����
    {
        if (fieldPurchase2 == true && fieldPurchase3 == false)
        {
            if (MoneyManager.instance.funds >= 100000)
            {
                MoneyManager.instance.funds -= 100000;
                _notice.SUB("��3�� �����ϼ̽��ϴ�");
                fieldPurchase3 = true;
            }
            else
            {
                _notice.SUB("���� �����մϴ�");
            }
        }
        else
        {
            _notice.SUB("�̹� ���� �ϼ̽��ϴ�");
        }

    }

    public void itemspurchase1() // ü��ȸ���� ����
    {
        if (MoneyManager.instance.funds >= 5000)
        {
            MoneyManager.instance.funds -= 5000;
            _notice.SUB("ü��ȸ������ �����ϼ̽��ϴ�");
            fieldPurchase3 = true;
        }
        else
        {
            _notice.SUB("���� �����մϴ�");
        }
    }

    public void itemspurchase2() // ���������� ����
    {
        if (MoneyManager.instance.funds >= 20000)
        {
            MoneyManager.instance.funds -= 20000;
            _notice.SUB("������������ �����ϼ̽��ϴ�");
            fieldPurchase3 = true;
        }
        else
        {
            _notice.SUB("���� �����մϴ�");
        }
    }

    public void barnpurchase() // ����� ����
    {
        if (MoneyManager.instance.funds >= 5000)
        {
            MoneyManager.instance.funds -= 5000;
            CropsManager.instance.Max += 5; // ������� +5
            _notice.SUB("����Ұ�ȭ�� �����ϼ̽��ϴ�");
            fieldPurchase3 = true;
        }
        else
        {
            _notice.SUB("���� �����մϴ�");
        }
    }

    public void healthpurchase() // ����� ����
    {
        if (MoneyManager.instance.funds >= 5000 && GameManager.instance.health <=200)
        {
            MoneyManager.instance.funds -= 5000;
            GameManager.instance.health += 5; // ü�� +5

            _notice.SUB("ü�°�ȭ�� �����ϼ̽��ϴ�");
            fieldPurchase3 = true;
        }
        else if(MoneyManager.instance.funds >= 5000)
        {
            _notice.SUB("���� �����մϴ�");
        }
        else if(GameManager.instance.health > 200)
        {
            _notice.SUB("�ִ�ü���Դϴ�");
        }
    }

    public void fieldExit()
    {
        StoreUI[0].SetActive(false);
    }

    public void itemsExit()
    {
        StoreUI[1].SetActive(false);
    }

    public void barnExit()
    {
        StoreUI[2].SetActive(false);
    }

    public void healthExit()
    {
        StoreUI[3].SetActive(false);
    }
}
