using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{
    //音频管理器 存储所有的音频并且可以播放和停止
    [Serializable]
    public class Sound
    {
        [Header("音频剪辑")]
        public AudioClip clip;

        [Header("音频分组")]
        public AudioMixerGroup outputGroup;

        [Header("音频音量")]
        [Range(0, 1)]
        public float volume;

        [Header("音频是否自启动")]
        public bool PlayOnAwake;

        [Header("音频是否要循环播放")]
        public bool loop;
    }

    public List<Sound> sounds;//存储所有音频的信息
    private Dictionary<string, AudioSource> audioDic;//每一个音频的名称组件

    private void Start()
    {
        audioDic = new Dictionary<string, AudioSource>();

        foreach (var sound in sounds)
        {
            GameObject obj = new GameObject(sound.clip.name);
            obj.transform.SetParent(transform);

            AudioSource source = obj.AddComponent<AudioSource>();
            source.clip = sound.clip;
            source.volume = sound.volume;
            source.playOnAwake = sound.PlayOnAwake;
            source.loop = sound.loop;
            source.outputAudioMixerGroup = sound.outputGroup;


            if (sound.PlayOnAwake)
            {
                source.Play();
            }
            audioDic.Add(sound.clip.name, source);
        }
    }


    //播放某个音频的方法 iswait为是否等待
    public static void PlayAudio(string name, bool isWait = false)
    {
        if (!Instance.audioDic.ContainsKey(name))
        {
            //不存在次音频
            Debug.LogError("不存在" + name + "音频");
            return;
        }

        if (isWait)
        {
            if (!Instance.audioDic[name].isPlaying)
            {
                //如果是等待的情况 不在播放
                Instance.audioDic[name].Play();
            }
        }
        else
        {
            //直接播放
            Instance.audioDic[name].Play();
        }
    }


    //停止音频的播放
    public static void StopMute(string name)
    {

        if (!Instance.audioDic.ContainsKey(name))
        {
            //不存在次音频
            Debug.LogError("不存在" + name + "音频");
            return;
        }
        else
        {
            Instance.audioDic[name].Stop();

        }
    }
}
