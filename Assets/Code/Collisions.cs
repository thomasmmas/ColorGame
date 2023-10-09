using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public Material material;
    Renderer rend;
    Collider collider;

    void Start()
    {
        collider = GetComponent<Collider>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "BlueObstacle" && rend.material.color == Color.blue)
        {
            print("Contact");
            collider.enabled = !collider.enabled;
        }
        else if (col.gameObject.tag == "BlueObstacle")
        {
            print("shit");
        }
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "BlueObstacle")
        {
            print("drowning");
        }
    }
}
