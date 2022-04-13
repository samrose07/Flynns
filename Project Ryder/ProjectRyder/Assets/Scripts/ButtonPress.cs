/* This script was made by Samuel Rose at Boise State University.
 * 
 * The purpose of this script is tobe a physical button you can press
 * 
 * Biodigital Jazz, man
 */
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
public class ButtonPress : XRBaseInteractable
{
    #region variables
    public UnityEvent OnPress = null;

    private float yMin = 0.0f;
    private float yMax = 0.0f;
    private bool previousPress = false;


    private XRBaseInteractor hoverInteractor = null;
    private float previousHandHeight = 0.0f;
    #endregion

    #region on awake
    protected override void Awake()
    {
        base.Awake();
        onHoverEntered.AddListener(StartPress); //make sure unity knows when something happens
        onHoverExited.AddListener(EndPress);
    }


    private new void OnDestroy()
    {
        onHoverEntered.RemoveListener(StartPress);  //keep memory free if we're not there
        onHoverExited.RemoveListener(EndPress);
    }

    private void StartPress(XRBaseInteractor interactor)    //unity event
    {
        hoverInteractor = interactor;
        previousHandHeight = GetLocalYPosition(hoverInteractor.transform.position); //we're gonna update where the button cube is based on where the hand is.
    }

    private void EndPress(XRBaseInteractor interactor)
    {
        hoverInteractor = null;     //no more hoverInteractor
        previousHandHeight = 0.0f;  //reset hand height in regards to the button
        previousPress = false;  //did not press it
        SetYPosition(yMax);     //reset button position
    }

    #endregion

    #region start, custom methods
    private void Start()
    {
        SetMinMax();
    }

    private void SetMinMax()
    {
        Collider collider = GetComponent<Collider>();   //find our collider
        yMin = transform.localPosition.y - (collider.bounds.size.y * 0.5f);     //take that collider and get the halfway height so we don't have to hard code it if we want to change sides
        yMax = transform.localPosition.y;

    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if(hoverInteractor) //does it exist
        {
            float newHandHeight = GetLocalYPosition(hoverInteractor.transform.position);    //where is the hand
            float handDifference = previousHandHeight - newHandHeight;      //where is the button in relation
            previousHandHeight = newHandHeight;     //now we have the hand height

            float newPosition = transform.localPosition.y - handDifference;     //get the new position and set it to it
            SetYPosition(newPosition);

            CheckPress();   //check if we got all the way there
        }
    }

    private float GetLocalYPosition(Vector3 position)
    {
        Vector3 localPosition = transform.root.InverseTransformPoint(position);     //where is the height for the base of the button? that is the maximum height for the actual button

        return localPosition.y;
    }

    private void SetYPosition(float position)
    {
        Vector3 newPosition = transform.localPosition;
        newPosition.y = Mathf.Clamp(position, yMin, yMax);
        transform.localPosition = newPosition;      //basically making it go only up and down on the local
    }

    private void CheckPress()
    {
        bool inPosition = InPosition();     //are we there yet

        if (inPosition && inPosition != previousPress)      //are we there and is it different than last time? makes it only press once rather than when held.
        {
            OnPress.Invoke();       //do the functionality
            //print("pressed button");
        }

        previousPress = inPosition;     //does not repeat every frame
        //print("pressed check");

    }
    
    private bool InPosition()
    {
        float inRange = Mathf.Clamp(transform.localPosition.y, yMin, yMin + 0.01f);     //basically how low the button has to go. the 0.01 is arbitrary, but set so low to feel more like a button
        
        return transform.localPosition.y == inRange;
        
    }

    #endregion
}
