/* This script was made by Samuel Rose at Boise State University.
 * 
 * The purpose of this script is to play an audio clip for the elevators.
 * 
 * Biodigital Jazz, man
 */
using UnityEngine;

public class ElevatorAudioScript : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    //i could have gotten rid of this script and put this code somewhere else
    public void PlayAudio()
    {
        source.PlayOneShot(clip);
    }
}
