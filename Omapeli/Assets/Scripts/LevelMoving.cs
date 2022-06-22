using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMoving : MonoBehaviour
{

    public int sceneBuildIndex;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger entered");

        if (other.tag == "Player")
        {
            //Pelaaja osuu kohtaan - vaihdetaan leveliä
            print("Switching scene to: " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
  
}
