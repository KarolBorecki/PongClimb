using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public int blockLive = 20;
    public int recoil = 200;

    private Rigidbody2D rb;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision){
        rb.bodyType = RigidbodyType2D.Dynamic;
        blockLive -= 1;

        if (collision.gameObject.tag == "ShootBall"){
            rb.AddForce(Vector2.up * recoil);
        }
        if (blockLive <= 0) dead();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        blockLive -= 1;
    }

    private void dead(){
        Destroy(gameObject);
    }

}
