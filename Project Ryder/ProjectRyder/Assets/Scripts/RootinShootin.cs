/* This script was made by Samuel Rose at Boise State University.
 * 
 * The purpose of this script is to be the gun for the player, shootin
 * cool lazers out quick
 * 
 * Biodigital Jazz, man
 */
using UnityEngine;

public class RootinShootin : MonoBehaviour
{
    #region variables

    [SerializeField] private Transform bulletAttach;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;

    #endregion

    #region on shoot

    public void OnShoot()
    {
        Vector3 force = bulletAttach.forward * bulletSpeed;     //creatin force
        GameObject newBullet = Instantiate(bulletPrefab);       //put it in the scene
        newBullet.transform.position = bulletAttach.position;   // set the transform
        newBullet.transform.rotation = gameObject.transform.rotation;       //make sure its facing forward in regards to where player is aiming
        Rigidbody rb = newBullet.GetComponent<Rigidbody>();     //get rb
        rb.AddForce(force, ForceMode.Impulse);      //shoot the thang
    }

    #endregion
}
