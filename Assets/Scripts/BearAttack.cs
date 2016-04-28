using UnityEngine;
using System.Collections;

public class BearAttack : MonoBehaviour {
    public float delay;
    public static bool countdown;
    public static bool start;
    private Animation run;
    private Animator anim;
    public float speed;
    public static bool scareBear;
    public AudioSource barry_running;

    // Use this for initialization
    void Start () {
        scareBear = false;
        countdown = false;
        start = false;
        anim = GameObject.Find("barrywheeler_bear").GetComponent<Animator>();
        run = gameObject.GetComponent<Animation>();
        delay = 10;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (scareBear) {
            GetComponent<AudioSource>().Stop();
            run.Stop("Bear running");
            anim.SetBool("idling", true);
            Transform bs = GameObject.Find("BEAR_BLK").transform;
            bs.SetParent(null);
            bs.LookAt(GameObject.Find("Sphere").transform);
            bs.position += 15 * bs.forward * Time.deltaTime;
            if (GameObject.Find("Bear Friend")) {
                GameObject.Find("Bear Friend").GetComponent<Animation>().enabled = false;
            }
        }
        if (countdown) {
            delay -= Time.deltaTime;
        }
        if (delay <= 0) {
            start = true;
            countdown = false;
        }
        if (start) {
            run["Bear running"].speed = speed;
            if (!scareBear && !GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }
            if(!scareBear && !barry_running.isPlaying)
            {
                barry_running.Play();
            }
            run.Play("Bear running");
            delay = 10;
        }
    }
}
