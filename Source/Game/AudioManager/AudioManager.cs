using System;
using System.Collections.Generic;
using FlaxEngine;

namespace Game
{
    public class AudioManager : Script
    {
        public Action<AudioSource , AudioClip> Play;

        private AudioSource MainAudioSouce;
        private AudioClip MainClip;
        public void SetAudioSource(AudioSource source)
        {
            MainAudioSouce = source;
        }

        public void SetAudioClip(AudioClip clip)
        {
            MainClip = clip;
        }
        public void PlayAudio()
        {
            MainAudioSouce.Clip = MainClip;
            MainAudioSouce.Play();
        }




        
    }
}
