/* This script was made by Samuel Rose at Boise State University.
 * 
 * This class is used as the data storage. Takes in whatever you want but can only store the four
 * main types: float, int, string, and bool. Doesn't take in Unity specifics like
 * vector3 and such. Good thing is, you can break most of them up into the basic types.
 * 
 * Biodigital Jazz, man
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    #region variables (things I want to save)

    //i should really learn to save and load with JSON.
    public int areasDiscovered;
    public float[] playerPosition;
    public bool lightsOn;
    public float[] ventJanitorPos;
    public int ventJanScrewUnlocks;
    public float[] ventBLPos;
    public int ventBLScrewUnlocks;
    public float[] ventBRPos;
    public int ventBRScrewUnlocks;
    public float[] keycardPos;
    public float[] screwdriverPos;
    public float[] flashlightPos;
    #endregion

    #region PlayerData - Accessed by GM
    public PlayerData (GameManager gm)
    {
        /*Essentially all that happens is you get the information
         * from the gm class and store it into player data.
         * GM then calls for the save or load. ezpz.
         */

        //lights and area
        lightsOn = gm.turnLightsOn;
        areasDiscovered = gm.areasDiscovered;

        //player
        playerPosition = new float[3];
        playerPosition[0] = gm.player.transform.position.x;
        playerPosition[1] = gm.player.transform.position.y;
        playerPosition[2] = gm.player.transform.position.z;

        //janitor vent
        ventJanitorPos = new float[3];
        ventJanitorPos[0] = gm.ventJanitor.transform.position.x;
        ventJanitorPos[1] = gm.ventJanitor.transform.position.y;
        ventJanitorPos[2] = gm.ventJanitor.transform.position.z;
        ventJanScrewUnlocks = gm.ventJUnlock.screwBoolUnlocks;

        //b left vent
        ventBLPos = new float[3];
        ventBLPos[0] = gm.ventBLeft.transform.position.x;
        ventBLPos[1] = gm.ventBLeft.transform.position.y;
        ventBLPos[2] = gm.ventBLeft.transform.position.z;
        ventBLScrewUnlocks = gm.ventBLUnlock.screwBoolUnlocks;

        //b right vent
        ventBRPos = new float[3];
        ventBRPos[0] = gm.ventBRight.transform.position.x;
        ventBRPos[1] = gm.ventBRight.transform.position.y;
        ventBRPos[2] = gm.ventBRight.transform.position.z;
        ventBRScrewUnlocks = gm.ventBRUnlock.screwBoolUnlocks;

        //keycard
        keycardPos = new float[3];
        keycardPos[0] = gm.keycard.transform.position.x;
        keycardPos[1] = gm.keycard.transform.position.y;
        keycardPos[2] = gm.keycard.transform.position.z;
        
        //screwdriver
        screwdriverPos = new float[3];
        screwdriverPos[0] = gm.screwdriver.transform.position.x;
        screwdriverPos[1] = gm.screwdriver.transform.position.y;
        screwdriverPos[2] = gm.screwdriver.transform.position.z;

        //flashlight
        flashlightPos = new float[3];
        flashlightPos[0] = gm.flashlight.transform.position.x;
        flashlightPos[1] = gm.flashlight.transform.position.y;
        flashlightPos[2] = gm.flashlight.transform.position.z;
    }
    #endregion
}
