using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class data : MonoBehaviour
{
	[SerializeField]
	public GameObject[] boxes;

	public int N;
	public int[] arr = new int[10];
	//public GameObject[] boxes=new GameObject[20];


	public int state = -2;

	public int p;
	public int q;

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


	void realSwap(int i,int j)
	{
		//Debug.Log ("Real swap"+i+" "+j+"=");
		int temp = arr [i];
		arr [i] = arr [j];
		arr[j]=temp;

		GameObject TGO = boxes [i];
		boxes [i] = boxes [j];
		boxes [j] = TGO;
	}




	void Highlight(int i,int j)
	{
		//Debug.Log ("HightLight"+i+" "+j+"=");

		boxes [i].transform.GetChild(0).GetComponent<Renderer> ().material.color = Color.red;
		boxes [j].transform.GetChild(0).GetComponent<Renderer> ().material.color = Color.red;
		state = 2;
	}

	void UnHighlight(int i,int j)
	{
		//Debug.Log ("UnHightLight"+i+" "+j+"=");

		boxes [i].transform.GetChild(0).GetComponent<Renderer> ().material.color = Color.blue;
		boxes [j].transform.GetChild(0).GetComponent<Renderer> ().material.color = Color.blue;

		//real swap
		if (arr [i] >= arr [j])
			realSwap (i, j);

		q++;
		state = 0;
		//Debug.Log ("B="+Time.time);
	}

	void Comeout(int i,int j)
	{
		//Debug.Log ("Comeout"+i+" "+j+"=");

		boxes [i].transform.Translate(Vector3.back*speed);
		boxes [j].transform.Translate(Vector3.back*speed);

		if (boxes [i].transform.position.z<= -1f)
			state = 3;

	}

	void Goin(int i,int j)
	{
		//Debug.Log ("Goin "+i+" "+j+"=");
		boxes [i].transform.Translate(Vector3.forward*speed);
		boxes [j].transform.Translate(Vector3.forward*speed);

		if (boxes [i].transform.position.z >= 0f)
			state = 5;
	}


	void Swap(int i,int j)
	{
		//Debug.Log ("Physical swap "+i+" "+j+"=");
		boxes [i].transform.Translate(Vector3.right*speed);
		boxes [j].transform.Translate(Vector3.left*speed);

		if (boxes [i].transform.position.x >= j)
			state = 4;

		if (boxes [j].transform.position.x <= i)
			state = 4;
	}

	void ProcessBoth(int i,int j)
	{
		//Debug.Log ("Process"+i+" "+j+"=");
		if (arr [i] <= arr [j])
			state = 4;

		else
		{
			Swap (i, j);
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



	int y=1;

	// Update is called once per frame
	void Update () 
	{
		//Debug.Log ("select  p=" + p+ " q=" + q);

		switch (state)
		{
		case -2:PLAY ();break;
		case -1: Fillprefabs ();break;
		case 0: BubbleSort ();break;
		case 1:  Highlight (q, q+1); break;
		case 2:  Comeout (q, q+1);   break;
		case 3:  ProcessBoth (q, q+1);break;
		case 4:  Goin (q, q+1);      break;
		case 5:  UnHighlight (q, q+1);break;
		}

		if (Input.GetKey (KeyCode.M))
			incspeed ();

		if (Input.GetKeyDown (KeyCode.N))
			decspeed ();


	}

	void BubbleSort()
	{
		Debug.Log ("p=" + p+ " q=" + q);

		if (q <N-1)
			state = 1;
		else 
		{
			p++;
			if (p == N)
				state = -1;

			q = 0;
			state = 1;
		}
	}

}
