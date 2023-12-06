using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ImprovController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float rotationSmoothing;
    [SerializeField] private Rect turningArea = new Rect(0.4f, 0.4f, 0.4f, 0.4f);
    private Animator anim;
    public GameObject footstep;
    public GameObject JumpSE;
    public GameObject SE_Swimming;
    public bool swimming;
    public float maxUpwardVelocity;

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
        swimming = false;
        rend = GetComponent<Renderer>();
        //_rb = GetComponent<Rigidbody>();
        rend.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
            Vector3 targetLookDirection = directionToMouse.normalized * mouseSensitivity;
            currentLookDirection = Vector3.Slerp(currentLookDirection, targetLookDirection, Time.deltaTime * rotationSmoothing);
        }

        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        var moveDirection = (currentLookDirection * verticalInput + transform.right * horizontalInput).normalized;
        moveDirection += transform.right * horizontalInput;
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

        //Detection to see if character should jump
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

        if (_rb.velocity.y > maxUpwardVelocity)
        {
            Vector3 newVelocity = _rb.velocity;
            newVelocity.y = Mathf.Lerp(newVelocity.y, -4000, Time.deltaTime);
            _rb.velocity = newVelocity;
        }


        //Tab button turns off and on the cursor
        if (Input.GetKeyUp(KeyCode.Tab) && Cursor.visible == true)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
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

    //checks to see if touching the ground
    bool GroundCheck()
    {
        RaycastHit hit;
        float distance = 1f;
        Vector3 dir = new Vector3(0, -3);

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
            //print("swimming");
            swimming = true;
            SE_Swimming.SetActive(true);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "BlueObstacle" && (rend.material.color == Color.magenta || rend.material.color == Color.green))
        {
            //print("not swimming");
            swimming = false;
            SE_Swimming.SetActive(false);
        }
    }
    /*bool IsInteractingWithObject()
    {
        // Implement your logic to check if the player is interacting with an object here
        // For example, raycasting to detect interactable objects

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            // Check if the hit object is interactable
            // Adjust this logic based on your game's interaction system
            if (hit.collider.CompareTag("Interactable"))
            {
                return true;
            }
        }
        return false;
    }*/
}