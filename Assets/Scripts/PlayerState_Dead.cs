using UnityEngine;
using System.Collections;

public class PlayerState_Dead : PlayerState {

	private Rigidbody2D body;

	public PlayerState_Dead(Player p)
	{
		player = p;
		
		player.GetComponent<Animator>().SetBool ("Dead", true);
		
		player.transform.GetChild (1).gameObject.GetComponent<SpriteRenderer>().enabled = false;
		
		CircleCollider2D[] colliders = player.GetComponents<CircleCollider2D>();
		for (int i = 0; i < colliders.Length; ++i)
		{
			colliders[i].enabled = false;
		}
		
		player.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
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
