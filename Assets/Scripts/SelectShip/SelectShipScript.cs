using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectShipScript : MonoBehaviour
{
    public void selectFirst()
    {
        Parameters.SelectFirstSpaceCraft();
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }

    public void selectSecond()
    {
        Parameters.SelectSecondSpaceCraft();
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}
