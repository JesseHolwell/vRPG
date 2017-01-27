using UnityEngine;

public class Breakable_Object : MonoBehaviour
{
    public GameObject outputObject;
    public int quantity;
    public float hardness;

    private void Start()
    {
        GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    private void OnCollisionEnter(Collision collision)
    {

        var collisionForce = collision.relativeVelocity.magnitude;
        if (collisionForce > hardness)
        {
            GameObject newObject = (GameObject)Instantiate(outputObject, gameObject.transform.position, gameObject.transform.rotation);
            newObject.name = outputObject.name;
            quantity--;
            if (quantity <= 0)
                Destroy(gameObject);
        }

        Debug.Log(gameObject.name + " Collision\n"
            + "collisionForce: " + collisionForce + "\n"
            + "items remaining:" + quantity);
    }
}