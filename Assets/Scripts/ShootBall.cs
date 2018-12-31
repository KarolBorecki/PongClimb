using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour {

    public float destroyTime = 2f;
	
	void Update () {
        destroyTime -= Time.deltaTime;
        if (destroyTime <= 0) Destroy(gameObject);

	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
