/* This script was made by Samuel Rose at Boise State University.
 * 
 * The purpose of this script is to unlock the power in the second level
 * through a shooting puzzle
 * 
 * Biodigital Jazz, man
 */
using UnityEngine;

public class PowerUnlock : MonoBehaviour
{
    #region variables

    public int targetsShot = 0;
    [SerializeField] private int neededTargets = 0;


    #endregion

    #region mechanics
    // Update is called once per frame
    void Update()
    {
        if (targetsShot >= neededTargets) UnlockPower();    //check to make sure my requirement is met
    }

    void UnlockPower()
    {
        Destroy(gameObject);
    }
    #endregion
}
