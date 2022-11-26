using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController cc;
    private AudioSource asrc;
    //atur kecepatan
    float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        asrc= gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Freedom.f)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 move = transform.right * x + transform.forward * z;
            cc.Move(move * speed * Time.deltaTime);
            if (asrc.isPlaying)
            {
                if (Input.GetKeyUp("w") || Input.GetKeyUp("d") || Input.GetKeyUp("s") || Input.GetKeyUp("a"))
                {
                    if (!(Input.GetKey("w") || Input.GetKey("d") || Input.GetKey("s") || Input.GetKey("a")))
                    { 
                        asrc.Stop();
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown("w") || Input.GetKeyDown("d") || Input.GetKeyDown("s") || Input.GetKeyDown("a"))
                {
                    asrc.Play();
                }
            }
        }
        else
        {
            asrc.Stop();
        }
    }
}
