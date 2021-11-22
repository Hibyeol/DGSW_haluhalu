using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public static StoreManager instance;

    public GameObject storeUI;
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

    public void fieldClick()
    {
        StoreUI[0].SetActive(true);
    }

    public void fieldpurchase1()
    {
        if (MoneyManager.instance.funds >= 30000)
        {
            MoneyManager.instance.funds -= 30000;
            _notice.SUB("밭2를 구매하셨습니다");
        }
        else {
            _notice.SUB("돈이 부족합니다");
        }

    }

    public void fieldExit()
    {
        StoreUI[0].SetActive(false);
    }


}
