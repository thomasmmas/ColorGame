using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform Grabber;
    public float range = 15.0f;
    private bool Grabbed = false;
    private Vector3 originalPos;
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
        Debug.Log("Object Grabbed");
        Grabbed = true;
        originalPos = transform.position;

        GetComponent<BoxCollider>().enabled = false;
        rb.useGravity = false;
        transform.parent = GameObject.Find("InvisibleHand").transform;
    }

    void ReleaseObject()
    {
        Grabbed = false;
        transform.parent = null;
        GetComponent<BoxCollider>().enabled = true;
        rb.useGravity = true;
    }

    void ThrowObject()
    {
        if (Grabbed)
        {
            ReleaseObject();

            // Calculate the direction from the camera to the mouse cursor
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Vector3 throwDir = ray.direction;

            Debug.Log("Throw direction" + throwDir);
            // Apply force in the direction of the mouse cursor
            rb.velocity = throwDir * 40f;
        }
    }
}
