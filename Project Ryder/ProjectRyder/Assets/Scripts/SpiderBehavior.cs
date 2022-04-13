/* This script was made by Samuel Rose at Boise State University.
 * 
 * The purpose of this script is make the spiders move for ambience,
 * but not using navmeshes.
 * 
 * Biodigital Jazz, man
 */
using UnityEngine;

public class SpiderBehavior : MonoBehaviour
{
    #region variables
    [SerializeField] private Animator spiderimator;
    [SerializeField] private Transform fleeLocation1;
    [SerializeField] private Transform fleeLocation2;
    [SerializeField] private Transform fleeLocation3;
    [SerializeField] private Transform locationToGoTo;
    [SerializeField] private Transform currentLocation;


    public bool canGo = false;
    #endregion

    #region update and trigger
    private void Update()
    {
        if (canGo) GoToLocation();  //allowed to move? then do
        else spiderimator.SetBool("Moving", false); //otherwise, naw, make it animate idle.
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "thePlayer") locationToGoTo = NewLocation(currentLocation); //once player is near, you may go.
    }

    #endregion

    #region custom methods

    private Transform NewLocation(Transform location)   //getting a new location. Coulda used a switch statement here. could have also randomized it
    {
        Transform temp;

        if (currentLocation == fleeLocation1)
        {
            temp = fleeLocation2;
        }
        else if (currentLocation == fleeLocation2)
        {
            temp = fleeLocation3;
        }
        else if (currentLocation == fleeLocation3)
        {
            temp = fleeLocation1;
        }
        else temp = fleeLocation1;
        canGo = true;
        return temp;
    }

    void GoToLocation() //once we have a location, look at it, move towards it, and once we get close enough, stop it.
    {
        transform.rotation = Quaternion.LookRotation(transform.position - locationToGoTo.position);
        transform.position = Vector3.MoveTowards(transform.position, locationToGoTo.position, .03f);
        float distance = Vector3.Distance(transform.position, locationToGoTo.position);
        spiderimator.SetBool("Moving", true);
        if(distance < 1)
        {
            currentLocation = locationToGoTo;
            canGo = false;
        }
    }
    #endregion
}
