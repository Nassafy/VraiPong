using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallControler : MonoBehaviour {

	public const float SPEED_INIT = 5;
    private int score;
    public Text textScore;
    private float speed;
    private Vector2 posInitialeBalle;
    
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        speed = SPEED_INIT;
		rb = GetComponent<Rigidbody2D>();
        posInitialeBalle = rb.transform.position;
        rb.velocity = new Vector2(1, 0) * speed;
        score = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
 
        if (coll.collider.gameObject.name == "RacketRigth")
        {
            rebondRacket(coll, -1);
        }

        else if (coll.collider.gameObject.name == "RacketLeft")
        {
            rebondRacket(coll, 1);
        }

        else if (coll.collider.gameObject.CompareTag("WallsDeath"))
        {
            score = 0;
            UpdateScore();
            rb.position = posInitialeBalle;
            speed = SPEED_INIT;
        }
    }

    void rebondRacket(Collision2D racketCollision, float sens)
    {
        //calcul de la trajectoire apres le rebond
        speed = speed * 1.1f;
        score++;
        UpdateScore();
        Vector2 posBall = transform.position;
        Vector2 posRacket = racketCollision.collider.transform.position;
        float racketSize = racketCollision.collider.bounds.size.y;
        rb.velocity =  new Vector2(sens,(posBall.y - posRacket.y) / racketSize).normalized * speed;
    }

    private void UpdateScore()
    {
        textScore.text = "Score : " + score;
    }

}
