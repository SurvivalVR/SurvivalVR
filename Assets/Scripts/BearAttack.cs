using UnityEngine;
using System.Collections;

public class BearAttack : MonoBehaviour {
    public float delay;
    public static bool countdown;
    public static bool start;
    private Animator anim;

    // Use this for initialization
    void Start () {
        countdown = false;
        start = false;
        anim = GameObject.Find("barrywheeler_bear").GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (countdown) {
            delay -= Time.deltaTime;
        }
    }
}
