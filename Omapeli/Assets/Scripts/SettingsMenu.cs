using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer; //äänenvoimakkuussäätäjä

    public Dropdown  resolutionDropDown; //Unityn puolella oleva dropdown joka nimetään resolutionDropDowniksi

    Resolution[] resolutions; //array resolutioneja

    public void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions(); //tyhjennetään resolutionDropDown

        List<string> options = new List<string>(); //Tehdään string tyyppinen options-lista resoluutioista

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++) //loopataan Resolution[] arrayn jokainen elementti läpi
        {
            //jokainen elementtiä listalla muutetaan stringiksi jotka on resoluution leveys x korkeus (esim. 1420 x 960)
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option); //Lisätään loopattu lista options listalle

            //katsotaan mikä on ajankohtainen resoluutio
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(options); //Lisätään optionsit resolutionDropDowniin
        resolutionDropDown.value = currentResolutionIndex; //Näytetään ajankohtainen resoluutioS
        resolutionDropDown.RefreshShownValue(); //Päivitetään näytettävä arvo (aiemmin pienimmästä suurimpaan -> nyt nykyinen arvo)
    }

    //Resoluutionin setti
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    //Äänenvoimakkuus
    public void SetVolume(float volume) 
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
