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
	
	public override void FixedUpdate () 
	{
		AIUpdateTimer.Update (Time.fixedDeltaTime);
		if (AIUpdateTimer.done)
		{
			UpdateAI();
			AIUpdateTimer.Start (1.0f);
		}
	
		if (zombie.target != null)
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
	}
	
	public override void OnStateChange () {}
}
