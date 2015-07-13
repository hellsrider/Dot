using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public enum CameraModes{Smooth, Linear};
	public CameraModes cameraMode;
	public Transform character;
	public Vector3 cameraOffset;
	public float linearSpeed = 10.0f;
	public float smoothTime = 0.25f;
	public float bootDelay = 1.0f;
	private Vector3 velocity = Vector3.zero;
	private bool boot = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine (BootWait ());
		if (!boot)
			return;
		Vector3 target = character.position + cameraOffset;
		switch (cameraMode) {
		case CameraModes.Linear:
			float step = linearSpeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target, step);
			break;
		case CameraModes.Smooth:
			transform.position = Vector3.SmoothDamp (transform.position, target, ref velocity, smoothTime);
			break;
		}
	}

	IEnumerator BootWait() {
		yield return new WaitForSeconds(bootDelay);
		boot = true;
	}
}
