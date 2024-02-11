using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Players : MonoBehaviour
{
    CharacterController controller;
    Vector3 movement;
    Animator animator;
    float speed = 5f;
    public Transform playerModel, pivot;
    int coin = 0;

    // Start is called before the first frame update
    void Start()
    {
       controller = GetComponent<CharacterController>();
       animator = GetComponentInChildren<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float yPos = movement.y;
        //movement = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal")*speed, 0 , CrossPlatformInputManager.GetAxis("Vertical")*speed);
        movement = (CrossPlatformInputManager.GetAxis("Vertical") * transform.forward + CrossPlatformInputManager.GetAxis("Horizontal") * transform.right);
        movement = movement.normalized * speed;
        movement.y = yPos;
        animator.SetFloat("Speed", (Mathf.Abs(CrossPlatformInputManager.GetAxis("Horizontal")) + Mathf.Abs(CrossPlatformInputManager.GetAxis("Vertical"))));
        if (controller.isGrounded)
        {
            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                //animator.SetBool("isJump", false);
                animator.SetBool("isJump", true);
                movement.y = 15f;
            }
            else
            {
                //animator.SetBool("isJump", true);
                animator.SetBool("isJump", false);
            }
        }
       

        movement.y += Physics.gravity.y * Time.deltaTime * speed;
        controller.Move(movement * Time.deltaTime);
        if (CrossPlatformInputManager.GetAxis("Horizontal") != 0 || CrossPlatformInputManager.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0, pivot.eulerAngles.y, 0);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(movement.x, 0, movement.z));
            playerModel.rotation = Quaternion.Slerp(playerModel.rotation, newRotation, 0.5f);
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag=="coin")
        {
            Destroy(hit.gameObject);
            coin++;
            Debug.Log("<color=red>" + coin + "</color>");
        }

        if (hit.gameObject.tag == "dieCoin")
        {
            Time.timeScale = 0f;
        }
    }
}
