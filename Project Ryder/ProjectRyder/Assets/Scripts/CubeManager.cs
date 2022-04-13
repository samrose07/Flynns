using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    /*This script was made week one of the proj
     * when we needed to have saving in it. Never used it again.
     */
    private Vector3 thisTransform;
    private Vector3 newTransform;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        thisTransform = gameObject.transform.position;
        newTransform = thisTransform;
        float x = PlayerPrefs.GetFloat("CubePositionX");
        float y = PlayerPrefs.GetFloat("CubePositionY");
        float z = PlayerPrefs.GetFloat("CubePositionZ");
        gameObject.transform.position = new Vector3(x, y, z);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("new transform = " + newTransform);
        newTransform = gameObject.transform.position;
        //if(newTransform != thisTransform)
        //{
            SaveTransformPosition();
       // }

        
    }

    private void SaveTransformPosition()
    {
        PlayerPrefs.SetFloat("CubePositionX", (float)newTransform.x);
        PlayerPrefs.SetFloat("CubePositionY", (float)newTransform.y);
        PlayerPrefs.SetFloat("CubePositionZ", (float)newTransform.z);
        PlayerPrefs.Save();
        //gameManager.position = newTransform;
    }
}
