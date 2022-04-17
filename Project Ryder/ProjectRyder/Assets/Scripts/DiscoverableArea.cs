/* This script was made by Samuel Rose at Boise State University.
 * 
 * The purpose of this script is to update the areas in which you have discovered,
 * and display the fact that you discovered one on your wrist.
 * 
 * Biodigital Jazz, man
 */
using UnityEngine;

public class DiscoverableArea : MonoBehaviour
{
    #region variables
    public GameManager gm;
    public string location;
    public bool discoverable = true;
    public AudioClip audioToPlay;
    public AudioSource fromWhereToPlay;
    public bool checkThisToCheckIfAudioCanPlay = false;
    public bool gmCheck = false;
    public bool thirdFloorLightsOn = false;
    public AudioClip thirdFloorNoLightsClip;
    public GameObject objectToAppear;

    #endregion

    #region trigger and update
    //when player enters collider and it hasn't been discovered yet,
    //tell GM to send a new message to hand text.
    //GM also adds to areas to be discovered!
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "thePlayer" && discoverable)
        {
            gm.AreaEntranceMessage(location);

            //discoverable false means no more ability to discover since ya already did ya silly goose
            discoverable = false;
            PlayAudioClip();

            if (objectToAppear) objectToAppear.SetActive(true);
        }    
    }
    private void Update()
    {
        if (gm.turnLightsOn) thirdFloorLightsOn = true;
    }

    #endregion

    #region custom methods
    private void PlayAudioClip()
    {
        if (audioToPlay != null)    //do we have one?
        {
            if(thirdFloorNoLightsClip != null)  //do we have a no lights clip
            {
                if(thirdFloorLightsOn)
                {
                    fromWhereToPlay.PlayOneShot(audioToPlay);   //if the lights are on, play THIS clip
                }
                else
                {
                    fromWhereToPlay.PlayOneShot(thirdFloorNoLightsClip);    //if not, play THIS clip
                }
            }
            //if the dev wants to check if audio (that can play from multiple sources) has been played somewhere else
            else if (checkThisToCheckIfAudioCanPlay)
            {
                //internal bool inherits from GM, since each DA script is its own instance, therefore can't be a universal without a singularity
                gmCheck = gm.canPlayVentClip;
                if (gmCheck)
                {
                    //if can play based on GM, play the clip, then set to false;
                    fromWhereToPlay.PlayOneShot(audioToPlay);
                    gm.canPlayVentClip = false;
                } 
            }
            else
            {
                fromWhereToPlay.PlayOneShot(audioToPlay);   //built it like this so we know what can play when and where. If you want it to play in a specific spot, you can, otherwise default to this
            }
        }
        
    }
    #endregion
}
