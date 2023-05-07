using System.Collections.Generic;
using Audio.Model;
using UnityEngine;

namespace Audio.Script
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private List<GameAudio> sfxAudioList;
        [SerializeField] private List<GameAudio> musicAudioList;
        [SerializeField] private AudioSource sfxAudioSource;
        [SerializeField] private AudioSource musicAudioSource;


        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void PlaySfxAudio(string clipName)
        {
            var gameAudio = sfxAudioList.Find(a => a.ClipName == clipName);
            if (gameAudio == null)
            {
                Debug.Log("sfx not found");
            }
            else
            {
                sfxAudioSource.clip = gameAudio.Clip;
                sfxAudioSource.loop = false;
                sfxAudioSource.Play();
            }
        }

        public void PlayMusicAudio(string clipName)
        {
            var gameAudio = musicAudioList.Find(a => a.ClipName == clipName);
            if (gameAudio == null)
            {
                Debug.Log("sfx not found");
            }
            else
            {
                musicAudioSource.clip = gameAudio.Clip;
                musicAudioSource.loop = true;
                musicAudioSource.Play();
            }
        }

        public void StopSfxAudio(string clipName)
        {
            var gameAudio = sfxAudioList.Find(a => a.ClipName == clipName);
            if (gameAudio == null)
            {
                Debug.Log("sfx not found");
            }
            else
            {
                sfxAudioSource.clip = gameAudio.Clip;
                sfxAudioSource.Stop();
            }
        }

        public void StopMusicAudio(string clipName)
        {
            var gameAudio = musicAudioList.Find(a => a.ClipName == clipName);
            if (gameAudio == null)
            {
                Debug.Log("sfx not found");
            }
            else
            {
                musicAudioSource.clip = gameAudio.Clip;
                musicAudioSource.Stop();
            }
        }

        public AudioSource FetchSfxAudio(string clipName)
        {
            var gameAudio = sfxAudioList.Find(a => a.ClipName == clipName);
            if (gameAudio == null)
            {
                Debug.Log("sfx not found");
            }
            else
            {
                sfxAudioSource.clip = gameAudio.Clip;
                sfxAudioSource.loop = false;
            }

            return sfxAudioSource;
        }

        public AudioSource FetchMusicAudio(string clipName)
        {
            var gameAudio = musicAudioList.Find(a => a.ClipName == clipName);
            if (gameAudio == null)
            {
                Debug.Log("sfx not found");
            }
            else
            {
                musicAudioSource.clip = gameAudio.Clip;
            }

            return musicAudioSource;
        }
    }
}