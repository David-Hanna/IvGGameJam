using UnityEngine;
using System.Collections;

public class StoreClosestNodeToPlayer : MonoBehaviour {

	public Transform closestNode { get; private set; }
	public float sqrDistanceToTarget { get; private set; }
	
	private Transform target;
	private CountdownTimer reSearchTimer;
	
	void Start()
	{
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		findClosestNode();
		reSearchTimer = new CountdownTimer();
		reSearchTimer.Start (3.0f);
	}
	
	void Update () 
	{
		reSearchTimer.Update (Time.deltaTime);
		if (reSearchTimer.done)
		{
			findClosestNode();
			reSearchTimer.Start (3.0f);
		}
	}
	
	private void findClosestNode()
	{
		float closestSqrDistance = float.MaxValue;
		for (int i = 0; i < transform.childCount; ++i)
		{
			Transform node = transform.GetChild (i);
			float sqrDistance = (target.position - node.position).sqrMagnitude;
			if (sqrDistance < closestSqrDistance)
			{
				closestSqrDistance = sqrDistance;
				closestNode = node;
			}
		}
		sqrDistanceToTarget = closestSqrDistance;
		//Debug.Log ("Found Closest Node to Player: " + closestNode.ToString ());
	}
}
