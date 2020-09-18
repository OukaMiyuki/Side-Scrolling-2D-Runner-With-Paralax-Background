using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour {

    // this is basically called event and delegate
    // learn more about it here : https://www.youtube.com/watch?v=jQgwEsJISy0&ab_channel=ProgrammingwithMosh
    // or here : https://www.youtube.com/watch?v=WyrW-i73VGo&ab_channel=JamieKing
    // or maybe here : https://www.youtube.com/watch?v=l3iK-Vp2Nm8&ab_channel=THEENK
    // and here again : https://www.youtube.com/watch?v=qwQ16sS8FSs&ab_channel=GameDevHQ
    // last but not least : https://www.youtube.com/watch?v=el-kKK-7SBU&ab_channel=PontusWittenmark
    // oh and maybe you'd like more reading than watching : https://www.dicoding.com/blog/mengenal-konsep-event-dan-delegate-untuk-berkomunikasi-antar-object-di-unity/
    //
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
