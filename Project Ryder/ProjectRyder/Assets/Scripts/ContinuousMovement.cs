/* This script was made by Samuel Rose at Boise State University.
 * 
 * The purpose of this script is to move the player, handling those inputs.
 * 
 * Biodigital Jazz, man
 */
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class ContinuousMovement : MonoBehaviour
{
    #region variables
    public XRNode inputSource;
    public float speed = 1f;
    public float gravity = -9.81f;
    public LayerMask groundLayer;
    public float additionalHeight = 0.2f;
    private float fallingSpeed;
    private XRRig rig;
    private Vector2 inputAxis;
    private CharacterController character;
    #endregion

    #region Start, update, fixed update
    // Start is called before the first frame update
    void Start()
    {
        //getting what I need
        character = GetComponent<CharacterController>();
        rig = GetComponent<XRRig>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);       //need to figure out what type of controller we're using
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);   //attempts to get an axis change based on button press, and if valid then give us values to use in inputAxis
    }

    private void FixedUpdate()
    {
        CapsuleFollowHeadset();
        Quaternion headYaw = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);      //where are we looking?
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);     //we want to move in the direction we are looking, uses the left thumbstick to initiate it

        character.Move(direction * Time.fixedDeltaTime * speed);    //activate the move

        //gravity
        bool isGrounded = CheckIfGrounded();        //we chillin on the ground?
        if (isGrounded) fallingSpeed = 0;       //if so, we are not affected by gravity
        else fallingSpeed += gravity * Time.fixedDeltaTime;     //otherwise, you bet we fallin

        character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);    //add gravity to the move vector
    }
    #endregion

    #region custom methods
    void CapsuleFollowHeadset()
    {
        character.height = rig.cameraInRigSpaceHeight + additionalHeight;       //gettin our height. TODO: change movement speed to be slower when under a threshold of height
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.cameraGameObject.transform.position);       //where is our stomach?
        character.center = new Vector3(capsuleCenter.x, character.height / 2 + character.skinWidth, capsuleCenter.z);       //Character controller needs to know this to dynamically update itself in game
    }

    bool CheckIfGrounded()
    {
        //tells if on ground
        Vector3 rayStart = transform.TransformPoint(character.center);      //boom raycast below from the centerpoint we found above too
        float rayLength = character.center.y + 0.01f;       //at what point will we figure out if we're grounded? Super close, thats what TODO implement this in my 3D platformer for better gravity controls

        bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer);     //do the sphere cast with the distance of the ray we set up
        return hasHit;
    }
    #endregion
}
