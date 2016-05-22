using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public int damage = 1;
	private bool hasSpawn;
	private MoveScript moveScript;
		void Awake()
	{
		// Retrieve scripts to disable when not spawn
		moveScript = GetComponent<MoveScript>();
	}
	// Use this for initialization
	void Start () {
		hasSpawn = false;
		// Disable everything
		// -- collider
		this.gameObject.GetComponent<Collider2D>().enabled=false;
		// -- Moving
		moveScript.enabled = false;
	}

	void Update()
	{
		// 2 - Check if the enemy has spawned.
		if (hasSpawn == false) {
			if (this.gameObject.GetComponent<Renderer>().IsVisibleFrom(Camera.main))
			{
				Spawn();
			}
		} else {
			if (this.gameObject.GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)
			{
				Destroy(gameObject);
			}
		}
	}

	private void Spawn()
	{
		hasSpawn = true;

		// Enable everything
		// -- Collider
		this.gameObject.GetComponent<Collider2D>().enabled=true;	// -- Moving
		moveScript.enabled = true;
	}
}