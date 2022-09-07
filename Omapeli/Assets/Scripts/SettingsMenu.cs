using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer; //‰‰nenvoimakkuuss‰‰t‰j‰

    public Dropdown  resolutionDropDown; //Unityn puolella oleva dropdown joka nimet‰‰n resolutionDropDowniksi

    Resolution[] resolutions; //array resolutioneja

    public void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions(); //tyhjennet‰‰n resolutionDropDown

        List<string> options = new List<string>(); //Tehd‰‰n string tyyppinen options-lista resoluutioista

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++) //loopataan Resolution[] arrayn jokainen elementti l‰pi
        {
            //jokainen elementti‰ listalla muutetaan stringiksi jotka on resoluution leveys x korkeus (esim. 1420 x 960)
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option); //Lis‰t‰‰n loopattu lista options listalle

            //katsotaan mik‰ on ajankohtainen resoluutio
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(options); //Lis‰t‰‰n optionsit resolutionDropDowniin
        resolutionDropDown.value = currentResolutionIndex; //N‰ytet‰‰n ajankohtainen resoluutioS
        resolutionDropDown.RefreshShownValue(); //P‰ivitet‰‰n n‰ytett‰v‰ arvo (aiemmin pienimm‰st‰ suurimpaan -> nyt nykyinen arvo)
    }

    //Resoluutionin setti
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    //ƒ‰nenvoimakkuus
    public void SetVolume(float volume) 
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
