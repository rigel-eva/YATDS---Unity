using UnityEngine;
using System.Collections;

public class Player_Ship : MonoBehaviour {
    public float hp = 1.0f;
    public Texture hp_bar_fill;
    public Texture hp_bar_background;
    public Texture hp_bar_foreground;
    public Camera playerCamera;
    public Rect hp_Area;
    public float Hit_Points
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }
	// Use this for initialization
	void Start () {
        //Let's go ahead and get our bounds for where we can move
        //TODO: add in bounding script

    }
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, hp_bar_background.width, hp_bar_background.height), hp_bar_background);
        GUI.DrawTextureWithTexCoords(new Rect(hp_Area.x,hp_Area.y,hp_Area.width*hp,hp_Area.height), hp_bar_fill, new Rect(0, 0, hp_Area.width / hp_bar_fill.width*hp, hp_Area.height / hp_bar_fill.height*hp));
        GUI.DrawTexture(new Rect(0, 0, hp_bar_foreground.width, hp_bar_foreground.height), hp_bar_foreground);
    }
    // Update is called once per frame
    void Update () {
        const float speed = 0.125f;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, speed, 0);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -speed, 0);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed, 0, 0);
        }
        if (Input.GetKeyUp(KeyCode.Home))
        {
            playerCamera.orthographic = !playerCamera.orthographic;
        }
	}
}
