using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.UI;

public class Mute: MonoBehaviour
{
    private bool isMuted;
    public Sprite mutedSprite;
    public Sprite unmutedSprite;
    public AudioSource audioSource;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        isMuted = false;
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;

        if (isMuted)
        {
            // 静音
            audioSource.mute = true;
            button.image.sprite = mutedSprite;
        }
        else
        {
            // 取消静音
            audioSource.mute = false;
            button.image.sprite = unmutedSprite;
        }
    }
}
