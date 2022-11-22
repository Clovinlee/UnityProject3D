using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class window1_anim : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip windowBreak;
    public AudioClip windowLockBroke;

    private AudioSource asource;
    private Animator an;
    private bool accessible;
    private bool clickable;
    void Start()
    {
        asource = gameObject.GetComponent<AudioSource>();
        an =  gameObject.GetComponent<Animator>();
        accessible = false;
        clickable = true;
    }

    void OnMouseDown()
    {
        if(EventSystem.current.IsPointerOverGameObject()){
            return;
        }
        
        AnimatorStateInfo aninfo = an.GetCurrentAnimatorStateInfo(0);

        if(GameState.windowBreak > 0 && clickable){
            if(aninfo.normalizedTime > 1.0f){
                clickable = false;
                an.SetTrigger("window1_break");
                asource.PlayOneShot(windowBreak);

                //To prevent user spam click
                StartCoroutine(waitClickAgain(aninfo.length));
                GameState.windowBreak--;
            }
        }else if(GameState.windowBreak == 0){
            GameState.windowBreak--;
            asource.PlayOneShot(windowLockBroke);
            StartCoroutine(delayLockBroke(windowLockBroke.length + 0.5f));
        }else if(accessible){
            if(aninfo.normalizedTime > 1.0f){
                an.SetInteger("window1_close",Mathf.Abs(an.GetInteger("window1_close")-1));
                asource.Play();
            }   
        }

        if(GameState.windowBreak != -1){
            Debug.Log("Window Break : "+GameState.windowBreak);
        }
    }

    IEnumerator delayLockBroke(float time)
    {
        yield return new WaitForSeconds(time);
        accessible = true;
        // panelDescription.SetActive(false);
    }

    IEnumerator waitClickAgain(float time){
        yield return new WaitForSeconds(time);
        clickable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
