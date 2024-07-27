using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scorer : MonoBehaviour
{

    public TMP_Text tagText;
    // Start is called before the first frame update
    void Start()
    {
       if (tagText != null)
        {
            // Retrieve and display the object tag from PlayerPrefs
            string score = PlayerPrefs.GetString("HitObjectTag", "No Tag"); // "No Tag" is the default value if the key doesn't exist
            tagText.text = "Your Score is:" + score;
        }  
    }

}
