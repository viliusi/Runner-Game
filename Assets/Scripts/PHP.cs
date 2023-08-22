using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PHP : MonoBehaviour
{
	[SerializeField]
	private TMP_InputField _initials;

	public string url;

	void Start()
	{
		
	}

	public void Submit()
	{
		string initialsText = _initials.text;
		initialsText = initialsText.ToUpper();

		if (initialsText.Length == 2)
		{
            Encoding.Post(initialsText, url, Player.minutes, Player.seconds, Player.miliSecs, Player.deaths, System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day);
		}
		else
		{
			Debug.Log("Initials must be 2 characters long");
		}
	}
}

public abstract class Encoding : System.Net.WebRequest, System.Runtime.Serialization.ISerializable
{
	public static System.Text.Encoding UTF8 { get; }

	public static void Post(string initialsText, string url, double minutes, double seconds, double miliSecs, int deaths, int year, int month, int day)
	{
		byte[] byteArray = Encoding.UTF8.GetBytes("initials=" + initialsText + "&" + 
		"minutes=" + minutes + "&" + 
		"seconds=" + seconds + "&" + 
		"miliseconds=" + miliSecs + "&" + 
		"deaths=" + deaths + "&" + 
		"year=" + year + "&" + 
		"month=" + month + "&" + 
		"day=" + day);

		HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
		webRequest.Method = "POST";
		webRequest.ContentType = "application/x-www-form-urlencoded";
		webRequest.ContentLength = byteArray.Length;

		using (Stream webpageStream = webRequest.GetRequestStream())
		{
			webpageStream.Write(byteArray, 0, byteArray.Length);
		}
	}
}
