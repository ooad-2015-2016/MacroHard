using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public Vector2 speed = new Vector2 (50, 50);
	public int hp =3;
	
	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (speed.x * inputX, speed.y * inputY);
		movement *= Time.deltaTime;
		transform.Translate (movement);
		bool shoot = Input.GetButtonDown ("Fire1");
		shoot = Input.GetButtonDown ("Fire2");
		if (shoot) {
			WeaponScript weapon = GetComponent<WeaponScript> ();
			if (weapon != null) {
				weapon.Attack (false);
			}
		}
	
	}

	void OnTriggerEnter2D (Collider2D collider) {
		EnemyScript enemy = collider.gameObject.GetComponent<EnemyScript> ();
		if (enemy != null) {
			
			hp -= enemy.damage;
			if (hp <= 0)
				Destroy (this.gameObject);
			
			Destroy (enemy.gameObject);
		}
	}
}

