using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject water_Text;
    public GameObject tillage_Text;
    public GameObject planting_Text;
    public Text month_Text;
    public Text day_Text;
    public Text hour_Text;
    public Text min_Text;

    int year;
    int month;
    int day;
    int hour;
    float min;

    public int acceleration;
    public bool T_completeGrowth; // 토마토 재배 가능
    public bool T_Planting; // 토마토 심기
    public bool S_completeGrowth; // 해바라기 재배 가능
    public bool S_Planting; // 해바리기 심기
    public bool replanting; // 재심기

    public int Tomato_count;


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        year = 2021;
        month = 1;
        day = 1;
        hour = 12;
        min = 1;
        water_Text.SetActive(false);
        tillage_Text.SetActive(false);
        planting_Text.SetActive(false);
        acceleration = 1;
        T_completeGrowth = false;
        T_Planting = false;
        S_completeGrowth = false;
        S_Planting = false;
        replanting = true;
    }

    // Update is called once per frame
    void Update()
    {
        Hour();
    }

    void Hour()
    {
        month_Text.text = month + "월 ";
        day_Text.text = day + "일";
        hour_Text.text = hour + " : ";
        min_Text.text =" "+ (int)min + "";
        min += Time.deltaTime* acceleration;
        //Debug.Log("[GM]Hour/ min" + min);
        if(min>60)
        {
            //Debug.Log("[GM]Hour/ test");
            min = 1;
            hour += 1;
            if (hour > 24)
            {
                hour = 1;
                day += 1;
                if (month % 2 == 0)
                {
                    if (month == 2)
                    {
                        if (day > 28)
                        {
                            day = 1;
                            month += 1;

                        }
                    }
                    else if (day > 31)
                    {
                        day = 1;
                        month += 1;
                    }
                }
                else
                {
                    if (day > 30)
                    {
                        day = 1;
                        month += 1;
                    }
                }
                if (month > 12)
                {
                    year++;
                    month = 1;
                }
            }
        }
    }

}
