using UnityEngine;
using System.Collections;

public class MainCharacter_Controller : MonoBehaviour {
    Animator anim;
    private bool walking = false;
    private CardboardHead head;
    public float speed;
	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
        head = Camera.main.GetComponent<StereoController>().Head;
    }
	
	void Update () {
        transform.position = head.Gaze.direction;
        if (GameObject.Find("CardboardMain").GetComponent<Cardboard>().Triggered)
        {
            walking = !walking;
            Debug.Log(speed * head.Gaze.direction * Time.deltaTime);
            gameObject.GetComponent<Rigidbody>().transform.position += speed * head.Gaze.direction * Time.deltaTime;
            anim.SetBool("isWalking", walking);
        }
    }
}
