/* This script was made by Samuel Rose at Boise State University.
 * 
 * The purpose of this script is to be accessed by many other scripts to run global events such as
 * saving and loading data, turning lights on or off
 * and area discovery.
 * 
 * Biodigital Jazz, man
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    #region variables
    /*so, you've entered the big class hoping to take a tour. Welcome. It'll be a breeze.
     * it mainly handles global variables for other scripts to access.
     * directly below this are the variables that can be accessed by all other classes 
     * that require it.
     */
    //arrays that hold the floor game objects to allow each of them to be turned on or off depending on what floor you are on
    public bool flip = false;
    public bool flipped = false;
    public GameObject can;
    public GameObject[] floorOneGOs;
    public GameObject[] floorTwoGOs;
    public GameObject[] floorThreeGOs;

    //audio bools
    public bool canPlayVentClip = true;

    //grab bool
    public bool objectGrabbedLeft;
    public bool objectGrabbedRight;

    public TextMeshProUGUI textOnHand;
    public Animator textAnimator;
    private bool animationTimerStart;
    private float targetTime;

    //save objects and others
    public GameObject player;
    public GameObject keycard;
    public GameObject screwdriver;
    public GameObject ventJanitor;
    public VentUnlock ventJUnlock;
    public GameObject ventBLeft;
    public VentUnlock ventBLUnlock;
    public GameObject ventBRight;
    public VentUnlock ventBRUnlock;
    public GameObject flashlight;
    public int areasDiscovered = 0;
    private string areasDiscoveredString;
    //endsave

    public TextMeshProUGUI areaTextBox;
    public Vector3 position;
    public GameObject cubeTest;
    public List<float> playerPrefsStrings;
    public Light[] lightsInScene;
    public bool turnLightsOn;

    //start Elevators
    public GameObject firstFloorElevatorGameObject;
    public GameObject secondFloorElevatorGameObject;
    public GameObject thirdFloorElevatorGameObject;
    public bool insideFirstElevator = false;
    public bool insideSecondElevator = false;
    public bool insideThirdElevator = false;
    //end Elevators

    #endregion

    #region start and update
    void Start()
    {
        //set discovery text. 
        areasDiscoveredString = "Areas discovered: " + areasDiscovered + "/16";
        areaTextBox.text = areasDiscoveredString;
        //below are other tests.
        can.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //making sure that the area text is always updated to show what you have discovered whenever
        //the menu is present.
        areasDiscoveredString = "Areas discovered: " + areasDiscovered + "/16";
        areaTextBox.text = areasDiscoveredString;

        //this is for the hand text. This way the text doesn't constantly flash at you.
        if (animationTimerStart)
        {

            targetTime -= Time.deltaTime;
            if(targetTime <= 0.0f)
            {
                textAnimator.SetBool("Start", false);
                animationTimerStart = false;
            }
        }

        //if the lights need to turn on, turn em on. Pretty short update if i do say so myself.
        if (turnLightsOn) TurnLights(true);
        else TurnLights(false);
        // print(PlayerPrefs.GetFloat("CubePositionX") + "   " + PlayerPrefs.GetFloat("CubePositionY") + "   " + PlayerPrefs.GetFloat("CubePositionZ"));
        // print(textAnimator.GetBool("Start"));

        if (flip) FlipEverything();
    }
    #endregion

    #region custom methods
    //tells savesystem to start gathering the info based on this script and save it to a file.
    public void Save()
    {
        SaveSystem.SavePlayer(this);
    }

    public void ChangeFloorLoadedObjects(int floorNumber)
    {
        switch(floorNumber)
        {
            case 1:
                foreach(GameObject g in floorOneGOs)
                {
                    g.SetActive(true);
                }
                foreach(GameObject g in floorTwoGOs)
                {
                    g.SetActive(false);
                }
                foreach(GameObject g in floorThreeGOs)
                {
                    g.SetActive(false);
                }
                break;
            case 2:
                foreach (GameObject g in floorOneGOs)
                {
                    g.SetActive(false);
                }
                foreach (GameObject g in floorTwoGOs)
                {
                    g.SetActive(true);
                }
                foreach (GameObject g in floorThreeGOs)
                {
                    g.SetActive(false);
                }
                break;
            case 3:
                foreach (GameObject g in floorOneGOs)
                {
                    g.SetActive(false);
                }
                foreach (GameObject g in floorTwoGOs)
                {
                    g.SetActive(false);
                }
                foreach (GameObject g in floorThreeGOs)
                {
                    g.SetActive(true);
                }
                break;
        }
    }
    //below is the loading. Sets one var for position, and for each object saved it changes the position var to match where it was
    //when saved. Then sets the object to that location, afterwhich it will repeat until done. Misc objects don't need that, like
    //booleans and ints.
    public void Load()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        turnLightsOn = data.lightsOn;
        areasDiscovered = data.areasDiscovered;

        Vector3 position;
        position.x = data.playerPosition[0];
        position.y = data.playerPosition[1];
        position.z = data.playerPosition[2];

        player.transform.position = position;

        //for janitor vent
        position.x = data.ventJanitorPos[0];
        position.y = data.ventJanitorPos[1];
        position.z = data.ventJanitorPos[2];
        ventJanitor.transform.position = position;
        ventJUnlock.screwBoolUnlocks = data.ventJanScrewUnlocks;

        //for bottom bathroom left vent
        position.x = data.ventBLPos[0];
        position.y = data.ventBLPos[1];
        position.z = data.ventBLPos[2];
        ventBLeft.transform.position = position;
        ventBLUnlock.screwBoolUnlocks = data.ventBLScrewUnlocks;

        //for bottom bathroom right vent
        position.x = data.ventBRPos[0];
        position.y = data.ventBRPos[1];
        position.z = data.ventBRPos[2];
        ventBRight.transform.position = position;
        ventBRUnlock.screwBoolUnlocks = data.ventBRScrewUnlocks;

        //for keycard
        position.x = data.keycardPos[0];
        position.y = data.keycardPos[1];
        position.z = data.keycardPos[2];
        keycard.transform.position = position;

        //for screwdriver
        position.x = data.screwdriverPos[0];
        position.y = data.screwdriverPos[1];
        position.z = data.screwdriverPos[2];
        screwdriver.transform.position = position;

        //for flashlight
        position.x = data.flashlightPos[0];
        position.y = data.flashlightPos[1];
        position.z = data.flashlightPos[2];
        flashlight.transform.position = position;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    //pub method for in-game button to call upon.
    public void LightBooleanActivate()
    {
        turnLightsOn = true;
    }

    //takes each light applied to the array and turns them on. wink.
    public void TurnLights(bool on)
    {
        for (int i = 0; i < lightsInScene.Length; i++)
        {

            lightsInScene[i].enabled = on;
        }
    }

    //when applicable based on elevator button press, teleport. not the smoothest way to do it, but cool nonetheless.
    public void TeleportToDifferentFloor(GameObject desiredElevator)
    {
        player.transform.position = new Vector3(player.transform.position.x, desiredElevator.transform.position.y - 1.6f, player.transform.position.z);
    }

    //called upon when entering a new area.
    public void AreaEntranceMessage(string location)
    {
        areasDiscovered++;
        
        textOnHand.text = "You have discovered " + location;
        textAnimator.SetBool("Start", true);
        animationTimerStart = true;
        targetTime = 10f;
    }

    //we take the world and flip it. the way i built the level two years ago means it won't just flip in place and be fine.
    //instead, we flip the world around the player, keeping them inside the map still.
    public void FlipEverything()
    {
        flip = false;
        GameObject holder = GameObject.Find("Holder");
        can.SetActive(true);
        Invoke("TurnOffCanvas", 1f);
        //holder.transform.Rotate(0, 0, 180);
        Vector3 pointToRotateAround = new Vector3(player.transform.position.x, player.transform.position.y+1f, player.transform.position.z);
        holder.transform.RotateAround(pointToRotateAround, new Vector3(0,0,1), 180);
        if (flipped) flipped = false;
        else flipped = true;
    }

    public void TurnOffCanvas()
    {
        can.SetActive(false);
    }
    #endregion
}
