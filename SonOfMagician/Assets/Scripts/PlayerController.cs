using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    Animator anim;
    [SerializeField]
    float speed = 0f;
    Vector3 scale;
    bool facingRight = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

        Walk();
    }

    private void Walk()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.velocity = new Vector3(speed * Time.deltaTime, 0, 0);
            anim.SetFloat("Horizontal", 1);
            flip(!facingRight);
            facingRight = true;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            anim.SetFloat("Horizontal", -1);
            anim.SetFloat("Horizontal", 1);
            flip(facingRight);
            facingRight = false;
            rb.velocity = new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        else
        {
            anim.SetFloat("Horizontal", -1);
        }
    }

    void flip(bool faceDir)
    {
        if (faceDir)
        {
            scale.z *= -1;
            transform.localScale = scale;
           

        }
    }
}
