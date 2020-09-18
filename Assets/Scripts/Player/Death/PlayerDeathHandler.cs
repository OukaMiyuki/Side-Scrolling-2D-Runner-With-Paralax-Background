using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour {

    public delegate void EndGame();
    public static event EndGame endGame;

    void PlayerDeathEndGame() {
        if (endGame != null) {
            endGame();
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Collector") {
            PlayerDeathEndGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Zombie") {
            PlayerDeathEndGame();
        }
    }
}
