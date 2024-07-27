using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class mover : MonoBehaviour
{
    [SerializeField] float birdspeed=0.05f;
    [SerializeField]float thrust=1000f;

//    public float speedIncrement = 2f; // Speed increment value
    public float incrementInterval = 7f;
    [SerializeField]ParticleSystem CrashParticles;
    [SerializeField]float delaytime=0.6f;
    Rigidbody rbd;
    // Start is called before the first frame update
    void Start()
    {
        rbd=GetComponent<Rigidbody>();
        StartCoroutine(EnableGravityAfterDelay(1f));
        InvokeRepeating("IncrementSpeed", incrementInterval, incrementInterval);
    }

    // Update is called once per frame
    void Update()
    {
        // StartCoroutine(ChangeSpeedAfterDelay(delay));
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        movePlayer();
        ProcessThrust();
    }

void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
          StartThrusting();
        }     
    }

void StartThrusting()
    {
      rbd.AddRelativeForce(Vector3.up*Time.deltaTime*thrust);
       // rbd.AddForce(Vector3.up * thrust * Time.deltaTime, ForceMode.Impulse);
    }
void movePlayer()
{
    transform.Translate(0,0,birdspeed*Time.deltaTime);
}
void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag=="Finish")
        {
            SceneManager.LoadScene(4);
        }
        
        if(other.gameObject.tag!="NoWorry" &&  other.gameObject.tag!="Untagged")
    {
        CrashParticles.Play();
        string score = other.gameObject.tag;
        PlayerPrefs.SetString("HitObjectTag", score);
        PlayerPrefs.Save();
        Invoke("RetryScene",delaytime);
        // scoretaker.DisplayScore(score);
        // Invoke("ReloadLevel", delaytime);
    }
    
    }
        

// void ReloadLevel()
// {
//      int sceneindex=SceneManager.GetActiveScene().buildIndex;
//     SceneManager.LoadScene(sceneindex);
// }

void RetryScene()
{
    int sceneindex=SceneManager.GetActiveScene().buildIndex;
     SceneManager.LoadScene(sceneindex+1); 
}
 

  IEnumerator EnableGravityAfterDelay(float delay)
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delay);

        // Enable gravity on the Rigidbody
        if (rbd != null)
        {
            rbd.useGravity = true;
            Debug.Log("Gravity enabled on the Rigidbody.");
        }
        else
        {
            Debug.LogError("Rigidbody component not found!");
        }
    }

     void IncrementSpeed()
    {
        Debug.Log("Speed incremented!"+birdspeed );
        // Increase the speed
        birdspeed += 0.82f;
    }
}


