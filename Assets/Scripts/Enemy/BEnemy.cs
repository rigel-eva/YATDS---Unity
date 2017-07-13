using UnityEngine;
using System.Collections;

public class BEnemy : MonoBehaviour {
    public BezierSpline spline;
    public float duration;
    protected float progress;
    protected bool killNextFrame = false;
    // Use this for initialization
    void Start () {
        progress = 0f;
	}
	
	// Update is called once per frame
	public void Update () {
        if (spline != null)
        {
            progress += Time.deltaTime / duration;
            if (killNextFrame)
            {
                Destroy(this.gameObject);//Kill Ourself if we are done
            }
            if (progress > 1f)
            {
                progress = 1f;
                killNextFrame = true;
            }
            transform.localPosition = spline.GetPoint(progress);

        }
    }
    void OnHitPlayer(Player_Ship player){
        player.Hit_Points -= .2f;
		Destroy(this.gameObject);//Kill ourself if we collide with the player

	}
    void OnTriggerEnter2D(Collider2D col)
    {
        print(col.gameObject.name);
        if (col.gameObject.name == "Player")
        {
            OnHitPlayer((Player_Ship)col.gameObject.GetComponent<Player_Ship>());
        }
    }
}

