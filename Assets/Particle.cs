using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle {
	bool active;
	int age;
	Vector3 position;
	Vector3 direction;
	float speed;
	int maxAge;
	GameObject gameObject;

	public Particle(Vector3 position, float speed, int maxAge, GameObject prefab) {
		active = true;
		age = 0;
		this.position = position;
		this.speed = speed;
		direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
		direction.Normalize();
		direction = direction * speed;
		this.maxAge = maxAge;
		gameObject = GameObject.Instantiate(prefab, position, Quaternion.identity);

		//Debug.Log("Created particle with speed " + speed + " and direction " + direction.x + ", " + direction.y + ", " + direction.z);
	}

	public void Move()
	{
		if(active)
		{
			position = position + direction;
			age++;

			if(age > maxAge)
			{
				Die();
			}
		}
	}
		
	public void Move(Vector3 force)
	{
		direction = direction + force;
		Move();
	}

	public void Draw()
	{
		if(active)
		{
			gameObject.transform.position = position;
		}
	}

	public void Die(){
		active = false;
		GameObject.Destroy(gameObject);
	}

	public bool isAlive()
	{
		return active;
	}
}
