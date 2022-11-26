using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class window1_anim : MonoBehaviour
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
        if(EventSystem.current.IsPointerOverGameObject()){
            return;
        }
        
        AnimatorStateInfo aninfo = an.GetCurrentAnimatorStateInfo(0);


        if(aninfo.normalizedTime > 1.0f){
            an.SetInteger("window1_close",Mathf.Abs(an.GetInteger("window1_close")-1));
            asource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
