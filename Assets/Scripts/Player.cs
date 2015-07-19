using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public bool autolife = false;
	public bool burst = false;
	public bool runJuice = false;

	public float speed = 5.0f;
	public float fireDelay = 0.5f;
	public float burstMultiplier = 2.0f;
	
	public float fireballSpeed = 7.5f;
	public float fireballMaxDistanceSqrd = 30.0f;
	
	public Sprite HP00;
	public Sprite HP33;
	public Sprite HP66;
	public Sprite HP100;
	public Bar HPBar { get; private set; }
	
	public Sprite RegenShield00;
	public Sprite RegenShield50;
	public Sprite RegenShield100;
	public Bar RegenShieldBar { get; private set; }
	
	public Sprite Shield00;
	public Sprite Shield50;
	public Sprite Shield100;
	public Bar ShieldBar { get; private set; }

	private PlayerState state;

	public int health { get; set; }
	public int regenBarrier { get; set; }
	public int nonregenBarrier { get; set; }
	public Camera camera { get; private set; }

	private int MAX_HEALTH = 3;
	private int MAX_REGEN_BARRIER = 2;
	private int MAX_NON_REGEN_BARRIER = 2;

	void Start () 
	{
		GameObject HPBarObject = GameObject.FindGameObjectWithTag ("HPBar");
		if (HPBarObject != null)
		{
			HPBar = HPBarObject.GetComponent<Bar>();
			if (HPBar != null)
			{
				HPBar.SetSprite (HP100);
			}
		}
		
		GameObject RegenShieldBarObject = GameObject.FindGameObjectWithTag ("RegenerableShieldBar");
		if (RegenShieldBarObject != null)
		{
			RegenShieldBar = RegenShieldBarObject.GetComponent<Bar>();
			if (RegenShieldBar != null)
			{
				RegenShieldBar.SetSprite (RegenShield00);
			}
		}
		
		GameObject NonRegenShieldBarObject = GameObject.FindGameObjectWithTag ("NonRegenerableShieldBar");
		if (NonRegenShieldBarObject != null)
		{
			ShieldBar = NonRegenShieldBarObject.GetComponent<Bar>();
			if (ShieldBar != null)
			{
				ShieldBar.SetSprite (Shield00);
			}
		}
	
		state = new PlayerState_Locked (this);

		health = MAX_HEALTH;
		regenBarrier = 0;
		nonregenBarrier = 0;
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
	}

	void Update () 
	{
		state.Update ();
	}

	void FixedUpdate() 
	{
		state.FixedUpdate ();
	}

	private void Move () 
	{
		state.Move ();
	}

	private void Fire () 
	{
		state.Fire ();
	}

	public void TakeDamage () 
	{
		state.TakeDamage ();
	}
	
	public void ChangeState (PlayerState nextState) 
	{
		state.OnChangeState ();
		state = nextState;
	}
	
	public void PickupHealthRegen () 
	{
		state.PickupHealthRegen ();
	}
	
	public void PickupAutoLife () 
	{
		state.PickupAutoLife ();
	}
	
	public void PickupRunJuice () 
	{
		state.PickupRunJuice ();
	}
	
	public void PickupRegenBarrier () 
	{
		state.PickupRegenBarrier ();
	}
	
	public void PickupVolcanoShells (int number) 
	{
		state.PickupVolcanoShells (number);
	}
	
	public void PickupIceShot () 
	{
		state.PickupIceShot ();
	}
	
	public void PickupLightningShot () 
	{
		state.PickupLightningShot ();
	}
	
	public void PickupInvincibleAura () 
	{
		state.PickupInvincibleAura ();
	}
	
	public void PickupBarrier () 
	{
		state.PickupBarrier ();
	}
}
