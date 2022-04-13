/* This script was made by Samuel Rose at Boise State University.
 * 
 * This script was created to make the starting room disappear, putting
 * the player directly in the scene smoothly.
 * 
 * Biodigital Jazz, man
 */
using UnityEngine;

public class StartingRoomWalls : MonoBehaviour
{

    #region variables
    public Vector3 positionToMoveTo;
    public GameObject endPosGameObject;
    public CharacterController characterController;
    public float movementSpeed;
    private bool canMove = false;
    private bool checkPos = false;
    #endregion

    #region Update
    private void Update()
    {

        checkPos = CheckPos();  // should have named it checkScale, but oh well
        if (checkPos)
        {
            Destroy(endPosGameObject);      //if we are small enough, lets destroy the object that tells us where to go
            Destroy(gameObject);        //and then the instance of this object itself
        }
        if (canMove)        //if we are allowed to move
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosGameObject.transform.position, movementSpeed);       //lets get to where we need to go
            transform.localScale = Vector3.MoveTowards(transform.localScale, endPosGameObject.transform.localScale, movementSpeed);     //shrink us to look cool
        }
    }
    #endregion

    #region Custom methods
    public void MoveTheWallsAway()
    {
        canMove = true;     //called by the button script when the button is pressed. Allows us to move
    }

    bool CheckPos()
    {
        bool returnValue = false;
        Vector3 scale = transform.localScale;
        if (scale.x <= 0.1 && scale.y <= 0.1 && scale.z <= 0.1)     //here we are just checking if the objects are small enough to be invisible so we can get rid of them
            returnValue = true;
        return returnValue;
    }
    #endregion
}
