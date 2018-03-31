using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxscript : MonoBehaviour
{
	
	public int index;
	public int data;
	public Transform body;

	// Use this for initialization
	void Start () 
	{
		
	
	}

	public void BORN()
	{
		Debug.Log ("called" + index+" "+data);
		this.transform.position = new Vector3 (index, 0, 0);
		body.transform.Translate (Vector3.up * data / 2);
		body.transform.localScale = new Vector3 (1, data, 1);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
