using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework : MonoBehaviour {

	List<Particle> particles;

	public int numParticles;
	public float speed;
	public int maxAge;
	public GameObject prefab;
	public float gravity;

	// Use this for initialization
	void Start () {
		particles = new List<Particle>();
		Init();
	}


	public void Init(){
		for(int i=0; i<numParticles; i++)
		{
			particles.Add(new Particle(transform.position, speed + Random.Range(-2f, 2f), maxAge, prefab));
		}
	}
	
	// Update is called once per frame
	void Update () {
		Move();
		Draw();

		if(isFinished())
		{
			Init();
		}
	}

	public void Move() {
		for(int i=0; i<particles.Count; i++)
		{
			particles[i].Move(Vector3.down * gravity);
			if(!particles[i].isAlive())
			{
				particles.Remove(particles[i]);
			}
		}
	}

	public void Draw() {
		for(int i=0; i<particles.Count; i++)
		{
			particles[i].Draw();
		}
	}

	public bool isFinished()
	{
		return particles.Count == 0;
	}
}
