using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketControllers : MonoBehaviour {

    public float speed = 30;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float dirVertical = Input.GetAxisRaw("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, dirVertical) * speed;
	}
}
