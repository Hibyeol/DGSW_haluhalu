using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public static StoreManager instance;

    public GameObject storeUI;
    public bool fieldPurchase2; // 밭 2 구매 여부
    public bool fieldPurchase3; // 밭 3 구매 여부
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

    public void fieldClick() // 밭 상점
    {
        StoreUI[0].SetActive(true);
    }

    public void itemsClick() // 아이템 상점
    {
        StoreUI[1].SetActive(true);
    }
    public void barnClick() // 저장소 상점
    {
        StoreUI[2].SetActive(true);
    }
    public void healthClick() // 체력상점
    {
        StoreUI[2].SetActive(true);
    }

    public void fieldpurchase1() // 밭 2 구매
    {
        if (fieldPurchase2 == false)
        {
            if (MoneyManager.instance.funds >= 30000)
            {
                MoneyManager.instance.funds -= 30000;
                _notice.SUB("밭2를 구매하셨습니다");
                fieldPurchase2 = true;
            }
            else
            {
                _notice.SUB("돈이 부족합니다");
            }
        }
        else
        {
            _notice.SUB("이미 구매 하셨습니다");
        }

    }


    public void fieldpurchase2() // 밭 3 구매
    {
        if (fieldPurchase2 == true && fieldPurchase3 == false)
        {
            if (MoneyManager.instance.funds >= 100000)
            {
                MoneyManager.instance.funds -= 100000;
                _notice.SUB("밭3을 구매하셨습니다");
                fieldPurchase3 = true;
            }
            else
            {
                _notice.SUB("돈이 부족합니다");
            }
        }
        else
        {
            _notice.SUB("이미 구매 하셨습니다");
        }

    }

    public void itemspurchase1() // 체력회복제 구매
    {
        if (MoneyManager.instance.funds >= 5000)
        {
            MoneyManager.instance.funds -= 5000;
            _notice.SUB("체력회복제를 구매하셨습니다");
            fieldPurchase3 = true;
        }
        else
        {
            _notice.SUB("돈이 부족합니다");
        }
    }

    public void itemspurchase2() // 성장촉진제 구매
    {
        if (MoneyManager.instance.funds >= 20000)
        {
            MoneyManager.instance.funds -= 20000;
            _notice.SUB("성장촉진제를 구매하셨습니다");
            fieldPurchase3 = true;
        }
        else
        {
            _notice.SUB("돈이 부족합니다");
        }
    }

    public void barnpurchase() // 저장소 구메
    {
        if (MoneyManager.instance.funds >= 5000)
        {
            MoneyManager.instance.funds -= 5000;
            CropsManager.instance.Max += 5; // 저장공간 +5
            _notice.SUB("저장소강화에 성공하셨습니다");
            fieldPurchase3 = true;
        }
        else
        {
            _notice.SUB("돈이 부족합니다");
        }
    }

    public void healthpurchase() // 저장소 구메
    {
        if (MoneyManager.instance.funds >= 5000 && GameManager.instance.health <=200)
        {
            MoneyManager.instance.funds -= 5000;
            GameManager.instance.health += 5; // 체력 +5

            _notice.SUB("체력강화에 성공하셨습니다");
            fieldPurchase3 = true;
        }
        else if(MoneyManager.instance.funds >= 5000)
        {
            _notice.SUB("돈이 부족합니다");
        }
        else if(GameManager.instance.health > 200)
        {
            _notice.SUB("최대체력입니다");
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
