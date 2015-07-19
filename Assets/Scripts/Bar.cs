using UnityEngine;
using System.Collections;

public class Bar : MonoBehaviour {
	
	private SpriteRenderer renderer;
	private Transform target;
	private Vector3 offsetFromTarget;
	
	void Start()
	{
		renderer = GetComponent<SpriteRenderer>();
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		if (target != null)
		{
			offsetFromTarget = target.position - transform.position;
		}
	}
	
	void Update()
	{
		if (target != null)
		{
			transform.position = new Vector3(target.position.x - offsetFromTarget.x, target.position.y - offsetFromTarget.y, transform.position.z);
		}
	}
	
	public void SetSprite(Sprite sprite)
	{
		if (renderer != null)
		{
			renderer.sprite = sprite;
		}
	}
}
