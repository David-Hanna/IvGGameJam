using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

	public float speed = 2.0f;

	public int health { get; set; }
	public Transform node { get; set; }
	
	private ZombieState state;
	public Transform target { get; private set; }
	public Animator animator { get; private set; }

	void Start () 
	{
		health = 4;
		state = new ZombieState_Locked (this);
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		animator = GetComponent<Animator>();
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
		if (collider.gameObject.tag == "Player")
		{
			Player player = collider.gameObject.GetComponent<Player>();
			if (player != null)
			{
				player.TakeDamage ();
			}
		}
		else if (collider.gameObject.tag == "ZombiePathNode")
		{
			node = collider.transform;
			//Debug.Log ("Hit path node: " + node.ToString ());
		}
	}
	
	public void ChangeState(ZombieState newState)
	{
		state.OnStateChange ();
		state = newState;
	}
}
