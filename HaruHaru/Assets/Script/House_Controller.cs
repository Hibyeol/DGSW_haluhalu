using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House_Controller : MonoBehaviour
{ 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.acceleration = 30;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameManager.instance.acceleration = 1;
    }
}
