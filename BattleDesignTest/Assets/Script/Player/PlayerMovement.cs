using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Singleton<PlayerMovement>
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    private float nowSpeed;

    [SerializeField] private Transform cam;
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    [SerializeField] private Animator anim;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            nowSpeed = runSpeed;
            anim.SetInteger("Speed",2);
        }
        else
        {
            nowSpeed = walkSpeed;
            anim.SetInteger("Speed", 1);
        }

        anim.SetFloat("Speed",nowSpeed);

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * nowSpeed * Time.deltaTime);
            anim.SetBool("Move",true);
        }
        else
        {
            anim.SetBool("Move",false);
        }
        

    }
}
