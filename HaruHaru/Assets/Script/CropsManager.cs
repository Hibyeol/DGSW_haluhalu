using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropsManager : MonoBehaviour
{
    public static CropsManager instance;
    public int Max;
    public int Cur;
    public int sunflower_cur;
    public int Napa_cabbage_cur;
    public int pumpkin_cur;
    public int Cherry_tomato_cur;
    public int rice_cur;

    public bool istillage;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        istillage = true;
    }

    // Update is called once per frame
    void Update()
    {
        Cur = sunflower_cur + Napa_cabbage_cur + pumpkin_cur + Cherry_tomato_cur + rice_cur;
        if (Max > Cur)
        {
            Debug.Log("[CM]Update / ���� ����Ұ� ���� á���ϴ�. ���۹��� �Ǹ��Ͻʽÿ�");
            istillage = false;
        }
        else
        {
            istillage = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("[CM]OnTriggerEnter / sunflower_cur :" + sunflower_cur);
        }
    }
}
