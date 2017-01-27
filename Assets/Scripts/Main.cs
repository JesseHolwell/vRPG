using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

    public GameObject Sun;

    public float minsInDay;
    private float time;

    void Start () {

    System.Random r = new System.Random();

		//spawn objects
		for (int i = 0; i < 50; i += 5)
		{
			Vector3 pos = new Vector3(r.Next(-25, 25), 1, i - 25);

			GameObject tree = (GameObject)Instantiate(GameObject.Find("Tree"), pos, new Quaternion(0,0,0,0));
			tree.name = "Tree";

			pos = new Vector3(r.Next(-25, 25), -0.08f, i - 25);

			GameObject rock = (GameObject)Instantiate(GameObject.Find("RockPile"), pos, new Quaternion(0, 0, 0, 0));
			rock.name = "RockPile";

			pos = new Vector3(r.Next(-25, 25), 0.212f, i - 25);

			GameObject bush = (GameObject)Instantiate(GameObject.Find("Bush"), pos, new Quaternion(0, 0, 0, 0));
			bush.name = "Bush";
		}    
	}
	
	void Update () {

        //Sun rotation
        Sun.transform.localEulerAngles = new Vector3((float)(time * 360 / minsInDay), 0, 0);

        //Time
        time += (float)0.1;
        if (time >= minsInDay)
            time = 0;
    }
}
