using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CropsManager : MonoBehaviour
{
    public static CropsManager instance;
    public int Max; // 저장소 공간
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
            Debug.Log("[CM]Update / 현재 저장소가 가득 찼습니다. 농작물을 판매하십시요");
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
        sunflower.text = "해바라기\n" + sunflower_cur;
        napa_cabbage.text = "양배추\n" + Napa_cabbage_cur;
        pumkin.text = "호박\n" + pumpkin_cur;
        
        rice.text = "쌀\n" +rice_cur;
        max.text = "최대수량\n" + Max;
    }

    private void OnTriggerExit(Collider other)
    {
        UI.SetActive(false);
    }
}
