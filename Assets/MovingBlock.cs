using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
	public Vector3 start;
	public Vector3 end;
	public float speed;
	
    // Start is called before the first frame update
    void Start()
    {
	    transform.position = start;
    }

    // Update is called once per frame
    void Update()
	{
		transform.position = Vector3.Lerp (start, end, Mathf.PingPong(Time.time*speed, 1.0f));
    }
    
	void FixedUpdate()
	{
	    
	}
}
