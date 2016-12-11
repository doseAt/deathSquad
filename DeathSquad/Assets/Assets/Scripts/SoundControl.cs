using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

namespace Pokega
{
	public class SoundControl : MonoBehaviour 
	{
		public UIToggle musicToggle;
		public UIToggle sfxToggle;
		public AudioMixer mixer;
		public string sfxVolumeExposedParName;
		public string musicVolumeExposedParName;

		public AudioSource[] sfxAudioSources;
		public static SoundControl instance = null;


		void Awake()
		{
			if (instance == null)
				instance = this;
			else if (instance != this)
				Destroy (gameObject);
			
			int musicOnOff = PlayerPrefs.GetInt ("MusicOnOff");
			if (musicOnOff == 1)
			{
				//Debug.Log("Sound is ON.");
				//musicToggle.value = false;
			}
			else 
			{
				//Debug.Log("Sound is OFF.");
				//musicToggle.value = true;
			}

			int sfxOnOff = PlayerPrefs.GetInt ("SfxOnOff");
			if (sfxOnOff == 1)
			{
				//Debug.Log("SFX is ON.");
				//sfxToggle.value = false;
			}
			else 
			{
				//Debug.Log("SFX is OFF.");
				//sfxToggle.value = true;
			}
		}

		void Start()
		{
			//EventDelegate.Add(musicToggle.onChange, OnMusicToggleChange);
			//EventDelegate.Add(sfxToggle.onChange, OnSfxToggleChange);
		}

		void OnDestroy() 
		{
			//EventDelegate.Remove(musicToggle.onChange, OnMusicToggleChange);
			//EventDelegate.Remove(sfxToggle.onChange, OnSfxToggleChange);
		}

		void OnMusicToggleChange() 
		{
			if (musicToggle.value) 
			{
				//set music OFF
				mixer.SetFloat(musicVolumeExposedParName, -80);
				PlayerPrefs.SetInt ("MusicOnOff", 0);
			}
			else 
			{
				//set music ON
				mixer.SetFloat(musicVolumeExposedParName, 0);
				PlayerPrefs.SetInt ("MusicOnOff", 1);
		}
		}

		void OnSfxToggleChange()
		{
			if (sfxToggle.value) 
			{
				//set music OFF
				mixer.SetFloat(sfxVolumeExposedParName, -80);
				PlayerPrefs.SetInt ("SfxOnOff", 0);
			}
			else 
			{
				//set music ON
				mixer.SetFloat(sfxVolumeExposedParName, 0);
				PlayerPrefs.SetInt ("SfxOnOff", 1);
			}
		}

		public void SetMusic(bool to)
		{
			if(to)
				musicToggle.value = false;
			else
				musicToggle.value = true;
		}

		public void SetSFX(bool to)
		{
			if(to)
				sfxToggle.value = false;
			else
				sfxToggle.value = true;
		}

		public void PlaySFX(string audioClipName, float pitchRandomFrom = 1.0f, float pitchRandomTo = 1.0f)
		{
			//foreach(AudioSource a in sfxAudioSources)
			//{
				//Debug.LogError(a.name + " - " + a.isPlaying);
			//}
			foreach(AudioSource a in sfxAudioSources)
			{
				if(a.clip.name == audioClipName)
				{
					if (a.isPlaying)
						a.Stop ();
					a.pitch = Random.Range(pitchRandomFrom, pitchRandomTo);
					a.Play();
					//a.pla

					return;
				}
			}
			//Debug.LogError("Error. You called SoundControl.PlaySFX(string ...) with audioClip name that doesn't exist in audioSources array!");
		}
	}
}
