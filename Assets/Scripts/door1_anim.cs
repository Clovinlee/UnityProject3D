using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door1_anim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown()
    {
        Animator an =  gameObject.GetComponent<Animator>();

        AnimatorStateInfo aninfo = an.GetCurrentAnimatorStateInfo(0);

        if(aninfo.normalizedTime > 1.0f){
            //Animation Finished
            an.SetInteger("door1_open",Mathf.Abs(an.GetInteger("door1_open")-1));
        }
        Debug.Log(an.GetInteger("door1_open"));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
