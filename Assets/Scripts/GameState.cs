using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameObject objActive;

    public AudioClip copSiren;

    private float delayCop = 0f;

    private AudioSource asource;

    public GameObject sirenLight;

    public static int doorBreak = 5;
    public static int windowBreak = 10;
<<<<<<< HEAD
    public float minDistance = 2.5f;
    private void Awake()
    {
        Freedom.player = gameObject;
        Freedom.minDistance = this.minDistance;
    }
=======
>>>>>>> parent of 1e4b0445 (Window break)

    void Start()
    {
        asource = gameObject.GetComponent<AudioSource>();
        asource.Play();
        delayCop = getRandom();
    }

    float getRandom(){
        // return Random.Range(70f,140f);
        return 30f;
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
            Debug.Log(delayCop);     
            StartCoroutine(playCop(delayCop));
            delayCop = 0f;
        }
    }
}
