/* This script was made by Samuel Rose at Boise State University.
 * 
 * The purpose of this script is to make the bullets go away after a certain time
 * 
 * Biodigital Jazz, man
 */
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region on spawn destroy
    private void Start()
    {
        Invoke("DestroyMe", 3f);    //once im spawned make me die in three whole seconds
    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }
    #endregion
}
