using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text cherriesText, diamondsText;
    public int cherries;
    public int diamonds;

    [SerializeField] private AudioSource collectionSoundEffect;

    //end screeniin kaik ker‰tyt(?)
    //public static int cherryAmount = 0;
    ////public static int totalDiamonds = 0;

    private void Start()
    {
        cherriesText.enabled = false;
        diamondsText.enabled = false;
    }

    private void PlayerHeal(int healing) 
    {
        GameManager.gameManager._playerHealth.healUnit(healing); //Tuodaan gamemanagerista healthi ja heal
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry")) //Jos osutaan gameObjectiin, jolla on tagi "Cherry"
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject); //Tuhotaan se (katoaa n‰kyvist‰)
            PlayerHeal(5); //healaa playeria kerralla 5
            Debug.Log(GameManager.gameManager._playerHealth.PlayerHealth); //Logataan health consoliin (ei n‰y oikeassa peliss‰)
            GameManager.cherries++; //Lis‰t‰‰n cherry intiin ker‰tyt (esim +1)

            Debug.Log(GameManager.cherries + " Cherries collected.");
            cherriesText.enabled=true; //N‰ytet‰‰n teksti
            cherriesText.text = "Cherries: " + GameManager.cherries; //N‰ytet‰‰n ker‰tyt tekstikent‰ss‰
        }

        if (collision.gameObject.CompareTag("Diamond")) //Jos tagi "Diamond"
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            GameManager.diamonds++;
            diamondsText.enabled=true; //N‰ytet‰‰n teksti 
            diamondsText.text = "Diamonds: " + GameManager.diamonds;
        }

    }
}
