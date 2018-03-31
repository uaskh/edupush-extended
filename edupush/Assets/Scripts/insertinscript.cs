using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class insertinscript : MonoBehaviour
{
	[SerializeField]
	public GameObject[] boxes;

	public int N;
	public int[] arr = new int[10];
	//public GameObject[] boxes=new GameObject[20];


	public int state = -2;

	public int p;
	public int q;
	public int r;
	public GameObject t;
	public int tv;
	public float speed=0.01f;

	void Fillprefabs()
	{

		for (int i = 0; i < N; i++)
		{
			boxes [i].GetComponent<boxscript> ().data = arr [i];
			boxes [i].GetComponent<boxscript> ().index = i;
			boxes [i].transform.GetChild (0).GetComponent<Renderer> ().material.color = Color.blue;
			boxes [i].GetComponent<boxscript> ().BORN ();

		}
		state = 0;
	}


	void HighLightG(int i)
	{
		boxes [i].transform.GetChild(0).GetComponent<Renderer> ().material.color = Color.green;
		state = 2;
	}

	void HighLight(int i)
	{
		boxes [i].transform.GetChild(0).GetComponent<Renderer> ().material.color = Color.red;
	}

	void UnHighlight(int i)
	{
		boxes [i].transform.GetChild (0).GetComponent<Renderer> ().material.color = Color.blue;

		boxes [i + 1] = boxes [i];
		arr [i + 1] = arr [i];

		q--;

		state = 3;


	}

	void HighlightTemp(int i)
	{
		boxes [i].transform.GetChild(0).GetComponent<Renderer> ().material.color = Color.yellow;
		state = 4;

	}

	void Comeout(int i)
	{

		boxes [i].transform.Translate(Vector3.back*speed);

		if (boxes [i].transform.position.z <= -1f)
		{
			t = boxes[i];  tv = arr [i];
			state = 3;
		}

	}











	void shiftright(int i)
	{
		boxes [i].transform.Translate(Vector3.right*speed);

		if (boxes [i].transform.position.x>= (float)(i+1))
			state = 6;
	}

	void walk(int j)
	{
		t.transform.Translate(Vector3.left*speed);

		if (t.transform.position.x<= (float)(j+1))
			state = 8;
	}


	void Compare(int i,int j)
	{
		if (arr [i] > arr[j])
		{
			state = 5;

		} 

		else
		{
			boxes [i].transform.GetChild(0).GetComponent<Renderer> ().material.color = Color.red;

			state = 7;
		}




	}


	void Goin(int i,int j)
	{
		t.transform.Translate(Vector3.forward*speed);

		if (t.transform.position.z >= 0f)
		{
			boxes [j + 1] = t;
			arr [j + 1] = tv;

			boxes [j].transform.GetChild(0).GetComponent<Renderer> ().material.color = Color.grey;
			boxes [j+1].transform.GetChild(0).GetComponent<Renderer> ().material.color = Color.grey;

			p++;
			q = p;  r = q + 1;

			state = 0;

		}
	}

	public void incspeed()
	{  
		speed+=0.1f;
	}

	public void decspeed()
	{
		speed -= 0.1f;
	}



	void PLAY()
	{
		if (Input.GetKey (KeyCode.Space))
			state = -1;

	}




	// Update is called once per frame
	void Update () 
	{
		//Debug.Log ("select  p=" + p+ " q=" + q);
		//boxes [p].transform.GetChild (0).GetComponent<Renderer> ().material.color = Color.red;

		switch (state)
		{
		case -2:PLAY ();break;
		case -1: Fillprefabs ();break;
		case 0: InsertionSort ();break;
		case 1:  HighLightG(r); break;
		case 2:  Comeout (r);   break;
		case 3:  HighlightTemp(q);break;
		case 4:  Compare(q,r);break;
		case 5:  shiftright (q); break;
		case 6: UnHighlight(q); break;
		case 7: walk (q); break;
		case 8: Goin(r,q); break;


		}


	}

	void InsertionSort()
	{
		Debug.Log ("q=" + q + " p=" + p + "r=" + r);

		if (r == N)
			state = -1;

		if (q >= 0)
			state = 1;
		else 
		{
			p++;
			q = p;  r = q + 1;
		}





	}
}
