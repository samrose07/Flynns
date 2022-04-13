/* This script was made by Samuel Rose at Boise State University.
 * 
 * The purpose of this script is to act as an easter egg for the player.
 * 
 * Biodigital Jazz, man
 */
using UnityEngine;

public class HandSwipe : MonoBehaviour
{
    public GameObject player;
    public Animator handAnimator;

    private void OnTriggerEnter(Collider other)
    {
        //basically, once the player gets close enough to the hand, make it swipe atcha
        if (other.gameObject.tag == "thePlayer")
        {
            handAnimator.SetBool("Triggered", true);
            //print("ive triggered successfully");
        }
        else handAnimator.SetBool("Triggered", false);
    }
}
