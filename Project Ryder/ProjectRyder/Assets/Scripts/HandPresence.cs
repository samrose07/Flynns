/* This script was made by Samuel Rose at Boise State University.
 * 
 * This script was made to make the hands appear correctly in game. Didn't use it though
 * 
 * Biodigital Jazz, man
 */
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class HandPresence : MonoBehaviour
{
    #region variables
    public bool showController = false;
    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;

    public GameObject handModelPrefab;

    private InputDevice targetDevice;
    private GameObject spawnedController;
    private GameObject spawnedHandModel;
    private Animator handAnimator;
    #endregion

    #region start/initialize
    void Start()
    {
        TryInitialize();
        
    }
    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();        //figure out what we have available within XRTK

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);     //find the controllers within XRTK and load them into our device list

        foreach (var item in devices)
        {
            //Debug.Log(item.name + item.characteristics); this was for testing, just to see what we could bring up and make sure we got it figured out
        }
        if (devices.Count > 0)      //do any exist?
        {
            targetDevice = devices[0];      //set what we're looking for

            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);     //getting the name of our desired controller from our TargetDevice using a lambda expression
            if (prefab)     //if its not null, that is
            {
                spawnedController = Instantiate(prefab, transform);     //what we have should now spawn
            }
            else
            {
                Debug.LogError("Did not find corresponding controller model");
                spawnedController = Instantiate(controllerPrefabs[0], transform);       //spawn the default controller if nothing matches.
            }

            spawnedHandModel = Instantiate(handModelPrefab, transform);     //lets spawn them hands so we can throw em
            handAnimator = spawnedHandModel.GetComponent<Animator>();       //lets be able to animate them hands
        }
    }
    #endregion

    #region updates
    void UpdateHandAnimation()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue)) handAnimator.SetFloat("Trigger", triggerValue);
        else handAnimator.SetFloat("Trigger", 0);       //with these we are setting the blend tree to represent what our hand is doing based on trigger

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue)) handAnimator.SetFloat("Grip", gripValue);
        else handAnimator.SetFloat("Grip", 0);      //represent what our grip looks like in the blend tree

    }

    void Update()
    {
        if (!targetDevice.isValid) TryInitialize();     //if we don't have a device, try, try again
        else
        {
            if (showController)     //we can control whether we want to see the controller or the hand here.
            {
                spawnedHandModel.SetActive(false);
                spawnedController.SetActive(true);
            }
            else
            {
                spawnedHandModel.SetActive(true);
                spawnedController.SetActive(false);
                UpdateHandAnimation();      //if we can see the hand, do the animations
            }
        }
        
        if(targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue) && primary2DAxisValue != Vector2.zero)
        {
            //Debug.Log("Primary Joystick " + primary2DAxisValue); this was used for testing somewhere.
        }
    }
    #endregion
}
