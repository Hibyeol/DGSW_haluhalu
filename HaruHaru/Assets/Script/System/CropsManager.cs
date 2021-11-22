using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CropsManager : MonoBehaviour
{
    public static CropsManager instance;
    public int Max; // ����� ����
    public int Cur;
    public int sunflower_cur;
    public int Napa_cabbage_cur;
    public int pumpkin_cur;
    public int Cherry_tomato_cur = 0;
    public int rice_cur;

    public GameObject UI;
    public Text sunflower;
    public Text napa_cabbage;
    public Text pumkin;
    public Text cherry_tomato;
    public Text rice;
    public Text max;

    public bool istillage;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        istillage = true;
        UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Cur = sunflower_cur + Napa_cabbage_cur + pumpkin_cur + Cherry_tomato_cur + rice_cur;
        if (Max < Cur)
        {
            Debug.Log("[CM]Update / ���� ����Ұ� ���� á���ϴ�. ���۹��� �Ǹ��Ͻʽÿ�");
            istillage = false;
        }
        else
        {
            istillage = true;
        }
        UpdateSet();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("[CM]OnTriggerEnter / sunflower_cur :" + sunflower_cur);
            UI.SetActive(true);
        }
    }

    void UpdateSet()
    {
        sunflower.text = "�عٶ��\n" + sunflower_cur;
        napa_cabbage.text = "�����\n" + Napa_cabbage_cur;
        pumkin.text = "ȣ��\n" + pumpkin_cur;
        
        rice.text = "��\n" +rice_cur;
        max.text = "�ִ����\n" + Max;
    }

    private void OnTriggerExit(Collider other)
    {
        UI.SetActive(false);
    }
}
