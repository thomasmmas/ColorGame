using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _jumpForce = 200;
    [SerializeField] private Rigidbody _rb;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpForce);
    }

    // Update is called once per frame
    void Update()
    {
        var vel = new Vector3(Input.GetAxis("Vertical") * -1, 0, Input.GetAxis("Horizontal")) * _speed;
        vel.y = _rb.velocity.y;
        _rb.velocity = vel;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("JumpTrigger");
            Invoke("Jump", 0.7f);
        }

        /*if (_rb.velocity > 0)
        {
            anim.SetBool("IsMoving", true);
        }*/
        //transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime, 0f, 0f);
        //transform.Translate(Input.GetAxis("Vertical") * 0f, 0f, Time.deltaTime);
    }
}
