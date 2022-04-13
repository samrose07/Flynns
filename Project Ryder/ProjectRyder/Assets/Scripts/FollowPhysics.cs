/* This script was made by Samuel Rose at Boise State University.
 * 
 * The purpose of this script is to make the belt collider on the player react to height and rotational changes.
 * Didn't ultimately get used as I was able to make a better one
 * 
 * Biodigital Jazz, man
 */
using UnityEngine;

public class FollowPhysics : MonoBehaviour
{

    public Transform target;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(target.transform.position);
    }
}
