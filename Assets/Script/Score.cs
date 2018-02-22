using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour {

	public static int score;
    Text txt;
    void Start()
    {
        txt = GetComponent<Text>();
        score = 0;
    }
    void Update()
    {
        if(score < 0)
        {
            score = 0;
        }
        txt.text = "" + score;
    }
    public static void AddPoint(int p)
    {
        score += p;
    }
    public static void Reset()
    {
        score = 0;
    }
}
