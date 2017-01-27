using Assets.Scripts;
using UnityEngine;
using VRTK_OutlineObjectCopyHighliter;
using System.Collections.Generic;
using System;

public class Craftable_Object : VRTK_InteractableObject
{
    public bool attachable;

    private bool inUse = false;
    SteamVR_Controller.Device device;
    List<GameObject> connectedObjects = new List<GameObject>();

    public override void StartUsing(GameObject usingObject)
    {
        base.StartUsing(usingObject);
        inUse = true;
    }

    public override void StopUsing(GameObject usingObject)
    {
        base.StopUsing(usingObject);
        inUse = false;
    }

    void OnCollisionStay(Collision collision)
    {
        //VRTK_InteractGrab grabbingController = (collision.gameObject.GetComponent<VRTK_InteractGrab>() ? collision.gameObject.GetComponent<VRTK_InteractGrab>() : collision.gameObject.GetComponentInParent<VRTK_InteractGrab>());

        Debug.Log(gameObject.name + " has collided with " + collision.gameObject.name);
        //if (grabbingController && grabbingController.GetGrabbedObject() == collision.gameObject)
        {
            Debug.Log(gameObject.name + " + " + collision.gameObject.name + " while holding");
            if (inUse)
            {
                if (!connectedObjects.Contains(collision.gameObject))
                {
                    Debug.Log(gameObject.name + " + " + collision.gameObject.name + " while in 'use' mode");

                    Craftable_Object craftableObject = collision.gameObject.GetComponent<Craftable_Object>();
                    if (craftableObject != null)
                    {
                        if (this.gameObject.name == "BasicRope")
                        {
                            Debug.Log("Applying rope to " + collision.gameObject.name);
                            craftableObject.attachable = true;
                            Destroy(gameObject);
                        }
                        else
                        {
                            if (this.attachable == true || craftableObject.attachable == true)
                            {
                                if (this.attachable)
                                    this.attachable = false;
                                else if (craftableObject.attachable)
                                    craftableObject.attachable = false;

                                Debug.Log("Attaching " + gameObject.name + " + " + collision.gameObject.name);
                                FixedJoint fixedJoint = collision.gameObject.AddComponent<FixedJoint>();
                                fixedJoint.connectedBody = gameObject.GetComponent<Rigidbody>();
                                connectedObjects.Add(collision.gameObject);
                            }

                            //string result = Crafting.Craft(gameObject.name, collision.gameObject.name);

                            //if (!string.IsNullOrEmpty(result))
                            //{
                            //    Debug.Log("Creating " + result);

                            //    //remember
                            //    Vector3 v = gameObject.transform.position;
                            //    Quaternion q = gameObject.transform.rotation;

                            //    //destroy
                            //    Destroy(gameObject);
                            //    Destroy(collision.gameObject);

                            //    //create
                            //    GameObject newObject = (GameObject)Instantiate(GameObject.Find(result), v, q);
                            //    newObject.name = result;

                            //    //grab

                            //    //VRTK_InteractGrab grabbingController = ;
                            //    //grabbingController.gameObject.GetComponent<VRTK_InteractTouch>().ForceTouch(newObject);
                            //    //grabbingController.AttemptGrab();
                            //}
                        }
                    }
                }
            }
        }
    }
}