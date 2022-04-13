/* This script was made by Samuel Rose at Boise State University.
 * 
 * The purpose of this script is to have a small interaction for the elevator. Interacts with 
 * the game manager script to play the introductory audio. Could have streamlined it a bit better.
 * 
 * Biodigital Jazz, man
 */
using UnityEngine;

public class EntranceDoorScript : MonoBehaviour
{
    //variables
    public Animator topAnim;
    public Animator bottomAnim;
    private bool firstInteract = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "thePlayer" && !firstInteract)   //is this the first time the player entered (only on first entrance to building)
        {
            topAnim.SetFloat("OpenValue", 0);       //open the door topside
            bottomAnim.SetFloat("OpenValue", 0);    //open the door bottomside
            firstInteract = true;       //let the game manager know
        }
    }
}
