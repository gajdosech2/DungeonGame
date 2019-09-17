using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5;
    public float walkSideSpeed = 3;
    public float walkReverseSpeed = 2;
    public float rotateSpeed = 100;
    public float jumpStrength = 0.2f;
    Vector3 walkAcceleration = new Vector3(0, 0, 0);
    float jumpAcceleration = 0;
    int jumpCount = 0;
    public CharacterController playerController;
    public Animator playerAnimator;

    void Update()
    {
        KeyboardInputs();
        playerAnimator.SetFloat("runningSpeed", walkAcceleration.magnitude);
        playerAnimator.SetFloat("jumpingSpeed", jumpAcceleration);
        Movements();
    }

    void KeyboardInputs()
    {
        if (Input.GetKey(KeyCode.W))
        {
            walkAcceleration = playerController.transform.forward * walkSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            walkAcceleration = playerController.transform.right * -walkSideSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            walkAcceleration = playerController.transform.forward * -walkReverseSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            walkAcceleration = playerController.transform.right * walkSideSpeed;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCount < 2)
            {
                jumpAcceleration = jumpStrength;
            }
            jumpCount += 1;
        }
    }

    void Movements()
    {
        playerController.Move(walkAcceleration * Time.deltaTime);
        playerController.Move(new Vector3(0, jumpAcceleration, 0));
        playerController.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotateSpeed);

        if (playerController.isGrounded)
        {
            walkAcceleration = Vector3.zero;
            jumpCount = 0;
        }
        else
        {
            walkAcceleration = Vector3.MoveTowards(walkAcceleration, Vector3.zero, Time.deltaTime);
        }

        if (jumpAcceleration > -0.98f)
        {
            jumpAcceleration = Mathf.MoveTowards(jumpAcceleration, -0.98f, Time.deltaTime);
        }
    }
}
