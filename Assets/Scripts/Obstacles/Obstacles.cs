using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Obstacles : MonoBehaviour {

    private float speed = -3;
    private Rigidbody2D myBody;

    void Awake() {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        myBody.velocity = new Vector2(speed, 0);
    }
}
