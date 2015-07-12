using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public enum CameraModes{Smooth, Linear};
	public CameraModes CameraMode;
	public Transform Character;
	public Vector3 CameraOffset;
	public float LinearSpeed = 10.0f;
	public float SmoothTime = 0.25f;
	public float BootDelay = 1.0f;
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
		Vector3 target = Character.position + CameraOffset;
		switch (CameraMode) {
		case CameraModes.Linear:
			float step = LinearSpeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target, step);
			break;
		case CameraModes.Smooth:
			transform.position = Vector3.SmoothDamp (transform.position, target, ref velocity, SmoothTime);
			break;
		}
	}

	IEnumerator BootWait() {
		yield return new WaitForSeconds(BootDelay);
		boot = true;
	}
}
