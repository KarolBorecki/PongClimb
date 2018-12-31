using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float shootDelay = .1f;
    private float actuallTime = 0f;

    public float shootForce = 1000f;
    public Rigidbody2D shoot;
    public Transform shootTransform;

    public bool isTesting = false;

    private GameController gameController;

	void Start () {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
	}
	
	void Update () {
        if (gameController.isInGame)
        {
            Vector3 mouse = Input.mousePosition;
            mouse = Camera.main.ScreenToWorldPoint(mouse);


            if (Input.GetButton("Fire1"))
            {
                Shoot();
                transform.position = new Vector3(mouse.x, mouse.y, transform.position.y);
            }
            else transform.position = transform.position;
        }
    }

    void Shoot(){
        actuallTime += Time.deltaTime;
        if(actuallTime >= shootDelay){
            Rigidbody2D shootball = Instantiate(shoot, shootTransform.position, transform.rotation) as Rigidbody2D;
            shootball.AddForce(Vector2.up * shootForce);
            actuallTime = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Dead" && !isTesting){
            Dead();
        }
    }

    private void Dead(){
        gameController.GameOver();
    }
}
