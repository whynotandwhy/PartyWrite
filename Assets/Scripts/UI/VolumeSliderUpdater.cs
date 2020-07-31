
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderUpdater : MonoBehaviour
{
    [SerializeField] protected Slider bgmVolumeSlider;

    protected AudioManager audioManager;


    public void UpdateBGMVolume() => audioManager.BGMVolume = bgmVolumeSlider.value;


    protected void Awake() => audioManager = FindObjectOfType<AudioManager>();
    protected void Start() => InitSliders();

    protected void InitSliders()
    {
        bgmVolumeSlider.value = audioManager.BGMVolume;
    }
}
