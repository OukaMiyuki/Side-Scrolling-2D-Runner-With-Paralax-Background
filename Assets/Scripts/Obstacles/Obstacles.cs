using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Obstacles : MonoBehaviour {

    private float speed = -3; // set the obstacles to run to the right (negative value in the x axes)
    private Rigidbody2D myBody;

    void Awake() {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        myBody.velocity = new Vector2(speed, 0); // move the obstacles or make it run opr move to the left
    }
}
