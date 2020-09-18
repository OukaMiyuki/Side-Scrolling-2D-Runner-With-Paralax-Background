using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour {

    public float speed = 0.1f; // 
    private Vector2 offset = Vector2.zero;
    private Material mat;

    void Start() {
        mat = GetComponent<Renderer>().material;
        offset = mat.GetTextureOffset("_MainTex");
        print(offset);
    }

    void Update() {
        offset.x += speed * Time.deltaTime; // move or scroll the backgound
        mat.SetTextureOffset("_MainTex", offset); // scroll the background by using texture offset
    }
}
