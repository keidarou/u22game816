using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {

	public GameObject gameobj;
	public GameObject pause;
	public GameObject restart;
	public GameObject quit;

	movetheball script;

	public void ButtonClick() {
		switch (transform.name) {
		case "Pause":
			script.pauseflag = true;
			break;
		case "Restart":
			script.pauseflag = false;
			break;
		case "Quit":
			SceneManager.LoadScene ("StageSelect");
			break;
		default:
			break;
		}
	}

	// Use this for initialization
	void Start () {
		script = gameobj.GetComponent<movetheball>(); //unitychanの中にあるUnityChanScriptを取得して変数に格納する
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(script.pauseflag);
		if (script.pauseflag == false) {
			restart.SetActive (false);
			quit.SetActive (false);
			pause.SetActive (true);
		} else {
			restart.SetActive (true);
			quit.SetActive (true);
			pause.SetActive (false);

		}

	}

}
