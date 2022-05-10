using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void OnEnable()
    {
        slider.onValueChanged.AddListener(OnSliderValueChanged);
        slider.value = AudioManager.instance.GetComponent<AudioSource>().volume; //Varför fel???
    }

    private void OnDisable()
    {
        slider.onValueChanged.RemoveListener(OnSliderValueChanged);

    }
    public void OnSliderValueChanged(float value)
    {
        //AudioManager.instance.GetComponent<AudioSource>().volume = value;
        AudioManager.instance.SetVolume(value);
    }
}
