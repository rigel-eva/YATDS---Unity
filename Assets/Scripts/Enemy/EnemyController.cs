using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour {

    // Use this for initialization
    public List<GameObject> spawns;//This is horrible, but I'm not going to implement a tuple class because Mono decided it's not going to.
    public List<float> spawnTimes;
    public List<BezierSpline> splines;
	void onDrawGizmos(){
		Gizmos.color = new Color (1, 0, 0);
		Gizmos.DrawCube(transform.position,new Vector3(.5f,.5f,.5f));
	}
	void Start () {
        //Alright normally we would expect a few paths to be loaded in here, and some spawn times, but for right now, we are going to skip that bit.
        if (spawns.Count != spawnTimes.Count||spawns.Count!=splines.Count||spawnTimes.Count!=splines.Count)
        {
            throw new System.DataMisalignedException("Spawns and Spawn Times must be the same length!!");
        }
    }
	
	// Update is called once per frame
	void Update () {
        while(spawnTimes.Count>0&&spawnTimes[0]<=Time.time)
        {
            GameObject boop = (GameObject)Instantiate(spawns[0], new Vector3(0, 0), Quaternion.identity);
            print(boop.GetType());
            BEnemy somb= boop.GetComponents(typeof(Component))[0].GetComponent<BEnemy>();
            print("Boop");
            if (splines[0] != null)
            {
                somb.spline = splines[0];
            }
            spawnTimes.RemoveAt(0);
            spawns.RemoveAt(0);
            splines.RemoveAt(0);
        }
	}
}
