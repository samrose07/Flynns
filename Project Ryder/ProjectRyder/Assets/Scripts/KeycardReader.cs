/* This script was made by Samuel Rose at Boise State University.
 * 
 * The purpose of this script is to allow the player to interact with the doors via keycard.
 * accounts for which doors you want to open and sends information to them
 * 
 * Biodigital Jazz, man
 */
using UnityEngine;

public class KeycardReader : MonoBehaviour
{
    public MySnapZone snapZoneObject;
    public float sentNumber;
    void Update()
    {
        if(snapZoneObject.snapped)      //is the keycard in place? then tell the snap zone to animate the doors
        {
            snapZoneObject.AnimateElevator(1, sentNumber);
            snapZoneObject.AnimateElevator(2, sentNumber);
        }
    }

    public void AnimationStart(float numberToSend)      //i made this to streamline the update function a bit, but it does the exact same thing as is never called
    {
        snapZoneObject.AnimateElevator(1, numberToSend);
        snapZoneObject.AnimateElevator(2, numberToSend);
    }
}
