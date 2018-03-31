using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DataStructure : MonoBehaviour {

	// Use this for initialization
	public void change_scene(string scene){
		SceneManager.LoadSceneAsync (scene);
}
}
