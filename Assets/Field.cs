using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

	public Transform Player;

    // Update is called once per frame
    void Update()
	{
		transform.position += new Vector3(Movement.speed, 0, 0);
    }
}
