using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float CameraOffset;
	public Transform CharacterPos;
	Vector3 p0;

	// Use this for initialization
	void Start () {
		p0 = transform.position;
		p0.x += CameraOffset;
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = p0 + (CharacterPos.position.x * Vector3.right);
	
	}
}
