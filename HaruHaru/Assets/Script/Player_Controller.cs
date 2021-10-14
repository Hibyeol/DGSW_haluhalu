using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Controller : MonoBehaviour
{
    [SerializeField]
    private Transform playerBody;
    [SerializeField]
    private Transform cameraArm;

    GameObject phone;
    GameObject tomato;
    GameObject sunflower;
    Animator animator;
    public float health;
    bool ismove;
    Grow_Controller grow_controller;

    // Start is called before the first frame update
    void Start()
    {
        animator = playerBody.GetComponent<Animator>();
        tomato = GameObject.Find("TomatoA");
        sunflower = GameObject.Find("SunFlowerA");
        phone = GameObject.Find("Phone");
        phone.SetActive(false);
        ismove = true;
    }

    // Update is called once per frame
    void Update()
    {
        LookAround();
        if (ismove == true)
        {
            Move();
        }
        Phone();
    }

    private void Move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool ismove = moveInput.magnitude != 0;
        animator.SetInteger("animation", 1);
        if (ismove)
        {
            animator.SetInteger("animation", 18);
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;

            playerBody.forward = lookForward; // 바라보는 방향
            transform.position += moveDir * Time.deltaTime * 1f; // 이동
        }
        Debug.DrawRay(cameraArm.position, new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized, Color.red);
    }

    private void LookAround()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 camAngle = cameraArm.rotation.eulerAngles;
        float x = camAngle.x - mouseDelta.y;

        if(x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 70f);//카메라 각도 제한
        }
        else
        {
            x = Mathf.Clamp(x, 335f, 361f); // 카메라 각도 제한
        }

        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z); // 카메라 각도
    }

    void Phone()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            phone.SetActive(true);
            ismove = false;
            animator.SetInteger("animation", 1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            phone.SetActive(false);
            ismove = true;
            
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Tomato")
        {
            if (GameManager.instance.T_Planting == false)
            {
                GameManager.instance.planting_Text.SetActive(true);
                GameManager.instance.tillage_Text.SetActive(false);
                //Debug.Log("[PC]OnTriggerEnter / Tomato");
                if (Input.GetKeyDown(KeyCode.F) == true)
                {
                    Debug.Log("[PC]OnTriggerEnter / keycode F");
                    tomato.GetComponent<Grow_Controller>().Grow();
                    GameManager.instance.T_Planting = true;
                }
            }
            if (GameManager.instance.T_completeGrowth == true && GameManager.instance.T_Planting == true)
            {
                GameManager.instance.planting_Text.SetActive(false);
                GameManager.instance.water_Text.SetActive(false);
                GameManager.instance.tillage_Text.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F) == true)
                {
                    GameManager.instance.Tomato_count += 16;
                    Debug.Log("[PC]RESTART");
                    tomato.GetComponent<Grow_Controller>().Restart();
                }

            }
            else if (GameManager.instance.T_completeGrowth == false && GameManager.instance.T_Planting == true)
            {
                GameManager.instance.planting_Text.SetActive(false);
                GameManager.instance.water_Text.SetActive(true);
                GameManager.instance.tillage_Text.SetActive(false);

            }
        }

        if (other.tag == "SunFlower")
        {
            if (GameManager.instance.S_Planting == false)
            {
                GameManager.instance.planting_Text.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F) == true)
                {
                    Debug.Log("[PC]OnTriggerEnter / keycode F");
                    sunflower.GetComponent<Grow_Controller>().Grow();
                    GameManager.instance.S_Planting = true;
                }
            }
            if (GameManager.instance.S_completeGrowth == true && GameManager.instance.S_Planting == true)
            {
                GameManager.instance.planting_Text.SetActive(false);
                GameManager.instance.water_Text.SetActive(false);
                GameManager.instance.tillage_Text.SetActive(true);
                

            }
            else if (GameManager.instance.S_completeGrowth == false && GameManager.instance.S_Planting == true)
            {
                GameManager.instance.planting_Text.SetActive(false);
                GameManager.instance.water_Text.SetActive(true);
                GameManager.instance.tillage_Text.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GameManager.instance.water_Text.SetActive(false);
        GameManager.instance.planting_Text.SetActive(false);
        GameManager.instance.tillage_Text.SetActive(false);
    }
}
