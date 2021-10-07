using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Controller : MonoBehaviour
{
    [SerializeField]
    private Transform playerBody;
    [SerializeField]
    private Transform cameraArm;

    GameObject tomato;
    GameObject sunflower;
    Animator animator;
    public float health;
    Grow_Controller grow_controller;

    // Start is called before the first frame update
    void Start()
    {
        animator = playerBody.GetComponent<Animator>();
        tomato = GameObject.Find("TomatoA");
        sunflower = GameObject.Find("SunFlowerA");
    }

    // Update is called once per frame
    void Update()
    {
        LookAround();
        Move();
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

            playerBody.forward = lookForward; // �ٶ󺸴� ����
            transform.position += moveDir * Time.deltaTime * 1f; // �̵�
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
            x = Mathf.Clamp(x, -1f, 70f);//ī�޶� ���� ����
        }
        else
        {
            x = Mathf.Clamp(x, 335f, 361f); // ī�޶� ���� ����
        }

        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z); // ī�޶� ����
    }

    void Phone()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        GameManager.instance.water_Text.SetActive(true);
        if (other.tag == "Tomato")
        {
            
            Debug.Log("[PC]OnTriggerEnter / Tomato");
            if (Input.GetKeyDown(KeyCode.F)==true)
            {
                Debug.Log("[PC]OnTriggerEnter / keycode F");
                tomato.GetComponent<Grow_Controller>().Grow();
            }
        }

        if (other.tag == "SunFlower")
        {

            Debug.Log("[PC]OnTriggerEnter / SunFlower");
            if (Input.GetKeyDown(KeyCode.F) == true)
            {
                Debug.Log("[PC]OnTriggerEnter / keycode F");
                sunflower.GetComponent<Grow_Controller>().Grow();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GameManager.instance.water_Text.SetActive(false);
    }
}
