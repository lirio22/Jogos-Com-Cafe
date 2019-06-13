using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ControleVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer masterMixer;

    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        VolumeBGM();
        VolumeSFX();
    }

    public void VolumeBGM()
    {
        masterMixer.SetFloat("BGM", bgmSlider.value);
    }

    public void VolumeSFX()
    {
        masterMixer.SetFloat("SFX", sfxSlider.value);
    }
}

