using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputIS : MonoBehaviour 
{

	insertinscript fix;
	managerIS index;
	public GameObject obj,temp;
	//int count=0;

	//public GameObject BOXES;
	//managerscript MGS;

	void Start(){
		index = obj.GetComponent<managerIS> ();
		fix = temp.GetComponent<insertinscript> ();
		//	MGS = BOXES.GetComponent<managerscript> ();
	}

	public void GetInput(string s)
	{
		Debug.Log ("yo");
		if (index.i == 0) 
		{
			fix.N = int.Parse (s);


		}

		else 
		{
			fix.arr [index.i - 1] = int.Parse(s);
			//MGS.ADD(s,count);  
			//BOXES.GetComponent<managerscript> ().ADD (s, count);
			//count++;  MGS.N++; MGS.ADD
			Debug.Log (fix.arr [index.i-1]);
		}  
		index.i += 1;


	}

}
