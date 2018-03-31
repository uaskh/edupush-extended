using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour {

	data fix;
	public int i = 0;
	public Text first,fourth,fifth;
	public Button second,seventh;
	public InputField third,sixth;
	private bool flag = true;
	public GameObject obj;

//	managerscript script;

	void Start () {
		fix = obj.GetComponent<data> ();
		//script = temp.GetComponent<managerscript> ();
		/*first = GetComponent<Text> ();
		fourth = GetComponent<Text> ();
		fifth = GetComponent<Text> ();
		second = GetComponent<Button> ();
		third = GetComponent<InputField> ();
		sixth = GetComponent<InputField> ();*/
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("yes");
		if (i > fix.N) {
			//temp.SetActive(true);
			fourth.gameObject.SetActive (false);
			fifth.gameObject.SetActive (false);
			sixth.gameObject.SetActive (false);
			seventh.gameObject.SetActive (false);
		} else {
			if (i == 0) {
				//Debug.Log ("yes yes");
				first.gameObject.SetActive (true);
				second.gameObject.SetActive (true);
				third.gameObject.SetActive (true);
				//first.GetComponent<InputField>().enabled = true;
				//second.GetComponent<Text>().enabled = true;
				//third.GetComponent<Text>().enabled = true;
			} else {
				if (flag) {
					/*first.SetActive (false);
					second.SetActive (false);
					third.SetActive (false);
					fourth.SetActive (true);
					fifth.SetActive (true);
					//fifth.text = "" + i; 
					sixth.SetActive (true);
					flag = false;*/
					first.gameObject.SetActive (false);
					second.gameObject.SetActive (false);
					third.gameObject.SetActive (false);
					fourth.gameObject.SetActive (true);
					fifth.gameObject.SetActive (true);
					fifth.text = "" + i; 
					sixth.gameObject.SetActive (true);
					//sixth.text = "";
					seventh.gameObject.SetActive (true);
				} else {
					fifth.text = "" + i; 
				}
			}
		}
	}
}
