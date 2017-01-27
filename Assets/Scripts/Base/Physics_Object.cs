using UnityEngine;
using VRTK_OutlineObjectCopyHighliter.Highlighters;

public class Physics_Object : MonoBehaviour
{
    public GameObject outputObject;
    public int quantity;
    public float durability;
    public float hardness;

    public bool flammable;
    public float flammability;
    public bool onFire;

    private void Start()
    {
        GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
        this.gameObject.AddComponent<VRTK_OutlineObjectCopyHighlighter>().Initialise();

    }

    private void Update()
    {
        if (onFire)
        {
            durability -= 0.1f;
            if (durability <= 0)
                ExplodeObject();
        }
    }

    public void SetOnFire()
    {
        if (flammable)
        {
            onFire = true;

            var highlighter = gameObject.GetComponent<VRTK_BaseHighlighter>();
            if (highlighter)
            {
                highlighter.Highlight(new Color(255, 0, 0));
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {

        var collisionForce = collision.relativeVelocity.magnitude;
        if (collisionForce > hardness)
        {
            durability -= collisionForce;
                
            if (durability <= 0)
                ExplodeObject();
        }

        Debug.Log(gameObject.name + " Collision\n"
            + "collisionForce: " + collisionForce + "\n"
            + "health: " + durability);
    }

    public virtual void ExplodeObject()
    {
        //make child objects
        for (int i = 0; i < quantity; i++)
        {
            GameObject newObject = (GameObject)Instantiate(outputObject, gameObject.transform.position + new Vector3(i/2, 0, i/2), gameObject.transform.rotation);
            newObject.name = outputObject.name;         
            //TODO: velocity from force
        }

        //despawn the object
        Destroy(gameObject);

    }

}