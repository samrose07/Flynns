/* This script was made by Samuel Rose at Boise State University.
 * 
 * The purpose of this script is to act as a custom snap zone wherein
 * I can add other functionality. This is because the XRTK implemented snap zone is
 * not built to acivate objectives and purely acts as a holder for an object. I made this
 * with the vent and screws in mind and it can work for just about anything you might want
 * 
 * Biodigital Jazz, man
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class MySnapZone : MonoBehaviour
{
    /* This class was created due to the limited functionality of the socket interactors
     * and/or the drop zones in oculus. Pretty easy.
     */

    private bool grabbed;
    private bool insideSnapZone;
    public bool snapped;
    public bool screwActivated = false;
    public bool ventMoveable = false;
    public GameObject elevatorDoor1;
    public GameObject elevatorDoor2;
    public Animator eDoor1Animator;
    public Animator eDoor2Animator;
    public GameObject ventObject;
    public GameObject objectToSnap;
    public GameObject rotationReference;
    public GameObject objHighlightObject;
    public GameObject parentObjectToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        //set the highlight to false
        objHighlightObject.SetActive(false);
        
    }

    //inside snap zone radius
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == objectToSnap.name) insideSnapZone = true;
        //set highlight to true to show you are in it.
        objHighlightObject.SetActive(true);
    }

    //exited snap zone radius
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == objectToSnap.name) insideSnapZone = false;
        //set highlight to false to show you are no longer in it.
        objHighlightObject.SetActive(false);
    }

    void Snap()
    {
        //if object is snapped and no longer grabbed, "snap" it into position and turn it to what
        //you have set in the game. Make sure script knows it's snapped.
        if(!grabbed && insideSnapZone)
        {
            objectToSnap.gameObject.transform.position = transform.position;
            objectToSnap.gameObject.transform.rotation = rotationReference.transform.rotation;
            snapped = true;
        }
        
    }
    
    //calls unsnap, sets the parent to false and the snapzone to false.
    //essentially only for the screw mechanic i made.
    public void DisableAndUnsnap()
    {
        UnSnap();

        parentObjectToDestroy.SetActive(false);
        gameObject.SetActive(false);
    }

    //sets snapped to false. Coulda done this in DaU, but wanted to 
    //be able to do this universally in the script.
    void UnSnap()
    {
        snapped = false;
    }

    //if not in snapzone, highlight is false. otherwise is true.
    void CheckSnapZoneEnteration()
    {
        if (!insideSnapZone) objHighlightObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //checks if grabbed so i can remove snapp.
        grabbed = objectToSnap.GetComponent<XRGrabInteractable>().isSelected;

        //calls the snappability.
        Snap();

        //turns off highlight if snapped.
        if (snapped) objHighlightObject.SetActive(false);

        //if grabbed and snapped make it no longer snapped silly.
        if (grabbed && snapped) snapped = false;
    }

    //animation for elevator. Takes in the elevator doors, each of their
    //animators have a float as such, that way i can make it universal.
    public void AnimateElevator(int elevatorNumber, float conditionalNumber)
    {
        if(elevatorNumber == 1)
        {
            eDoor1Animator.SetFloat("OpenValue", conditionalNumber);
        }
        if(elevatorNumber == 2)
        {
            eDoor2Animator.SetFloat("OpenValue", conditionalNumber);
        }
    }
}
