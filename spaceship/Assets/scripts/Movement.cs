using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour {

	//player input variables
	float Haxis = 0;
	float Vaxis = 0;

	public float rotation_speed;
	public float movement_speed;
	float Rspeed;
	float Mspeed;
	bool accelerate;

	public int health = 100;
	public int power = 2;
	GameObject cam;
	Quaternion Rotation;
    public int team;
    public Movement target;

	void Update () {
		cam = GameObject.FindGameObjectWithTag("MainCamera") as GameObject;
		Rspeed = rotation_speed * Time.deltaTime;
		Mspeed = movement_speed * Time.deltaTime;
		if (gameObject.name == "player") {
			Haxis = Input.GetAxis ("Horizontal");
			Vaxis = Input.GetAxis ("Vertical");
			if (Input.GetKeyDown (KeyCode.Backspace) == true)
			{
				cam.transform.localEulerAngles = new Vector3 (0,180,0);
			}
			if (Input.GetKeyUp (KeyCode.Backspace) == true)
			{
				cam.transform.localEulerAngles = new Vector3 (0,0,0);
			}
			if (Input.GetKey (KeyCode.Space) == true || Input.GetButton ("Thrust") == true){
				accelerate = true;
			}
			else
				accelerate = false;

			if (health <= 0)
				Application.Quit();
			Move ();
			if (Input.GetKey (KeyCode.LeftControl) == true || Input.GetButton("shoot"))
				hitscan();
		} 
		else {
			AI ();
		}
		for (int i = 0;i<Bullets.Count;i++)
		{
			Bullets[i].update();
			if (Bullets[i].Bullet == null){
				Bullets.RemoveAt(i);
				i -=1;
			}
		}
	}
	void Move () {
        transform.rotation *= Quaternion.Euler (Vaxis * Rspeed, Haxis * Rspeed, 0);

		if (accelerate == true)
		{
			rigidbody.AddForce(transform.forward*Mspeed);
		}
	}
	void AI ()
	{
		GameObject Player = GameObject.Find ("player");
		GameObject temp = new GameObject();
		temp.transform.rotation = transform.rotation;
		temp.transform.position = transform.position;
		temp.transform.LookAt (Player.transform.position);
		Vector3 targetangle = temp.transform.eulerAngles;

        transform.rotation = Quaternion.Lerp(transform.rotation, temp.transform.rotation,  Rspeed * 0.05f);
        Destroy(temp);

		int shoottol = 15;
		if (targetangle.x - transform.eulerAngles.x > -shoottol && targetangle.x - transform.eulerAngles.x < shoottol)
				if (targetangle.y - transform.eulerAngles.y > -shoottol && targetangle.y - transform.eulerAngles.y < shoottol)
					hitscan ();
        if (targetangle.x - transform.eulerAngles.x > -shoottol && targetangle.x - transform.eulerAngles.x < shoottol)
        {
            if (targetangle.y - transform.eulerAngles.y > -shoottol && targetangle.y - transform.eulerAngles.y < shoottol)
            {
                if (Vector3.Distance(transform.position, Player.transform.position) > 30)
                    accelerate = true;
                else
                    accelerate = false;
            }
            else
                accelerate = false;
        }
        else
            accelerate = false;
		Move ();

	}
	bullet Bullet;
	public Transform bullet;
	List<bullet> Bullets = new List<bullet>();
	float shoottimer;
	void shoot()
	{
		shoottimer += Time.deltaTime;
		if (gameObject.name == "player") {

			if (shoottimer >= 0.3f)
			{
				if (Input.GetKey (KeyCode.LeftControl) == true || Input.GetButton("shoot")){
					Bullets.Add (ScriptableObject.CreateInstance ("bullet") as bullet);
					Bullets [Bullets.Count - 1].init (50, this.gameObject, bullet, power);
					shoottimer = 0;
				}
			}
		} 
		else {

			if (shoottimer >= 0.3f)
			{
				Bullets.Add (ScriptableObject.CreateInstance ("bullet") as bullet);
				Bullets [Bullets.Count - 1].init (50, this.gameObject, bullet, power);
				shoottimer = 0;
			}

		}

	}

	float hitscantimer;
	public GameObject trail;
	GameObject Trail;
	public Transform startpoint;
	void hitscan ()
	{
		hitscantimer += Time.deltaTime;
		if (hitscantimer >= 0.13f) 
		{
			RaycastHit hit;
			Movement target;
			Vector3 shootangle = transform.forward + new Vector3 (Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f));

			if (Physics.Raycast (startpoint.position, shootangle, out hit)) 
			{
				target = hit.transform.GetComponent ("Movement") as Movement;
				target.health -= power;
			}
			Trail = Instantiate(trail,transform.position + transform.forward * 2,Quaternion.LookRotation(shootangle)) as GameObject;
			Trail.rigidbody.velocity=(Trail.transform.forward *50000);
			Debug.DrawRay (transform.position + transform.forward * 5, shootangle*50);
			hitscantimer = 0;
		}


	}
	bullet colbullet;
	void OnCollisionEnter (Collision col)
	{
		GameObject[]players = GameObject.FindGameObjectsWithTag("Player");

		if (col.gameObject.tag == "bullet")
		{
			bool finished = false;
			foreach (GameObject bo in players)
			{
				Movement move = bo.GetComponent("Movement")as Movement;
				foreach (bullet go in move.Bullets)
				{
					if (go.Bullet != null && go.Bullet.gameObject == col.gameObject)
					{
						colbullet = go;
						finished = true;
						break;
					}
				}
				if (colbullet.Firer.gameObject != this.gameObject)
				{
					health -= colbullet.power;
					Destroy(col.gameObject);
				}
				if (finished == true)
					break;
			}
		}
	}
}






















