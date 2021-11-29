using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaleStoreManager : MonoBehaviour
{
    public GameObject saleUI;
    public Text fund_Text;
    public Text sunflower;
    public Text napa_cabbage;
    public Text pumkin;
    public Text cherry_tomato;
    public Text rice;

    NoticeUI _notice;

    void Awake()
    {
        _notice = FindObjectOfType<NoticeUI>();
    }

    void Start()
    {
        saleUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        fund_Text.text = "���� �ڱ� : " + MoneyManager.instance.funds;
        sunflower.text = "�عٶ��\n" + CropsManager.instance.sunflower_cur;
        napa_cabbage.text = "�����\n" + CropsManager.instance.Napa_cabbage_cur;
        pumkin.text = "ȣ��\n" + CropsManager.instance.pumpkin_cur;
        cherry_tomato.text = "����丶��\n" + CropsManager.instance.Cherry_tomato_cur;
        rice.text = "��\n" + CropsManager.instance.rice_cur;
    }

    private void OnTriggerEnter(Collider other)
    {
        saleUI.SetActive(true);
    }

    public void ExitClick()
    {
        saleUI.SetActive(false);
    }

    public void SunflowerClick() //�عٶ�� �Ǹ�
    {
        //if (CropsManager.instance.sunflower_cur <= 0)
        //{
        //    _notice.SUB2("��� �����ϴ�");
        //}
        //else
        //{
            MoneyManager.instance.funds += CropsManager.instance.sunflower_cur * 500;
            CropsManager.instance.sunflower_cur -= CropsManager.instance.sunflower_cur;
            //_notice.SUB2( MoneyManager.instance.funds+"�� ȹ���ϼ̽��ϴ�");
        //}
    }

    public void Nepa_cabbageClick() // ����� �Ǹ�
    {
        //if (CropsManager.instance.Napa_cabbage_cur <= 0)
        //{
        //    _notice.SUB2("��� �����ϴ�");
        //}
        //else
        //{
        //    MoneyManager.instance.funds += CropsManager.instance.Napa_cabbage_cur * 3000;
        //    CropsManager.instance.Napa_cabbage_cur = 0;
        //}

        MoneyManager.instance.funds += CropsManager.instance.Napa_cabbage_cur * 3000;
        CropsManager.instance.Napa_cabbage_cur = 0;
    }

    public void PumkinClick() // ȣ�� �Ǹ�
    {
        //if (CropsManager.instance.pumpkin_cur <= 0)
        //{
        //    _notice.SUB("��� �����ϴ�");
        //}
        //else
        //{
        //    MoneyManager.instance.funds += CropsManager.instance.pumpkin_cur * 6000;
        //    CropsManager.instance.pumpkin_cur = 0;
        //}
        MoneyManager.instance.funds += CropsManager.instance.pumpkin_cur * 6000;
        CropsManager.instance.pumpkin_cur = 0;

    }

    public void CherryClick() // ����丶�� �Ǹ�
    {
        //if (CropsManager.instance.Cherry_tomato_cur <= 0)
        //{
        //    _notice.SUB2("��� �����ϴ�");
        //}
        //else
        //{
        //    MoneyManager.instance.funds += CropsManager.instance.Cherry_tomato_cur * 250;
        //    CropsManager.instance.Cherry_tomato_cur -= CropsManager.instance.Cherry_tomato_cur;
        //}

        MoneyManager.instance.funds += CropsManager.instance.Cherry_tomato_cur * 250;
        CropsManager.instance.Cherry_tomato_cur -= CropsManager.instance.Cherry_tomato_cur;

    }

    public void RiceClick() // ���Ǹ�
    {
        //    if (CropsManager.instance.rice_cur <= 0)
        //    {
        //        _notice.SUB2("��� �����ϴ�");
        //    }
        //    else
        //    {
        //        MoneyManager.instance.funds += CropsManager.instance.rice_cur * 300;
        //        CropsManager.instance.rice_cur -= CropsManager.instance.rice_cur;
        //    }
         MoneyManager.instance.funds += CropsManager.instance.rice_cur * 300;
         CropsManager.instance.rice_cur -= CropsManager.instance.rice_cur;
    }

}
