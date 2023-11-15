using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _jumpForce = 200;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float mouseSensitivity = 2.0f;
    [SerializeField] private float rotationSmoothing = 10.0f;
    [SerializeField] private Rect turningArea = new Rect(0.4f, 0.4f, 0.4f, 0.4f);
    private Animator anim;
    public GameObject footstep;
    public GameObject JumpSE;
    public GameObject SE_Swimming;
    public bool swimming;

    Renderer rend;

    float actionCooldown = 1.0f;
    float timeSinceAction = 0.0f;

    private Vector3 currentLookDirection;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        footstep.SetActive(false);
        JumpSE.SetActive(false);
        SE_Swimming.SetActive(false);
        currentLookDirection = transform.forward;
        swimming = false;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.y));
        Vector3 directionToMouse = mousePosition - transform.position;
        directionToMouse.y = 0;

        if (directionToMouse != Vector3.zero)
        {
            Vector3 targetLookDirection = directionToMouse.normalized;
            currentLookDirection = Vector3.Slerp(currentLookDirection, targetLookDirection, Time.deltaTime * rotationSmoothing);
            transform.forward = currentLookDirection * mouseSensitivity;
        }

        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        var moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        moveDirection.Normalize();
        var vel = moveDirection * _speed;
        vel.y = _rb.velocity.y;
        _rb.velocity = vel;

        if (Math.Abs(Input.GetAxis("Horizontal")) > 0 || Math.Abs(Input.GetAxis("Vertical")) > 0)
        {
            anim.SetBool("IsMoving", true);
            if (GroundCheck())
            {
                footstep.SetActive(true);
            }
            else
            {
                footstep.SetActive(false);
            }
        }
        else
        {
            anim.SetBool("IsMoving", false);
            footstep.SetActive(false);
        }

        timeSinceAction += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if ((GroundCheck() & timeSinceAction > actionCooldown) || swimming == true)
            {
                timeSinceAction = 0;
                anim.SetTrigger("JumpTrigger");
                footstep.SetActive(false);
                Invoke("Jump", 0.7f);
            }
        }
    }

    void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpForce);
        JumpSE.SetActive(true);
        Invoke("JumpSE_Disable", 0.7f);
    }

    void JumpSE_Disable()
    {
        JumpSE.SetActive(false);
    }

    bool GroundCheck()
    {
        RaycastHit hit;
        float distance = 1f;
        Vector3 dir = new Vector3(0, -1);

        if (Physics.Raycast(transform.position, dir, out hit, distance))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "BlueObstacle" && (rend.material.color == Color.magenta || rend.material.color == Color.green))
        {
            print("swimming");
            swimming = true;
            SE_Swimming.SetActive(true);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "BlueObstacle" && (rend.material.color == Color.magenta || rend.material.color == Color.green))
        {
            print("not swimming");
            swimming = false;
            SE_Swimming.SetActive(false);
        }
    }
}
