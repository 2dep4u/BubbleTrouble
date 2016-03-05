using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class AudioController : MonoBehaviour {

    private new AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void musicToggle()
    {
        if (audio.mute)
            audio.mute = false;
        else
            audio.mute = true;
    }
}
