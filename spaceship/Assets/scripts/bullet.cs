using UnityEngine;
using System.Collections;

public class bullet : ScriptableObject {
	public Transform Bullet;
	//public Transform prefab;
	float Speed;
	public GameObject Firer;
	public int power;
	public void init(float speed, GameObject firer, Transform prefab, int Power)
	{
		Bullet = Instantiate (prefab, firer.transform.position, firer.transform.rotation * Quaternion.Euler(90,0,0)) as Transform;
		Bullet.gameObject.GetComponent ("bulletstats");
		Speed = speed;
		Firer = firer;
		power = Power;
	}

	public void update () 
	{
		if (Bullet != null) {
			Bullet.Translate (0, Speed * Time.deltaTime, 0);
			if (Vector3.Distance (Firer.transform.position, Bullet.position) > 500)
				Destroy (Bullet.gameObject);
		}
	}
}
