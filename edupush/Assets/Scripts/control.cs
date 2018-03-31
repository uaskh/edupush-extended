using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class control : MonoBehaviour
{
	public void changescene(string scene)
	{
		SceneManager.LoadSceneAsync (scene);
	}

}
