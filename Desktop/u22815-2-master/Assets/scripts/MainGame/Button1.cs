using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Button1 : MonoBehaviour {

	public GameObject gameobj;
	public GameObject pause;
	public GameObject restart;
	public GameObject quit;
    GameObject timee;
	movetheballautomatic script;
    timelimitandmemory timescript;
    public void pausebottun()
    {
			script.pauseflag = true;
    }
    public void restartbutton()
    {
        script.restartflag = true;
			script.pauseflag = false;
    }
    public void restartgameover()
    {
        timee = GameObject.Find("timecounter");
        script.clearflag = false;
        timescript = timee.GetComponent<timelimitandmemory>();
        timescript.pauseorquitflag = true;
    }
    public void quitbutton()
    {
			SceneManager.LoadScene ("Title");
        timee = GameObject.Find("timecounter");
        Destroy(timee);
        SceneManager.LoadScene("Title");
    }
    

	// Use this for initialization
	void Start () {
		script = gameobj.GetComponent<movetheballautomatic>(); 
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(script.pauseflag);
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
