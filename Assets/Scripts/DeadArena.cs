using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadArena : MonoBehaviour {


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("FA");
        if (collision.gameObject.tag == "ShootBall")
        {

            Destroy(collision.gameObject);
        }
    }

}
