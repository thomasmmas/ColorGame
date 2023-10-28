using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _jumpForce = 200;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float mouseSensitivity = 2.0f;
    [SerializeField] private float rotationSmoothing = 10.0f;
    private Animator anim;

    private Vector3 currentLookDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentLookDirection = transform.forward;

    }

    // Update is called once per frame
    void Update()
    {

        
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.y));
        Vector3 directionToMouse = mousePosition - transform.position;
        directionToMouse.y = 0;

        if(directionToMouse != Vector3.zero){
            Vector3 targetLookDirection = directionToMouse.normalized;
            currentLookDirection = Vector3.Slerp(currentLookDirection, targetLookDirection, Time.deltaTime *rotationSmoothing);
            transform.forward = currentLookDirection * mouseSensitivity;
        }

        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        var moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        moveDirection.Normalize();
        var vel = moveDirection * _speed;
        vel.y = _rb.velocity.y;
        _rb.velocity = vel;


      

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("JumpTrigger");
            Invoke("Jump", 0.7f);
        }
           

        //transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime, 0f, 0f);
        //transform.Translate(Input.GetAxis("Vertical") * 0f, 0f, Time.deltaTime);
    }

    void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpForce);
    }

}
