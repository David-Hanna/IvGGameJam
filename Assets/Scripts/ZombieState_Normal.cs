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
		if (zombie.target != null)
		{
			UpdateAI();
		}
		AIUpdateTimer.Start (0.5f);
		body = zombie.GetComponent<Rigidbody2D>();
		//Debug.Log ("Zombie State is NORMAL.");
	}

	public override void Update () 
	{
		AIUpdateTimer.Update (Time.deltaTime);
		if (AIUpdateTimer.done)
		{
			UpdateAI();
			AIUpdateTimer.Start (0.5f);
		}
	}
	
	public override void FixedUpdate () 
	{
		if (body != null && zombie.node != null)
		{
			body.velocity = ((zombie.node.position - zombie.transform.position).normalized) * zombie.speed;
			zombie.transform.rotation = Quaternion.AngleAxis ((Mathf.Atan2 (body.velocity.y, body.velocity.x) * Mathf.Rad2Deg) - 90.0f, Vector3.forward);
			if (zombie.animator != null)
			{
				zombie.animator.SetBool ("Walking", true);
			}
		}
	}
	
	public override void UpdateAI () 
	{
		//zombie.node = zombie.target;
		Vector3 toPlayer = zombie.target.position - zombie.transform.position;
		RaycastHit2D hit = Physics2D.Raycast (zombie.transform.position, toPlayer, toPlayer.magnitude);
		if (hit.collider != null)
		{
			if (hit.collider.tag == "Player")
			{
				zombie.node = zombie.target;
			}
			else if (zombie.node != zombie.target)
			{
				ZombiePathNode algorithm = zombie.node.gameObject.GetComponent<ZombiePathNode>();
				Transform nextClosestNode = algorithm.nextClosestNode ();
				if (nextClosestNode != null)
				{
					zombie.node = nextClosestNode;
					//Debug.Log ("Going to node: " + zombie.node.ToString ());
				}
				else
				{
					zombie.node = zombie.target;
				}
			}
		}
	}
	
	public override void OnStateChange () {}
}
