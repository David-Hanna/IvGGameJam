using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

	public float speed = 2.0f;

	public int health { get; set; }
	
	public GameObject target { get; set; }
	public GameObject player { get; set; }
	
	private ZombieState state;
	public Animator animator { get; private set; }
	public ZombiePathNodeManager manager { get; private set; }

	void Start () 
	{
		health = 4;
		player = GameObject.FindGameObjectWithTag ("Player");
		state = new ZombieState_Locked (this);
		animator = GetComponent<Animator>();
		manager = GameObject.FindGameObjectWithTag ("ZombiePathNodeManager").GetComponent<ZombiePathNodeManager>();
	}
	
	void Update () 
	{
		state.Update ();
	}
	
	void FixedUpdate ()
	{
		state.FixedUpdate ();
	}
	
	public void TakeDamage (int damage)
	{
		--health;
		if (health == 0)
		{
			Destroy(gameObject);
		}
	}
	
	public void UpdateAI ()
	{
		state.UpdateAI ();
	}
	
	public void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject == player)
		{
			Player playerScript = player.GetComponent<Player>();
			if (playerScript != null)
			{
				playerScript.TakeDamage ();
			}
		}
	}
	
	public void ChangeState(ZombieState newState)
	{
		state.OnStateChange ();
		state = newState;
	}
}
