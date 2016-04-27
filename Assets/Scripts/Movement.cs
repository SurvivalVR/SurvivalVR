using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    public AudioSource baseCamp;
    public AudioSource riverCamp;
    public AudioSource mountainCamp;
    private bool walk;
    public bool walkDisabled;
    private float speed;
    private CardboardHead head;
    public GameObject character;
    private Animator anim;
    private Animator barryAnim;
    private int mode;
    private GameObject target;
    private bool mountain;
    private bool lake;
    private Transform barry_snake;
    // Use this for initialization
    void Start () {
        mountain = false;
        lake = false;
        mode = 0;
        walk = false;
        walkDisabled = false;
        head = Camera.main.GetComponent<StereoController>().Head;
        anim = GameObject.Find("alanwake_awns01").GetComponent<Animator>();
        barryAnim = GameObject.Find("barrywheeler").GetComponent<Animator>();
        anim.SetBool("isWalking", false);
        anim.SetBool("isSprinting", false);
        barryAnim.SetBool("isWalking", false);
        barryAnim.SetBool("isSprinting", false);
        baseCamp.Play();
    }
    void Awake()
    {
        barry_snake = GameObject.Find("barrywheeler_snake").transform;
    }
    void OnTriggerEnter(Collider col) {
        if (col.tag == "ToTheMountain") {
            mountain = true;
            transform.position = new Vector3(7423.346f, -5522.4f, -117.4304f);
            Follow.follow = false;
            GameObject.Find("Friend").transform.position = new Vector3(7425.1f, -5529.258f, -109.4f);
            GameObject.Find("Friend").transform.eulerAngles = new Vector3(0, 186.1648f, 0);
            mode = 0;
            baseCamp.Stop();
            mountainCamp.Play();
        }
        if (col.tag == "ToTheLake") {
            lake = true;
            transform.position = new Vector3(7371.993f, -5796.313f, 2682.001f);
            Follow.follow = false;
            //GameObject.Find("Friend").transform.position = new Vector3(7349.912f, -5803.332f, 2683.377f);
            //GameObject.Find("Friend").transform.eulerAngles = new Vector3(0, 359.9114f, 0);
            mode = 0;
            baseCamp.Stop();
            riverCamp.Play();
            SnackAttack.countdown = true;
        }
    }

    void OnTriggerExit(Collider col)
    {

    }

    public void itemClicked(GameObject t) {
        target = t;
    }

    // Update is called once per frame
    void Update () {
        if (target != null) {
            // do logic for when item is clicked
            Debug.Log(target.name);
        }
        if (transform.rotation.x != 0 || transform.rotation.z != 0) {
            transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
        }
        character.transform.rotation = new Quaternion(0, GameObject.Find("Head").transform.rotation.y, 0, GameObject.Find("Head").transform.rotation.w);
        if (GameObject.Find("CardboardMain").GetComponent<Cardboard>().Triggered && !walkDisabled) {
            if (mode == 2) {
                mode = 0;
            }
            else {
                mode++;
            }
        }
        if (mode == 0) {
            GetComponent<AudioSource>().Pause();
            anim.SetBool("isWalking", false);
            anim.SetBool("isSprinting", false);
        }
        else if (mode == 1) {
            speed = 7;
            transform.position += speed * head.Gaze.direction * Time.deltaTime;
            GetComponent<AudioSource>().UnPause();
            anim.SetBool("isWalking", true);
            anim.SetBool("isSprinting", false);
        }
        else {
            speed = 15;
            transform.position += speed * head.Gaze.direction * Time.deltaTime;
            anim.SetBool("isWalking", false);
            anim.SetBool("isSprinting", true);
        }
        if (lake == true && SnackAttack.start) {
            if (Vector3.Distance(barry_snake.position, transform.position) < 8) {
                mode = 0;
                transform.LookAt(barry_snake);
                transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
                anim.SetBool("isWalking", false);
                anim.SetBool("isSprinting", false);
                anim.SetBool("isKneeling", true);
            }
        }
	}
    void LateUpdate() {
        target = null;
    }
}
