using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIcontroller : MonoBehaviour {

	void Start () {
	
	}
    List<List<Movement>> teams = new List<List<Movement>>(); 
	void Update () {
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
        List<Movement> PlayMoves = new List<Movement>();
        for (int i = 0; i < Players.GetLength(0); i++) 
            PlayMoves.Add(Players[i].GetComponent("Movement") as Movement);
        for (int i = 0; i < PlayMoves.Count; i++){
            while (PlayMoves[i].team > teams.Count - 1) teams.Add(new List<Movement>());
            teams[i].Add(PlayMoves[i]);
        }
        foreach(Movement player in PlayMoves)
        {
            Movement target = null;
            for (int t = 0; t < teams.Count; t++)
            {
                for (int p = 0; p < teams[t].Count; p++)
                {
                    if (Vector3.Distance(teams[t][p].transform.position, player.transform.position) < Vector3.Distance(target.transform.position, player.transform.position) || target == null)
                        target = teams[t][p];
                }
            }
            player.target = target;
        }
	}
}
