using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class door1_anim : MonoBehaviour
{

    public AudioClip doorBreak;
    public AudioClip doorLockBroke;
    private Animator an;
    private AudioSource asource;
    private bool accessible;
    private bool clickable;
    void Start()
    {
        an = gameObject.GetComponent<Animator>();
        asource = gameObject.GetComponent<AudioSource>();
        accessible = false;
        clickable = true;
    }

    void OnMouseDown()
    {
        if(EventSystem.current.IsPointerOverGameObject() || Freedom.cekDistance(gameObject))
        {
            return;
        }
        AnimatorStateInfo aninfo = an.GetCurrentAnimatorStateInfo(0);

        if(GameState.doorBreak > 0 && clickable){
            if(aninfo.normalizedTime > 1.0f){
                clickable = false;
                an.SetTrigger("door1_break");
                asource.PlayOneShot(doorBreak);

                //Because door rotation animation dont always return to 0,0,0 idk why. So i do this V to reset rotation
                //everytime animation done executing
                StartCoroutine(resetDoorPosition(aninfo.length));
                GameState.doorBreak--;
            }
        }else if(GameState.doorBreak == 0){
            GameState.doorBreak--;
            asource.PlayOneShot(doorLockBroke);
            StartCoroutine(delayLockBroke(doorLockBroke.length + 0.5f));
        }else if(accessible){
            if(aninfo.normalizedTime > 1.0f){
            //Animation Finished

            an.SetInteger("door1_open",Mathf.Abs(an.GetInteger("door1_open")-1));
            asource.Play();
        }
        }else{
            // Debug.Log("Something's wrong with door1_anim.cs");
        }

        if(GameState.doorBreak != -1){
            Debug.Log("Door Break : "+GameState.doorBreak);
        }
    }

    IEnumerator delayLockBroke(float time)
    {
        yield return new WaitForSeconds(time);
        accessible = true;
        // panelDescription.SetActive(false);
    }

    IEnumerator resetDoorPosition(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.transform.rotation = Quaternion.Euler(0,90,0);
        clickable = true;
        // panelDescription.SetActive(false);
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
