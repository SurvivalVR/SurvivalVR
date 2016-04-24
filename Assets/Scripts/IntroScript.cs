using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroScript : MonoBehaviour {
    TextMesh text;
    Color col;
    float time = 0.0f;
    bool fade = false;
	// Use this for initialization
	void Start () {
        text = gameObject.GetComponent<TextMesh>();
        col = text.color;
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        col = text.color;
        Debug.Log(time);
        if (fade && text.color.a >= 0.0) {
            col.a -= 0.001f;
            text.color = col;
            if (col.a <= 0) {
                fade = false;
                col.a = 1;
            }
        }
        if (time >= 12) {
            text.text = "";
        }
        else if (time >= 9) {
            text.text = "The nearest ranger is two hours away.";
            fade = true;
        }
        else if (time >= 6) {
            text.text = "It's just you and your friend.";
            fade = true;
        }
        else if (time >= 3) {
            text.text = "You've gone camping at a National Park.";
            fade = true;
        }
        else
        {
            text.text = "";
        }
	}
}
