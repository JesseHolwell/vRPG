using UnityEngine;
using System.Collections;
using VRTK_OutlineObjectCopyHighliter.Highlighters;

public class Spark : MonoBehaviour {

    void Start () {
        //start death timer
        Destroy(gameObject, 1);

        this.gameObject.AddComponent<VRTK_OutlineObjectCopyHighlighter>().Initialise();
        var highlighter = gameObject.GetComponent<VRTK_BaseHighlighter>();
        if (highlighter)
        {
            highlighter.Highlight(new Color(255, 0, 0));
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        var physicsObject = collision.gameObject.GetComponent<Physics_Object>();
        if (physicsObject != null && physicsObject.flammable)
        {
            physicsObject.SetOnFire();
        }

        Debug.Log(gameObject.name + " Spark collision with" + collision.gameObject.name);
    }
}
