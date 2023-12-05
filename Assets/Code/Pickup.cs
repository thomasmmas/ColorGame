using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    public Transform Grabber;
    public float range = 15.0f;
    private bool Grabbed = false;
    private Vector3 originalPos;
    private Rigidbody rb;
    private Camera mainCamera;

    //For color change
    Renderer materialRend;
    public GameObject mainGuy;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;

        //For color change
        materialRend = GetComponent<Renderer>();
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

        /*
        if (Input.GetMouseButtonDown(1))
        {
            float distance = Vector3.Distance(Grabber.position, transform.position);

            if (distance <= range)
            {
                GrabObject();
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            if (Grabbed)
            {
                ReleaseObject();
            }
        }
        */

        //Pressing "Q" changes color of rock
        if (Grabbed && Input.GetKeyDown(KeyCode.Q))
        {
            mainGuy = GameObject.Find("MainCharacter");
            materialRend.material.color = mainGuy.GetComponent<Renderer>().material.GetColor("_Color");
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
        //Debug.Log("Object Grabbed");
        Grabbed = true;
        originalPos = transform.position;

        GetComponent<MeshCollider>().enabled = false;
        rb.useGravity = false;
        transform.parent = GameObject.Find("InvisibleHand").transform;
    }

    void ReleaseObject()
    {
        Grabbed = false;
        transform.parent = null;
        GetComponent<MeshCollider>().enabled = true;
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

            //Debug.Log("Throw direction" + throwDir);

            // Apply force in the direction of the mouse cursor
            rb.velocity = throwDir * 30f;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "BlueObstacle" && materialRend.material.color == Color.red)
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
            rb.freezeRotation = true;
        }
        else if (col.gameObject.tag == "GreenObject" && (materialRend.material.color == Color.magenta))// || materialRend.material.color.g == 128))
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
            rb.freezeRotation = true;
            Invoke("SceneChange", 1.0f);
        }

        //for some reason searching for orange doesn't work so it searches for anything but the following
        else if (col.gameObject.tag == "GreenObject" && (materialRend.material.color != Color.red && materialRend.material.color != Color.yellow && materialRend.material.color != Color.blue && materialRend.material.color != Color.green && materialRend.material.color != Color.white))
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
            rb.freezeRotation = true;
            Invoke("SceneChange", 1.0f);
        }
    }

    void SceneChange()
    {
        SceneManager.LoadScene("WinScreen");
        //SceneManager.SetActiveScene(WinScreen);
    }
}
