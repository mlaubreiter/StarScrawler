using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameters : MonoBehaviour
{
    public static int HighScore = 0;
    public static int SpaceCraft = 1;

    public static void IncreaseScore(int added)
    {
        HighScore += added;
    }

    public static void SelectFirstSpaceCraft()
    {
         SpaceCraft = 0;
    }

    public static void SelectSecondSpaceCraft()
    {
        SpaceCraft = 1;
    }
}
