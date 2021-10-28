using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ChooseModelScene");
    }
}
