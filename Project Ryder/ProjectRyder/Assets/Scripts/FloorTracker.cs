/* This script was made by Samuel Rose at Boise State University.
 * 
 * The purpose of this script is to track where the player is in the level to
 * turn certain objects on or off to save on memory.
 * 
 * Biodigital Jazz, man
 */
using UnityEngine;

public class FloorTracker : MonoBehaviour
{
    public int floorNumber;
    public GameManager gm;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "thePlayer")
        {
            gm.ChangeFloorLoadedObjects(floorNumber);
        }
    }
}
