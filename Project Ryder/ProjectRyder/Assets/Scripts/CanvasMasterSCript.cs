using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMasterSCript : MonoBehaviour
{
    //a master script that will be implemented more in the future. purely just to turn
    //a canvas on or off when needed.
    public GameObject canvasToSelect;

    public void TurnOffCanvas()
    {
        canvasToSelect.SetActive(false);
    }

    public void TurnOnCanvas()
    {
        canvasToSelect.SetActive(false);
    }
}
