using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    public AudioSource baseCamp;
    public AudioSource riverCamp;
    public AudioSource mountainCamp;
    private bool walk;
    private bool walkDisabled;
    public float speed;
    private CardboardHead head;
    public GameObject character;
    private Animator anim;
    private int mode;

    // Use this for initialization
    void Start () {
        mode = 0;
        walk = false;
        walkDisabled = false;
        head = Camera.main.GetComponent<StereoController>().Head;
        anim = GameObject.Find("alanwake_awns01").GetComponent<Animator>();
        anim.SetBool("isWalking", false);
        anim.SetBool("isSprinting", false);
        baseCamp.Play();
    }
	
    void OnTriggerEnter(Collider col) {
        if (col.tag == "ToTheMountain") {
            transform.position = new Vector3(7423.346f, -5522.4f, -117.4304f);
            mode = 0;
            baseCamp.Stop();
            mountainCamp.Play();
        }
        if (col.tag == "ToTheLake") {
            transform.position = new Vector3(7371.993f, -5796.313f, 2682.001f);
            mode = 0;
            baseCamp.Stop();
            riverCamp.Play();
        }
    }

    void OnTriggerExit(Collider col)
    {

    }


    // Update is called once per frame
    void Update () {
        Debug.Log(mode);
        if (transform.rotation.x != 0 || transform.rotation.z != 0)
        {
            transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
        }

        character.transform.rotation = new Quaternion(0, GameObject.Find("Head").transform.rotation.y, 0, GameObject.Find("Head").transform.rotation.w);

        if (GameObject.Find("CardboardMain").GetComponent<Cardboard>().Triggered && !walkDisabled)
        {
            if (mode == 2)
            {
                mode = 0;
            }
            else
            {
                mode++;
            }
        }
        if (mode == 0)
        {
            GetComponent<AudioSource>().Pause();
            anim.SetBool("isWalking", false);
            anim.SetBool("isSprinting", false);
        }
        else if (mode == 1)
        {
            speed = 7;
            transform.position += speed * head.Gaze.direction * Time.deltaTime;
            GetComponent<AudioSource>().UnPause();
            anim.SetBool("isWalking", true);
            anim.SetBool("isSprinting", false);
            //character.GetComponent<Animator>().SetTrigger(isWalking, true);
        }
        else {
            speed = 15;
            anim.SetBool("isWalking", false);
            anim.SetBool("isSprinting", true);
            transform.position += speed * head.Gaze.direction * Time.deltaTime;
        }
	}
}
