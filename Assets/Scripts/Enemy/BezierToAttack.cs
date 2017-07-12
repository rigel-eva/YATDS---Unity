using UnityEngine;
using System.Collections;

public class BezierToAttack :BEnemy {
   new void Update()
    {
        if (spline!=null&&progress<1f)
        {
            base.Update();
        }
        else
        {
            //First let's get the location of our player object
            var playerObject = GameObject.Find("Player");
            transform.Translate((playerObject.transform.position-transform.position).normalized*1f/(duration*5));
        }
    }    
}
