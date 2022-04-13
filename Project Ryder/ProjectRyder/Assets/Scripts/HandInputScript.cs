/* This script was made by Samuel Rose at Boise State University.
 * 
 * The purpose of this script is to handle inputs we get from the controllers. Currently,
 * only spawns the menu in game for the player to interact with
 * 
 * Biodigital Jazz, man
 */
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
public class HandInputScript : MonoBehaviour
{

    #region variables
    public XRNode inputSource;
    public GameObject menuPlacementCube;
    public GameObject menuItself;
    public GameObject playerCamera;
    private int currentMenuButtonState = 0;
    private bool menuButtonPress;
    private InputDevice device;
    #endregion

    #region start and update
    // Start is called before the first frame update
    void Start()
    {
        //get the device the player is using
        device = InputDevices.GetDeviceAtXRNode(inputSource);
    }

    // Update is called once per frame
    void Update()
    {
        //check if menu button is pressed
        device.TryGetFeatureValue(CommonUsages.menuButton, out menuButtonPress);

        //if true
        if (menuButtonPress)
        {
            //if the current menu button state exceeds one, based on the time that unity spends
            //counting here, then cannot spawn. This is so it doesn't spawn and respawn over and over again.
            if (currentMenuButtonState >= 1)
            {
                //print("cannot spawn"); this was here for testing purposes. Keeping it cus im too lazy to change the syntax here.
            }
            else
            {
                //print("spawned with no additional respawn"); send the method out fam.
                MenuPressed();
            }
            //adds to current menu b state so it only spawns or despawns once in a given press.
            currentMenuButtonState++;
        }
        else
        {
            //if not pressed, state is at zero so as to readily accept new presses. God i'm a genius.
            currentMenuButtonState = 0;
        }
    }
    #endregion

    #region MenuPressed Function
    //checks if active and if is, sets not. If not sets is, moves to the invis spawn, looks at the player.
    void MenuPressed()
    {
        if (menuItself.activeInHierarchy)       //are we active?
        {
           menuItself.SetActive(false);     //make it not so
            
        }
        else
        {
            menuItself.SetActive(true);     //otherwise turn on that there menu
            menuItself.transform.position = menuPlacementCube.transform.position;       //make sure the menu is in place
            menuItself.transform.LookAt(playerCamera.transform);        //make sure the menu is facing us so we don't have to maneuver weirdlike to see its properties
        }
    }
    #endregion
}