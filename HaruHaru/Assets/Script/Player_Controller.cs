using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField]
    private Transform playerBody;
    [SerializeField]
    private Transform cameraArm;

    Animator animator;
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        animator = playerBody.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAround();
        Move();
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
            transform.position += moveDir * Time.deltaTime * 2f; // 이동
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

    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "Tomato")
        {

            Debug.Log("[PC]OnTriggerEnter / Trigger");
            if (Input.GetKeyDown(KeyCode.F)==true)
            {
                Debug.Log("[PC]OnTriggerEnter / keycode F");

            }
        }
    }
}
