using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _timeText;
	
	double secsRound;
	string strSecs;
	double miliRound;
	string strMili;
	
    // Start is called before the first frame update
    void Start()
    {
	    _timeText.text = "Time: " + 0;
    }

    // Update is called once per frame
	void FixedUpdate()
	{
		secsRound = Mathf.RoundToInt((float)Player.seconds);
		if (secsRound <= 9)
		{
			strSecs = 0 + secsRound.ToString();
		}
		else
		{
			strSecs = secsRound.ToString();
		}
		
		miliRound = Mathf.RoundToInt((float)Player.miliSecs);
		if (miliRound <= 99)
		{
			strMili = 0 + miliRound.ToString();
		}
		else if (miliRound == 0)
		{
			strMili = "000";
		}
		else
		{
			strMili = miliRound.ToString();
		}
		
		_timeText.text = "Time: " + Player.minutes + ":" + strSecs + ":" +  strMili;   
    }
}
