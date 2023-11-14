using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Material[] material;
    public Rigidbody rb;
    Renderer rend;
    Collider collider;

    public float time = 1.0f;

    public AudioSource[] SoundEffect;


    // Start is called before the first frame update
    void Start()
    {
        //color changes
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];

        //collisions
        collider = GetComponent<Collider>();

        //rigidbody for mass
        rb = GetComponent<Rigidbody>();
    }

    //Color changes
    void OnTriggerEnter(Collider col)
    {
        SoundEffect[3].Play();

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
        else if (col.gameObject.tag == "BlueObstacle" && (rend.material.color == Color.yellow || rend.material.color == Color.red))
        {
            collider.material.dynamicFriction = 100000;
            rb.mass = 100;
            SoundEffect[1].Play();
        }
        else if (col.gameObject.tag == "BlueObstacle" && (rend.material.color == Color.magenta || rend.material.color == Color.green))
        {
            StartCoroutine(Swimming(col.collider));
            rb.mass = 10;
        }
        else
        {
            SoundEffect[0].Play();
        }
    }

    /*
    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "BlueObstacle" && (rend.material.color == Color.magenta || rend.material.color == Color.green))
        {
            print("swimming");
            SoundEffect[5].Play();
        }
    }
    */

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rend.material.color = Color.white;
            collider.material.dynamicFriction = 1;
            rb.mass = 5;
            SoundEffect[4].Play();
        }
    }
    
    //Turns on collisions after 1 second
    private IEnumerator Timer(Collider Faze)
    {
        Faze.isTrigger = true;

        SoundEffect[2].Play();

        yield return new WaitForSeconds (1.0f);

        Faze.isTrigger = false;
    }

    //Turns on collisions after 1 second
    private IEnumerator Swimming(Collider Faze)
    {
        Faze.isTrigger = true;

        yield return new WaitForSeconds(3.0f);

        Faze.isTrigger = false;
        rb.mass = 5;
    }
}
