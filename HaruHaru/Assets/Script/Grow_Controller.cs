using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow_Controller : MonoBehaviour
{

    Animator animator;
    public bool sunflower_planting;
    //public bool[] sunflower_planting = new bool[4];
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sunflower_planting = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.KeypadPlus))
        //{
        //    Debug.Log("TEST");
        //    //animator.SetFloat("Speed", animator.GetFloat("Speed") + 0.02f);
        //    animator.speed += 0.2f;
        //}
        //if (Input.GetKeyDown(KeyCode.KeypadMinus))
        //{
        //    animator.SetFloat("Speed", animator.GetFloat("Speed") - 0.02f);
        //}
    }


    public void Grow()
    {
        Debug.Log("[GC]Grow / Grow");
        sunflower_planting = true;
        animator.SetBool("Grow", true);
        animator.SetBool("Restart", false);
    }

    public void Restart()
    {
        GameManager.instance.replanting = false;
        Debug.Log("[GC]Restart");
        animator.SetBool("Restart", true);
        GameManager.instance.T_Planting = false;
        GameManager.instance.S_Planting = false;
        StartCoroutine(restart());
    }


    public void T_CompleteGrowth()
    {
        GameManager.instance.T_completeGrowth = true;
        animator.SetBool("Grow", false);
        Debug.Log("T_completeGrowth");
    }


    public void S_CompleteGrowth()
    {
        GameManager.instance.S_completeGrowth = true;
        animator.SetBool("Grow", false);
        Debug.Log("S_completeGrowth");
    }

    IEnumerator restart()
    {
        yield return new WaitForSeconds(15f);
        animator.SetBool("Restart", false);
        GameManager.instance.replanting = true;

    }
}
