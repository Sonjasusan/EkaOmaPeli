using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Play nappi
   public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //ladataan buildindexist� seuraava level
    }

    //Quit nappi
    public void QuitGame()
    {
        Debug.Log("QUIT"); //konsoliin viesti lopetuksesta
        Application.Quit(); //Peli sammuu
    }
}
