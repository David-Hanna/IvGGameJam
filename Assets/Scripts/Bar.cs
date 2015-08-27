using UnityEngine;
using System.Collections;

public class Bar : MonoBehaviour {
	
	private SpriteRenderer renderer;
	
	void Start()
	{
		renderer = GetComponent<SpriteRenderer>();
	}
	
	void Update()
	{
	}
	
	public void SetSprite(Sprite sprite)
	{
		renderer.sprite = sprite;
	}
}
