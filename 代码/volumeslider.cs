using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public AudioSource audioSource;
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void AdjustVolume()
    {
        float volume = slider.value;

        // 应用音量到音频源
        audioSource.volume = volume;
    }
}
