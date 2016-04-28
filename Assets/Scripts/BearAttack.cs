using UnityEngine;
using System.Collections;

public class BearAttack : MonoBehaviour {
    public float delay;
    public static bool countdown;
    public static bool start;
    private Animation run;
    private Animator anim;
    public float speed;

    // Use this for initialization
    void Start () {
        countdown = false;
        start = false;
        anim = GameObject.Find("barrywheeler_bear").GetComponent<Animator>();
        run = gameObject.GetComponent<Animation>();
    }
	
	// Update is called once per frame
	void Update () {
        if (countdown) {
            delay -= Time.deltaTime;
        }
        if (delay <= 0) {
            start = true;
            countdown = false;
        }
        if (start) {
            run["Bear running"].speed = speed;
            run.Play("Bear running");
            delay = 10;
        }
    }
}
