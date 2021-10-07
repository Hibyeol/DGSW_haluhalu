using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow_Controller : MonoBehaviour
{

    Animator tomatoanimator;
    // Start is called before the first frame update
    void Start()
    {
        tomatoanimator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Grow()
    {
        Debug.Log("[GC]Grow / Grow");
        tomatoanimator.SetBool("Grow", true);
    }
}
