using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
	void OnTriggerEnter(Collider collision)                     // used for things like bullets, which are triggers.  
	{
		SceneManager.LoadScene(2);
	}
}