using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retry : MonoBehaviour
{
    // Start is called before the first frame update
    public void RetryGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene(0);
    }

    
}
