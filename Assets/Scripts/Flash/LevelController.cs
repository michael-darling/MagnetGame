using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] FlashImage _flashImage = null;
    [SerializeField] Color _newColor = Color.red;
    [SerializeField] private AudioClip explosionSoundClip;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _flashImage.StartFlash(.25f, .25f, _newColor);
            Debug.Log("Space Pressed");
            SoundFXManager.instance.PlaySoundFXClip(explosionSoundClip, transform, 1f);
        }
    }
}
