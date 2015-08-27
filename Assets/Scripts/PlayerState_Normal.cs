using UnityEngine;
using System.Collections;

public class PlayerState_Normal : PlayerState
{
	private Rigidbody2D rigidbody;
	private CountdownTimer fireDelayTimer;
	private FireArm fireArm;
	private Animator animator;

	public PlayerState_Normal(Player p)
	{
		player = p;
		
		rigidbody = player.GetComponent<Rigidbody2D> ();
		fireDelayTimer = new CountdownTimer();
		fireArm = player.gameObject.GetComponentInChildren<FireArm>();
		animator = player.GetComponent<Animator>();
	}

	override public void Update () 
	{
		animator.SetBool ("Walking", rigidbody.velocity.sqrMagnitude > 0.0f);
		Fire();
	}
	
	override public void FixedUpdate () 
	{
		Move();
	}
	
	override public void Move () 
	{
		bool w = Input.GetKey (KeyCode.W);
		bool a = Input.GetKey (KeyCode.A);
		bool s = Input.GetKey (KeyCode.S);
		bool d = Input.GetKey (KeyCode.D);
		
		float actualSpeed;
		
		if ((w && d) || (w && a) || (s && d) || (s && a))
		{
			actualSpeed = player.speed * 0.707f;
		}
		else
		{
			actualSpeed = player.speed;
		}
		
		if (a && !d)
		{
			rigidbody.velocity = new Vector2(-actualSpeed, rigidbody.velocity.y);
		}
		else if (d && !a)
		{
			rigidbody.velocity = new Vector2(actualSpeed, rigidbody.velocity.y);
		}
		else
		{
			rigidbody.velocity = new Vector2(0.0f, rigidbody.velocity.y);
		}
		
		if (w && !s)
		{
			rigidbody.velocity = new Vector2(rigidbody.velocity.x, actualSpeed);
		}
		else if (s && !w)
		{
			rigidbody.velocity = new Vector2(rigidbody.velocity.x, -actualSpeed);
		}
		else
		{
			rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0.0f);
		}
		
		Vector3 lookAtPosition = player.camera.ScreenToWorldPoint(Input.mousePosition) - player.transform.position;
		//float angle = (Mathf.Atan2 (lookAtPosition.y, lookAtPosition.x) * Mathf.Rad2Deg) - 90.0f;
		//player.transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		player.transform.rotation = Quaternion.AngleAxis ((Mathf.Atan2 (lookAtPosition.y, lookAtPosition.x) * Mathf.Rad2Deg) - 90.0f, Vector3.forward);
	}
	
	override public void Fire () 
	{
		if (!fireDelayTimer.done) 
		{
			fireDelayTimer.Update (Time.deltaTime);
		}
		else if (Input.GetButton ("Fire1")) 
		{
			if (fireArm != null)
			{
				fireArm.Fire ();
			}
			GameObject fireball = GameObject.Instantiate (Resources.Load ("Fireball")) as GameObject;
			Transform fireballSpawn = player.transform.GetChild(0);
			if (fireballSpawn != null)
			{
				fireball.transform.position = fireballSpawn.position;
				fireball.transform.rotation = fireballSpawn.rotation;// * Quaternion.Euler (0, 0, 90);
				Fireball fireballBehaviour = fireball.GetComponent<Fireball>();
				if (fireballBehaviour != null)
				{
					fireballBehaviour.speed = player.fireballSpeed;
					fireballBehaviour.maxDistanceSquared = player.fireballMaxDistanceSqrd;
				}
			}
			fireDelayTimer.Start (player.fireDelay);
		}
	}
	
	override public void TakeDamage () 
	{
		if (player.nonregenBarrier != 0)
		{
			player.nonregenBarrier = player.nonregenBarrier - 1;
			
			switch (player.nonregenBarrier)
			{
				case 0:
					if (player.ShieldBar != null)
					{
						player.ShieldBar.SetSprite (player.Shield00);
					}
					break;
				case 1:
					if (player.ShieldBar != null)
					{
						player.ShieldBar.SetSprite (player.Shield50);
					}
					break;
			}
		}
		else
		{
			if (player.regenBarrier != 0)
			{
				player.regenBarrier = player.regenBarrier - 1;
				
				switch (player.regenBarrier)
				{
					case 0:
						if (player.RegenShieldBar != null)
						{
							player.RegenShieldBar.SetSprite (player.RegenShield00);
						}
						break;
					case 1:
						if (player.RegenShieldBar != null)
						{
							player.RegenShieldBar.SetSprite (player.RegenShield50);
						}
						break;
				}
			}
			else
			{
				player.health = player.health - 1;
				
				switch (player.health)
				{
					case 0:
						if (player.HPBar != null)
						{
							player.HPBar.SetSprite (player.HP00);
						}
						player.ChangeState (new PlayerState_Dead(player));
						break;
					case 1:
						if (player.HPBar != null)
						{
							player.HPBar.SetSprite (player.HP33);
						}
						break;
					case 2:
						if (player.HPBar != null)
						{
							player.HPBar.SetSprite (player.HP66);
						}
						break;
				}
			}
		}
	}
	
	override public void OnChangeState () 
	{
		rigidbody.velocity = new Vector2(0, 0);
	}
	
	override public void PickupHealthRegen () {}
	override public void PickupAutoLife () {}
	override public void PickupRunJuice () {}
	override public void PickupRegenBarrier () {}
	override public void PickupVolcanoShells (int number) {}
	override public void PickupIceShot () {}
	override public void PickupLightningShot () {}
	override public void PickupInvincibleAura () {}
	override public void PickupBarrier () {}
}
