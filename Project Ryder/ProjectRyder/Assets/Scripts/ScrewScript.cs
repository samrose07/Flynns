/* This script was made by Samuel Rose at Boise State University.
 * 
 * This script is the "brain" for the screws that interact with the vent snap zones.
 * It basically adds the tally of screws that have been unlocked by the player to the
 * respective vent and then makes the snap zone disappear so it doesn't do it twice
 * 
 * Biodigital Jazz, man
 */
using UnityEngine;

public class ScrewScript : MonoBehaviour
{
    #region variables
    public VentUnlock vent;
    public MySnapZone snapScript;
    public bool screwUnlocked = false;
    private bool hasAdded = false;
    #endregion

    void Update()
    {
        if(snapScript.snapped)      //do we have a screwdriver in place
        {
            AddScrewCount();    
          snapScript.DisableAndUnsnap();    //after we have added to the screw count, make sure the snapzone is gone
        }
    }
    void AddScrewCount()
    {
        if (!hasAdded)      //make sure we havent added any yet, and if not, do so and make sure we are not allowed to again for this instance
        {
            vent.screwBoolUnlocks++;
            hasAdded = true;
        }
    }
}
