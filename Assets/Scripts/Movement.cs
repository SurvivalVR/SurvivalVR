using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    private bool walk;
    private bool walkDisabled;
    public float speed;
    private CardboardHead head;
    public GameObject character;
    private Animator anim;

    // Use this for initialization
    void Start () {
        walk = false;
        walkDisabled = false;
        head = Camera.main.GetComponent<StereoController>().Head;
        anim = GameObject.Find("alanwake_awns01").GetComponent<Animator>();
    }
	
    void OnTriggerEnter(Collider col) {
        if (col.tag == "ToTheMountain") {
            transform.position = new Vector3(7423.346f, -5522.4f, -117.4304f);
            walk = false;
            anim.SetBool("isWalking", walk);
        }
        if (col.tag == "ToTheLake") {
            transform.position = new Vector3(7371.993f, -5796.313f, 2682.001f);
            walk = false;
            anim.SetBool("isWalking", walk);
        }
    }

    void OnTriggerExit(Collider col)
    {

    }


    // Update is called once per frame
    void Update () {
        if (transform.rotation.x != 0 || transform.rotation.z != 0)
        {
            transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
        }

        character.transform.rotation = new Quaternion(0, GameObject.Find("Head").transform.rotation.y, 0, GameObject.Find("Head").transform.rotation.w);

        if (GameObject.Find("CardboardMain").GetComponent<Cardboard>().Triggered && !walkDisabled)
        {
            walk = !walk;
            anim.SetBool("isWalking", walk);
        }
        if (walk)
        {
            transform.position += speed * head.Gaze.direction * Time.deltaTime;
            GetComponent<AudioSource>().UnPause();
            //character.GetComponent<Animator>().SetTrigger(isWalking, true);
        }
        else {
            GetComponent<AudioSource>().Pause();
            walk = false;
        }
	}
}
