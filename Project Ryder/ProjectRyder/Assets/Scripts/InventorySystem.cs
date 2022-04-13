/* This script was made by Samuel Rose at Boise State University.
 * 
 * The purpose of this script is to act as a belt that is attached to the player.
 * The player can add things to the belt and not worry about having to hold them.
 * The flashlight is an excellent example as it will point to wherever the player is looking
 * when attached to the belt.
 * 
 * Biodigital Jazz, man
 */
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = target.position + Vector3.up * offset.y 
            + Vector3.ProjectOnPlane(target.right, Vector3.up).normalized * offset.x 
            + Vector3.ProjectOnPlane(target.forward, Vector3.up).normalized * offset.z;     //this gets the x and z plane and allows us to place the belt objects around the player,
                                                                                            //as well as keep them from moving up and down.

        transform.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);    //makes sure it rotates with the player for consistency along the Y axis.
    }
}
