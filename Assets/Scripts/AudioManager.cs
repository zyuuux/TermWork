using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{
    //��Ƶ������ �洢���е���Ƶ���ҿ��Բ��ź�ֹͣ
    [Serializable]
    public class Sound
    {
        [Header("��Ƶ����")]
        public AudioClip clip;

        [Header("��Ƶ����")]
        public AudioMixerGroup outputGroup;

        [Header("��Ƶ����")]
        [Range(0, 1)]
        public float volume;

        [Header("��Ƶ�Ƿ�������")]
        public bool PlayOnAwake;

        [Header("��Ƶ�Ƿ�Ҫѭ������")]
        public bool loop;
    }

    public List<Sound> sounds;//�洢������Ƶ����Ϣ
    private Dictionary<string, AudioSource> audioDic;//ÿһ����Ƶ���������

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


    //����ĳ����Ƶ�ķ��� iswaitΪ�Ƿ�ȴ�
    public static void PlayAudio(string name, bool isWait = false)
    {
        if (!Instance.audioDic.ContainsKey(name))
        {
            //�����ڴ���Ƶ
            Debug.LogError("������" + name + "��Ƶ");
            return;
        }

        if (isWait)
        {
            if (!Instance.audioDic[name].isPlaying)
            {
                //����ǵȴ������ ���ڲ���
                Instance.audioDic[name].Play();
            }
        }
        else
        {
            //ֱ�Ӳ���
            Instance.audioDic[name].Play();
        }
    }


    //ֹͣ��Ƶ�Ĳ���
    public static void StopMute(string name)
    {

        if (!Instance.audioDic.ContainsKey(name))
        {
            //�����ڴ���Ƶ
            Debug.LogError("������" + name + "��Ƶ");
            return;
        }
        else
        {
            Instance.audioDic[name].Stop();

        }
    }
}
