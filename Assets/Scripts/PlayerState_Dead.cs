using UnityEngine;
using System.Collections;

public class PlayerState_Dead : PlayerState {

	private Rigidbody2D body;

	public PlayerState_Dead(Player p)
	{
		player = p;
		
		Animator animator = player.GetComponent<Animator>();
		if (animator != null)
		{
			animator.SetBool ("Dead", true);
		}
		
		Transform torch = player.transform.GetChild(1);
		if (torch != null)
		{
			SpriteRenderer renderer = torch.gameObject.GetComponent<SpriteRenderer>();
			if (renderer != null)
			{
				renderer.enabled = false;
			}
		}
		
		CircleCollider2D[] colliders = player.GetComponents<CircleCollider2D>();
		for (int i = 0; i < colliders.Length; ++i)
		{
			colliders[i].enabled = false;
		}
		
		body = player.GetComponent<Rigidbody2D>();
		if (body)
		{
			body.velocity = new Vector2(0.0f, 0.0f);
		}
		
		Debug.Log ("PlayerState is DEAD");
	}

	override public void Update () {}
	override public void FixedUpdate () {}
	override public void Move () {}
	override public void Fire () {}
	override public void TakeDamage () {}
	override public void OnChangeState () {}
	
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
