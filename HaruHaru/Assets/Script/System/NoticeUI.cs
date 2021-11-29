using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeUI : MonoBehaviour
{
    public GameObject subbox;
    public Text subintext;
    public Animator subani;

    //public GameObject saleSubbox;
    //public Text saleSubintext;
    //public Animator saleSubani;

    private WaitForSeconds _UIDelay1 = new WaitForSeconds(2.0f);
    private WaitForSeconds _UIDelay2 = new WaitForSeconds(0.3f);

    // Start is called before the first frame update
    void Start()
    {
        subbox.SetActive(false);
        //saleSubbox.SetActive(false);
    }


    public void SUB(string message)
    {
        subintext.text = message;
        subbox.SetActive(false);
        StopAllCoroutines();
        StartCoroutine(SUBDelay());
    }

    //public void SUB2(string message)
    //{
    //    saleSubintext.text = message;
    //    saleSubbox.SetActive(false);
    //    StopAllCoroutines();
    //    StartCoroutine(SUBDelay2());
    //}
    IEnumerator SUBDelay()
    {
        subbox.SetActive(true);
        subani.SetBool("isOn", true);
        yield return _UIDelay1;
        subani.SetBool("isOn", false);
        yield return _UIDelay2;
        subbox.SetActive(false);
    }

    //IEnumerator SUBDelay2()
    //{
    //    saleSubbox.SetActive(true);
    //    saleSubani.SetBool("isOn", true);
    //    yield return _UIDelay1;
    //    saleSubani.SetBool("isOn", false);
    //    yield return _UIDelay2;
    //    saleSubbox.SetActive(false);
    //}
}
