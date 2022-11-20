using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door1_anim : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource asource;
    private Animator an;
    void Start()
    {
        asource = gameObject.GetComponent<AudioSource>();
        an =  gameObject.GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        AnimatorStateInfo aninfo = an.GetCurrentAnimatorStateInfo(0);


        if(aninfo.normalizedTime > 1.0f){
            // Debug.Log(an.GetInteger("door1_open"));
            // if(an.GetInteger("door1_open") == 1){
            //     asource.time = 1.5f;
            // }
            //Animation Finished
            an.SetInteger("door1_open",Mathf.Abs(an.GetInteger("door1_open")-1));
            asource.Play();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(an.GetInteger("door1_open") == 1){
            if(asource.time >= 1.5f){
                asource.Pause();
            }
        }
    }
}
