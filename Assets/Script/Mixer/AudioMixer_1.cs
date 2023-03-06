using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixer_1 : MonoBehaviour
{
    public AudioMixer mixer;

    [Range(-80, 0)]
    public float master = 0;
    [Range(-80, 0)]
    public float bgm = 0;
    [Range(-80, 0)]
    public float effect = 0;

    public Slider bgmSlider;
    public Slider effectSlider;
    public void MixerControl()
    {
        mixer.SetFloat(nameof(master), master);
        mixer.SetFloat(nameof(bgm), bgm);
        mixer.SetFloat(nameof(effect), effect);
    }
    public void SetBgm()
    {
        mixer.SetFloat("bgm", Mathf.Log10(bgmSlider.value) * 20);
    }
    public void SetEffect()
    {
        mixer.SetFloat("effect", Mathf.Log10(effectSlider.value) * 20);
    }
    void Start()
    {
        
    }
    
    void Update()
    {
        //MixerControl();
    }
}
