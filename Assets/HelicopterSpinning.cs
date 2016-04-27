using UnityEngine;
using System.Collections;

public class HelicopterSpinning : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 50, 0 * Time.deltaTime);
	}
}
