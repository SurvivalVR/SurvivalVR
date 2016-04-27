using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
    private Animator barryAnim;
    private float speed;
    private Transform target;
    private Transform barry;
    public static bool follow;
    void Awake() {
        barry = transform;
    }
    void Start () {
        barryAnim = GameObject.Find("barrywheeler").GetComponent<Animator>();
        target = GameObject.Find("Main Character").transform;
        speed = 0;
        follow = true;
    }
	
	void Update () {
        if (follow) {
            transform.LookAt(target);
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
            if (Vector3.Distance(barry.position, target.position) > 25) { // run if distance is greater than 10
                speed = 13;
                barryAnim.SetBool("isWalking", false);
                barryAnim.SetBool("isSprinting", true);
            }
            else if (Vector3.Distance(barry.position, target.position) > 15) { // walk if distance is greater than 5
                speed = 7;
                barryAnim.SetBool("isWalking", true);
                barryAnim.SetBool("isSprinting", false);
            }
            else { // stop walking
                speed = 0;
                barryAnim.SetBool("isWalking", false);
                barryAnim.SetBool("isSprinting", false);
            }
            barry.position += speed * barry.transform.forward * Time.deltaTime;
        }
        else {
            speed = 0;
            barryAnim.SetBool("isWalking", false);
            barryAnim.SetBool("isSprinting", false);
        }
    }
}
