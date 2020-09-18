using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerJumpControl : MonoBehaviour {

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpClipSound;
    private float jumpForce = 12f;
    private float forwardForce = 0;
    private Rigidbody2D myBody;
    private bool canJump;
    private Button jumpButton;

    void Start() {
        myBody = GetComponent<Rigidbody2D>();
        jumpButton = GameObject.Find("Jump Button").GetComponent<Button>();
        jumpButton.onClick.AddListener(
            () => Jump()    
        );
    }

    void Update() {
        if (Mathf.Abs(myBody.velocity.y) == 0) {
            canJump = true;
        }
    }

    public void Jump() {
        if (canJump) {
            canJump = false;
            audioSource.PlayOneShot(jumpClipSound);
            if (transform.position.x < 0) {
                forwardForce = 1f;
            } else {
                forwardForce = 0f;
            }

            myBody.velocity = new Vector2 (forwardForce, jumpForce);
        }

    }
}
