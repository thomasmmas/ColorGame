using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Material[] material;
    Renderer rend;
    Collider collider;

    public float time = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        //color changes
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];

        //collisions
        collider = GetComponent<Collider>();
    }

    //Color changes
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "BluePuddle" && rend.material.color == Color.yellow)
        {
            rend.sharedMaterial = material[4];
        }
        else if (col.gameObject.tag == "BluePuddle" && rend.material.color == Color.red)
        {
            rend.sharedMaterial = material[6];
        }
        else if (col.gameObject.tag == "BluePuddle")
        {
            rend.sharedMaterial = material[1];
            print("blue");
        }
        else if (col.gameObject.tag == "YellowPuddle" && rend.material.color == Color.blue)
        {
            rend.sharedMaterial = material[4];
        }
        else if (col.gameObject.tag == "YellowPuddle" && rend.material.color == Color.red)
        {
            rend.sharedMaterial = material[5];
        }
        else if (col.gameObject.tag == "YellowPuddle")
        {
            rend.material.color = Color.yellow;
        }
        else if (col.gameObject.tag == "RedPuddle" && rend.material.color == Color.yellow)
        {
            rend.sharedMaterial = material[5];
        }
        else if (col.gameObject.tag == "RedPuddle" && rend.material.color == Color.blue)
        {
            rend.sharedMaterial = material[6];
        }
        else if (col.gameObject.tag == "RedPuddle")
        {
            rend.sharedMaterial = material[3];
        }
    }

    //Collisions
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "BlueObstacle" && rend.material.color == Color.blue)
        {
            StartCoroutine (Timer(col.collider));
        }

        if (col.gameObject.tag == "BlueObstacle" && (rend.material.color[1] == 128 || rend.material.color == Color.magenta))
        {
            collider.material.dynamicFriction = 1;
        }
        else if (col.gameObject.tag == "BlueObstacle" && (rend.material.color == Color.yellow || rend.material.color == Color.red))
        {
            collider.material.dynamicFriction = 100000;
        }
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "BlueObstacle")
        {
            //print("drowning");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rend.material.color = Color.white;
            collider.material.dynamicFriction = 1;
        }
    }
    
    //Turns on collisions after 1 second
    private IEnumerator Timer(Collider Faze)
    {
        Faze.isTrigger = true;

        yield return new WaitForSeconds (1.0f);

        Faze.isTrigger = false;
    }
}
