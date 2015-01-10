using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pebble : MonoBehaviour {


	public GameObject prefab;
	public GameObject player;
	Vector3 pebbleballcentre;
	List<GameObject> pebbles = new List<GameObject>();
	public int radius;
	public int quantity;
	void Start () {
		pebbleballcentre = transform.position;
		for (int i = 0; i<quantity; i++) 
		{
			pebbles.Add (Instantiate (prefab, pebbleballcentre + new Vector3 (Random.Range (-radius, radius), Random.Range (-radius, radius), Random.Range (-radius, radius)), Quaternion.Euler (0, 0, 1))as GameObject);
			if (Vector3.Distance(pebbles[pebbles.Count-1].transform.position, pebbleballcentre)>radius)
			{
				Destroy(pebbles[pebbles.Count-1]);
				pebbles.RemoveAt(pebbles.Count-1);
				i--;
			}
		}

	}

	void Update () {
		if (pebbleballcentre != transform.position) {
			pebbleballcentre = transform.position;
			List<GameObject> remove = new List<GameObject>();
			for (int i = 0; i<pebbles.Count; i++) 
			{
				if (Vector3.Distance (pebbles [i].transform.position, pebbleballcentre) > radius) 
				{
					remove.Add(pebbles[i]);
				}
			}
			foreach(GameObject go in remove)
			{
				pebbles.Remove (go);
				Destroy (go);
			}
			int count = pebbles.Count;
			for (int i = 0; i<quantity - count; i++) 
			{
				pebbles.Add (Instantiate (prefab, pebbleballcentre + new Vector3 (Random.Range (-radius, radius), Random.Range (-radius, radius), Random.Range (-radius, radius)), Quaternion.Euler (0, 0, 1))as GameObject);
				if (Vector3.Distance (pebbles [pebbles.Count - 1].transform.position, pebbleballcentre)>radius) 
				{
					Destroy (pebbles [pebbles.Count - 1]);
					pebbles.RemoveAt (pebbles.Count - 1);
					i--;
				}
			}
		}


		foreach (GameObject go in pebbles)
		{
			go.transform.LookAt (transform.position);
			go.transform.Rotate (90, 0, 0, Space.Self);
			//go.renderer.material.color = new Color(0,0,0, 1f);
		}

	}
}
