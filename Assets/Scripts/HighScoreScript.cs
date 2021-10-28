using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreScript : MonoBehaviour
{
    void Update()
    {
        gameObject.GetComponent<UnityEngine.UI.Text>().text = Parameters.HighScore.ToString();
    }
}
