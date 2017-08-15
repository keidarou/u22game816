﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class timelimitandmemory : MonoBehaviour
{

    public int clearcount = 0;
    public Texture2D tex;
    public Font f;
    private GUIStyle labelStyle;
    public string scenename;
    private GUIStyle Highscore;
    public bool gameoverflag = false;
    float timer;
    public bool pauseorquitflag = false;
    movetheballautomatic script;
    public GameObject movetheballl;
   
    public void gameovernisaseru()
    {
        gameoverflag = true;
    }
    public void zenkaivoid()
    {
        clearcount++;
        Debug.Log(clearcount);
    }
    static timelimitandmemory _instance = null;

    // オブジェクト実体の参照（初期参照時、実体の登録も行う）
    static timelimitandmemory instance
    {
        get { return _instance ?? (_instance = FindObjectOfType<timelimitandmemory>()); }
    }

    void Awake()
    {
        if (this != instance)
        {
            Destroy(gameObject);
            return;
        }

        // 以降破棄しない
        DontDestroyOnLoad(gameObject);

    }

    void OnDestroy()
    {
        if (this == instance) _instance = null;

    }
    // Use this for initialization
    void Start()
    {
       
        this.labelStyle = new GUIStyle();
        this.labelStyle.fontSize = Screen.height / 20;
        this.labelStyle.normal.textColor = Color.white;
        Highscore = new GUIStyle();
        Highscore.fontSize = Screen.height / 15;
        Highscore.normal.textColor = Color.red;
        labelStyle.font = f; Highscore.font = f;
    }

    // Update is called once per frame
    void Update()
    {
        movetheballl = GameObject.Find("MoveTheBall");
        script = movetheballl.GetComponent<movetheballautomatic>();
        if (script.pauseflag == false)
        {
            if (timer > 100||gameoverflag) { gameoverflag = true; }
            else
            {
                timer += Time.fixedDeltaTime;
            }
        }

    }
    void OnGUI()
    {
        string s = string.Format("{0}Seconds Left", 100 - (int)timer);
        string str = string.Format("Score : {0}", (int)clearcount);
        GUI.Label(new Rect(Screen.width-300, Screen.height-50, 100, 30), str, labelStyle);
        GUI.Label(new Rect(20, Screen.height-50, 100, 30), s, labelStyle);
        if (gameoverflag == true)
        {
            int imamadenomax = PlayerPrefs.GetInt(scenename, 0);
         //   Debug.Log(imamadenomax);
            if (imamadenomax < clearcount)//もしハイスコアなら
            {
                GUI.Label(new Rect(Screen.width / 2-150, Screen.height/2-160, 200, 30), "Highscore!!", Highscore);//表示されない
                string sscore = string.Format("Highscore : {0}    Your Score : {0}", (int)clearcount);
               // Debug.Log(sscore);
                GUI.Label(new Rect(Screen.width / 2-400, Screen.height/2 - 50, 100, 30), sscore, labelStyle);
            }
            else
            {
                string sscore = string.Format("Highscore : {0}    Your Score : {1}",(int)imamadenomax, (int)clearcount);
                GUI.Label(new Rect(Screen.width / 2-400, Screen.height/2 - 50, 100, 60), sscore, labelStyle);
            }
            script.gameoverflag = true;
            if (pauseorquitflag)
            {
                SceneManager.LoadScene(scenename);
                timer = 0;clearcount = 0;
                pauseorquitflag = false;
                gameoverflag = false;
            }
        }
    }
}
