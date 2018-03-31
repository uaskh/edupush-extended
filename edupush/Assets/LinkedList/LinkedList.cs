using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedList : MonoBehaviour {

	public GameObject[] element = new GameObject[7];

	int i;

	// Use this for initialization
	void Start () {
		for (i=0; i < 6; i++) {
			element [i].transform.localScale = new Vector3 (1,  1, 1);
			element [++i].transform.localScale = new Vector3 (0.1f,  1.2f, 0.1f);
			element [++i].transform.localScale = new Vector3 (0.2f,  0.2f, 0.2f);
		}
		element [i].transform.localScale = new Vector3 (1,  1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
