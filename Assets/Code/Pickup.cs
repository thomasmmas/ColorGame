using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform Grabber;
    public float range = 10.0f;
    private bool Grabbed = false;
    private Vector3 originalPos;
    private Vector3 throwDir;
    private Rigidbody rb;
    private Camera mainCamera;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Grabbed)
        {
            transform.position = Grabber.position;
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (Grabbed)
            {
                ThrowObject();
            }
        }
    }
    void OnMouseDown()
    {
        float distance = Vector3.Distance(Grabber.position, transform.position);

        if (distance <= range)
        {
            GrabObject();
        }
    }

    void OnMouseUp()
    {
        if (Grabbed)
        {
            ReleaseObject();
        }
    }
    void GrabObject()
    {

        Grabbed = true;
        originalPos = transform.position;

        throwDir = Grabber.forward;

        GetComponent<BoxCollider>().enabled = false;
        rb.useGravity = false;
        /*GetComponent<Rigidbody>().useGravity = false;*/
        /*transform.position = Grabber.position;*/
        transform.parent = GameObject.Find("InvisibleHand").transform;
        /*this.transform.position = Grabber.position;
??????????????????this.transform.parent = GameObject.Find("InvisibleHand").transform;*/
    }
    void ReleaseObject()
    {
        Grabbed = false;
        transform.parent = null;
        /*this.transform.parent = null;*/
        /*GetComponent<Rigidbody>().useGravity = true;*/
        GetComponent<BoxCollider>().enabled = true;
        rb.useGravity = true;
    }
    void ThrowObject()
    {
        if (Grabbed)
        {
            ReleaseObject();
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Vector3 throwDir = ray.direction;

            rb.velocity = throwDir * 40f;

        }
    }
}