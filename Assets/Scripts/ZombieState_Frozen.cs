using UnityEngine;
using System.Collections;

public class ZombieState_Frozen : ZombieState 
{
	public ZombieState_Frozen(Zombie z)
	{
		zombie = z;
		
		Rigidbody2D body = zombie.GetComponent<Rigidbody2D>();
		if (body != null)
		{
			body.velocity = new Vector2(0.0f, 0.0f);
		}
		Animator anim = zombie.GetComponent<Animator>();
		if (anim != null)
		{
			anim.SetBool ("Frozen", true);
		}
	}

	public override void Update () {}
	
	public override void FixedUpdate () {}
	
	public override void UpdateAI () {}
	
	public override void OnStateChange () 
	{
		Animator anim = zombie.GetComponent<Animator>();
		if (anim != null)
		{
			anim.SetBool ("Frozen", false);
		}
	}
}
