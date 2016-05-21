using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public int damage = 1;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 20);
	}
	

}
