using UnityEngine;
using System.Collections;

public class ZombieState_Frozen : ZombieState 
{
	public ZombieState_Frozen(Zombie z)
	{
		zombie = z;
		
		zombie.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
		zombie.GetComponent<Animator>().SetBool ("Frozen", true);
	}

	public override void FixedUpdate () {}
	public override void UpdateAI () {}
	
	public override void OnStateChange () 
	{
		zombie.GetComponent<Animator>().SetBool ("Frozen", false);
	}
}
