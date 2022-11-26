using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameObject objActive;

    public AudioClip copSiren;

    private float delayCop = 0f;
    private float delayMan = 0f;

    private AudioSource asource;

    public GameObject sirenLight;
    public GameObject figureMan;
    public static int doorBreak = 5;
    public static int windowBreak = 10;
    public float minDistance = 2.5f;

    void Start()
    {
        Freedom.player = gameObject;
        Freedom.minDistance = minDistance;
        asource = gameObject.GetComponent<AudioSource>();
        asource.Play();
        //Cop will show at 
        delayCop = getRandom();

        //Figure man will show at
        // delayMan = getRandom();
        delayMan = 10f;
    }

    float getRandom(){
        // return Random.Range(70f,140f);
        return 30f;
    }

    IEnumerator playFigureMan(float time){
        yield return new WaitForSeconds(time);
        figureMan.SetActive(true);

        yield return new WaitForSeconds(40f);
        figureMan.SetActive(false);
        // delayMan = getRandom();
        delayMan = 40f;
    }

    IEnumerator playCop(float time)
    {
        yield return new WaitForSeconds(time);
        sirenLight.SetActive(true);
        asource.PlayOneShot(copSiren);

        // After audio ends, 
        yield return new WaitForSeconds(copSiren.length);
        sirenLight.SetActive(false);
        delayCop = getRandom();
    }

    // Update is called once per frame
    void Update()
    {
        if(delayCop != 0f){
            Debug.Log("Siren will show on : "+delayCop+" seconds");     
            StartCoroutine(playCop(delayCop));
            delayCop = 0f;
        }

        if(delayMan != 0f){
            Debug.Log("FigureMan will show on : "+delayMan+" seconds");     
            StartCoroutine(playFigureMan(delayMan));
            delayMan = 0f;
        }
    }
}
