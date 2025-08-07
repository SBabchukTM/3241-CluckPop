using UnityEngine;

namespace Runtime.Core
{
    public static class AudioDataExtensions
    {
        public static AudioClip GetClip(this GameAudioConfigfile configfile, string clipId)
        {
            var audioData = configfile.Audio.Find(x => x.Id == clipId);
            return audioData.Clip;
        }
    }
}