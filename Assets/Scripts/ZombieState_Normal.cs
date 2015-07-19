using UnityEngine;
using System.Collections;

public class ZombieState_Normal : ZombieState
{
	private CountdownTimer AIUpdateTimer;
	private Rigidbody2D body;

	public ZombieState_Normal(Zombie z)
	{
		zombie = z;
		
		AIUpdateTimer = new CountdownTimer();
		AIUpdateTimer.Start (1.0f);
		
		body = zombie.GetComponent<Rigidbody2D>();
		zombie.target = zombie.player;
	}

	public override void Update () 
	{
		AIUpdateTimer.Update (Time.deltaTime);
		if (AIUpdateTimer.done)
		{
			UpdateAI();
			AIUpdateTimer.Start (1.0f);
		}
	}
	
	public override void FixedUpdate () 
	{
		if (body != null && zombie.target != null)
		{
			body.velocity = ((zombie.target.transform.position - zombie.transform.position).normalized) * zombie.speed;
			zombie.transform.rotation = Quaternion.AngleAxis ((Mathf.Atan2 (body.velocity.y, body.velocity.x) * Mathf.Rad2Deg) - 90.0f, Vector3.forward);
			if (zombie.animator != null)
			{
				zombie.animator.SetBool ("Walking", true);
			}
		}
	}
	
	public override void UpdateAI () 
	{
//		Vector3 toPlayer = zombie.player.transform.position - zombie.transform.position;
//		zombie.GetComponent<BoxCollider2D>().enabled = false;
//		RaycastHit2D hit = Physics2D.Raycast (zombie.transform.position, toPlayer);
//		zombie.GetComponent<BoxCollider2D>().enabled = true;
//		
//		if (hit.collider != null && hit.collider.tag == "Player")
//		{
//			zombie.target = zombie.player;
//		}
//		else
//		{
//			GameObject nextNode = zombie.manager.FindNextNode(FindClosestNodeToSelf());
//			if (nextNode == null)
//			{
//				zombie.target = null;
//			}
//			else
//			{
//				zombie.target = nextNode;
//			}
//		}
	}
	
//	private GameObject FindClosestNodeToSelf()
//	{
//		GameObject closestNode = null;
//		float shortestDistance = float.MaxValue;
//		
//		for (int i = 0; i < zombie.manager.transform.childCount; ++i)
//		{
//			GameObject node = zombie.manager.transform.GetChild(i).gameObject;
//			Vector3 toNode = node.transform.position - zombie.transform.position;
//			float distance = toNode.sqrMagnitude;
//			if (distance < shortestDistance)
//			{
//				RaycastHit2D hit = Physics2D.Raycast (zombie.transform.position, toNode);
//				
//				if (hit.collider == null)
//					Debug.Log ("Missing");
//				if (hit.collider != null && hit.collider.tag == "ZombiePathNode")
//				{
//					shortestDistance = distance;
//					closestNode = node;
//				}
//			}
//		}
//		return closestNode;
//	}
	
	public override void OnStateChange () {}
}
