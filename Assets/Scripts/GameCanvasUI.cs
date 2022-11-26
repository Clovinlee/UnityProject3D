using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvasUI : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject panelForensic;
    public GameObject panelDescription;
    public AudioClip paperSound;
    public AudioClip clickSound;

    private AudioSource asource;

    void Start()
    {
        asource = gameObject.GetComponent<AudioSource>();
    }

    public void forensicButtonPress(){
        asource.clip = paperSound;
        asource.Play();
        panelForensic.SetActive(!panelForensic.activeInHierarchy);
        Freedom.f = !Freedom.f;
    }

    public void descriptionButtonClose(){
        StartCoroutine(closeDescriptionPanel(0.15f));
    }

    IEnumerator closeDescriptionPanel(float time)
    {
        yield return new WaitForSeconds(time);
        GameState.objActive.GetComponent<Animator>().SetInteger("move",0);
        GameState.objActive = null;
        Freedom.f = true;
        panelDescription.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            if(panelForensic != null && panelForensic.activeInHierarchy){
                forensicButtonPress();
            }
        }
        if (Input.GetKeyDown("tab"))
        {
            forensicButtonPress();
        }
    }
}
