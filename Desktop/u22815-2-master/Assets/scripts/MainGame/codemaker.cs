using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codemaker : MonoBehaviour {
    automaticgenerator autoscript;
    int[,] map;
    void makecode()
    {
        autoscript = GetComponent<automaticgenerator>();
        map = autoscript.map;


    }

	// Use this for initialization
	void Start () {
	}
	
}
