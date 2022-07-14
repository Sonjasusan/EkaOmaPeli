using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }
    public Health _playerHealth = new Health(100,100);
    
    //Text = cherriesText;
    public static int cherries = 0;
    public static int diamonds = 0;


    void Awake()
    {
        if (gameManager != null && gameManager != this) //Jos tehd��n uusi gamemanager
        {
            Destroy(this); //tuhotaan t�m�
        }
        else
        {
            gameManager = this; //Muussa tapauksessa t�� on SE gamemanager
        }

        if (cherries > 1)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        if (diamonds > 1)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

}
