using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

	Transform target;

	void Start () 
	{
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	void Update () 
	{
		transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
	}
}
