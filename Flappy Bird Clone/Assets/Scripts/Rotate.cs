using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Rigidbody2D rocket;
    public float angVel;
    // Start is called before the first frame update
    void Start()
    {
        rocket = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetButtonDown("Jump"))
        {
            rocket.angularVelocity = angVel;
        }

        if(rocket.rotation >= -60)
        {
            rocket.rotation = -60;
        }
        else if(rocket.rotation <= -120)
        {
            rocket.rotation = -120;
        }
    }
}
