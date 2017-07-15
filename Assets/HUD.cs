using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour {
    Player_Ship player;
    Texture HP_Bar;
	// Use this for initialization
	void Start () {
		
	}
    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, 100, 0), HP_Bar);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
