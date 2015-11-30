using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private GameObject light;
	private Vector3 target;

	Vector3 cameraOffset = new Vector3(0, 4, 7);
	Vector3 cameraMoveTo = Vector3.zero;

	// Use this for initialization
	void Start () {
		target = GameObject.Find("BotConstructor").transform.position + (Vector3.up*2f);
		
	}

	void FixedUpdate (){
		transform.position = Vector3.Lerp(transform.position, cameraMoveTo+cameraOffset, 0.01f);

		if (Vector3.Distance(transform.position, cameraMoveTo+cameraOffset)<0.05f){
			cameraMoveTo.x = Random.Range(-2, 2);
			cameraMoveTo.y = Random.Range(-2, 2);
		}

		transform.LookAt(target);
	}
}
