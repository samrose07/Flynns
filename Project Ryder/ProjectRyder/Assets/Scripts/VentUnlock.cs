/* This script was made by Samuel Rose at Boise State University.
 * 
 * The purpose of this script is to unlock a vent once all screws are taken off
 * 
 * Biodigital Jazz, man
 */
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
public class VentUnlock : MonoBehaviour
{
    //ahh, i don't want to comment this one. If you can read code, this
    //class should come easy to you. sorry not sorry,
    public int screwBoolUnlocks = 0;
   // private List<bool> screwList = new List<bool>();

    void Update()
    {
        if(screwBoolUnlocks >= 4)   //have all screws been taken off
        {
            if (gameObject.GetComponent<Rigidbody>() == null)   //make sure the vent has a rigid body
            {
                gameObject.AddComponent<Rigidbody>();
            }
            if(gameObject.GetComponent<XRGrabInteractable>() == null)   //make sure the vent has a grab interactable
            {
                gameObject.AddComponent<XRGrabInteractable>();
            }
            gameObject.layer = 9;   //set the layer to interactable

            
        }
        else
        {
            if (gameObject.layer == 9) gameObject.layer = 0; //if the screws have not been taken off, you cannot interact
        }
    }
}
