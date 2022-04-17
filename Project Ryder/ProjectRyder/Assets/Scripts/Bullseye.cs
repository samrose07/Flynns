/* This script was made by Samuel Rose at Boise State University.
 * 
 * The purpose of this script is to handle interactions with the bullet
 * for the second floor power unlock puzzle
 * 
 * Biodigital Jazz, man
 */
using UnityEngine;

public class Bullseye : MonoBehaviour
{
    [SerializeField] private PowerUnlock powerUnlock;
    [SerializeField] private GameObject relatedIndicator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("bullet"))
        {
            powerUnlock.targetsShot++;      //power cube accessed and added 
            relatedIndicator.GetComponent<Renderer>().material.color = Color.green;    //change the indicator color to green (funny thing, the color change isn't visible unless the flashlight is pointed on it?)
            relatedIndicator.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);     //udpate: fixed the funny thing ^
            Destroy(gameObject);        //destroy me
        }
    }
}
