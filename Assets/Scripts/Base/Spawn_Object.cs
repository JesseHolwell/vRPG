using UnityEngine;
using VRTK_OutlineObjectCopyHighliter;
using System.Collections;

public class Spawn_Object : MonoBehaviour {

    public GameObject outputObject;
    public int quantity;
    public bool destructionOnEmpty;

    public int variation;

    private System.Random random;

    protected int quantityCounter;

    private void Start()
    {
        quantityCounter = 0;
        random = new System.Random();
    }

    private void OnTriggerStay(Collider collider)
    {
        
        VRTK_InteractGrab grabbingController = (collider.gameObject.GetComponent<VRTK_InteractGrab>() ? collider.gameObject.GetComponent<VRTK_InteractGrab>() : collider.gameObject.GetComponentInParent<VRTK_InteractGrab>());
        if (CanGrab(grabbingController) && quantityCounter < quantity)
        {
            GameObject newObject = Instantiate(outputObject);
            int radius = random.Next(variation, variation);
            int length = random.Next(variation, variation);
            newObject.transform.localScale += new Vector3(radius, length, radius);
            newObject.name = outputObject.name;
            grabbingController.gameObject.GetComponent<VRTK_InteractTouch>().ForceTouch(newObject);
            grabbingController.AttemptGrab();
            quantityCounter++;
            if (quantityCounter == quantity && destructionOnEmpty)
                Destroy(gameObject);

            Debug.Log("Spawning object. radius: " + radius + ", length: " + length);
        }
    }

    private bool CanGrab(VRTK_InteractGrab grabbingController)
    {
        return (grabbingController && grabbingController.GetGrabbedObject() == null && grabbingController.gameObject.GetComponent<VRTK_ControllerEvents>().grabPressed);
    }
}
