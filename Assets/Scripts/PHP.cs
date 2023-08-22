using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PHP : MonoBehaviour
{
	public string URL;
	public WWW WWW;
	
	void Start() {
		StartCoroutine(Upload());
	}

	IEnumerator Upload(){
		yield return Upload1();
		yield return Upload2();
	}

	IEnumerator Upload1() {
		List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
		formData.Add( new MultipartFormDataSection("field1=foo&field2=bar") );
		//formData.Add( new MultipartFormFileSection("my file data", "myfile.txt") );

		UnityWebRequest www = UnityWebRequest.Post(url, formData);
		yield return www.SendWebRequest();

		if(www.isNetworkError || www.isHttpError) {
			Debug.Log(www.error);
		}
		else {
			Debug.Log("Form upload complete!");
			Debug.Log( "MULTIPART: " + www.downloadHandler.text );
		}
	}

	IEnumerator Upload2() {
		WWWForm form = new WWWForm();
		form.AddField("myField", "myData");

		UnityWebRequest www = UnityWebRequest.Post(url, form);
		yield return www.SendWebRequest();

		if(www.isNetworkError || www.isHttpError) {
			Debug.Log(www.error);
		}
		else {
			Debug.Log("Form upload complete!");
			Debug.Log( "WWWForm: " + www.downloadHandler.text );
		}
	}
	}
}
