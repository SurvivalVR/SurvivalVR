using UnityEngine;
using System.Collections;

public class SnackAttack : MonoBehaviour {
    public float delay;
    public static bool countdown;
    public static bool start;
    private Animator anim;
    private GameObject trigger;
	// Use this for initialization
	void Start () {
        countdown = false;
        start = false;
        anim = GameObject.Find("barrywheeler_snake").GetComponent<Animator>();
        trigger = GameObject.Find("InteractItem_Poison");
        trigger.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
        if (countdown) {
            delay -= Time.deltaTime;
        }
        Debug.Log(delay);
        if (delay <= 0) {
            start = true;
            countdown = false;
        }
        if (start) {
            anim.SetBool("isBitten", true);
            trigger.SetActive(true);
        }
    }
}
