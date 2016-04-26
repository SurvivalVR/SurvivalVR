using UnityEngine;
using System.Collections;

public class TeleportCamera : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = new Vector3(300, 100, 0);
            //camera.main.transform.position = new Vector3(300, 100, 0);
        }
    }
}
