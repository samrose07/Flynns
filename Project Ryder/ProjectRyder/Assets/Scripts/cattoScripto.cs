/* This script was made by Samuel Rose at Boise State University.
 * 
 * The purpose of this script is to be the brain of the cat. The cat is a navagent,
 * who will guide the player to the hand easter egg.
 * 
 * Biodigital Jazz, man
 */
using UnityEngine;
using UnityEngine.AI;

public class cattoScripto : MonoBehaviour
{
    #region variables
    public NavMeshAgent agent;
    public Transform endGoal;
    public GameObject player;
    public float distanceToCheck = 0.0f;

    public Animator animator;
    #endregion

    #region update
    // Update is called once per frame
    void Update()
    {
        if(CheckHeightOf(player)) //if we are on the second floor
        {
            if (CheckDistanceOf(player.transform))      //if we are closer than the distance set in inspector
            {
                agent.destination = endGoal.transform.position;     //set the destination and start walkin
                animator.SetBool("Walking", true);
            }
            else
            {
                agent.destination = transform.position;     //otherwise stop, stop walkin
                animator.SetBool("Walking", false);
            }
        }
    }

    #endregion

    #region custom methods
    private bool CheckDistanceOf(Transform tf)
    {
        float distance = Vector3.Distance(transform.position, tf.position);     //checking to see how far away the tf transform is from the catto
        return distance < distanceToCheck ? true : false;       //returns true if its close, false if far.
    }

    private bool CheckHeightOf(GameObject gm)
    {
        bool check = false;
        if(gm.transform.position.y < 18 && gm.transform.position.y > 12)        //arbitrary values found from within the game. Basically, is on second floor?
        {
            check = true;
        }
        return check;
    }

    #endregion
}
