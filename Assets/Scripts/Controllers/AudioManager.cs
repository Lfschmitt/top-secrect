using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 0.7f;
    [Range(.5f, 4f)]
    public float pitch = 1f;
    public bool loop;

    [Range(0f, 0.5f)]
    public float randomVolume = 0.1f;
    [Range(0f, 0.5f)]
    public float randomPitch = 0.1f;


    private AudioSource source;

    public void SetSource(AudioSource _source)
    {
        _source.GetComponent<AudioSource>();
        source = _source;
        source.clip = clip;
    }

    public void Play()
    {
        source.volume = volume * (1 + Random.Range(-randomVolume/2f , randomVolume/2f));
        source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f));
        source.loop = loop;
        source.Play();
    }

    public void Stop()
    {
        source.Stop();
    }

    public void Pause()
    {
        source.Pause();
    } 
}

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    [SerializeField]
    Sound[] sound;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More tham one AudioManager in the scene");
        }
        else
        {
            instance = this;
        }
    }



    private void Start()
    {
        for(int i = 0; i < sound.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sound[i].name);
            _go.transform.SetParent(this.transform);
            sound[i].SetSource (_go.AddComponent<AudioSource>());
        }
    }

    public void PlaySound (string _name)
    {
        for (int i = 0; i < sound.Length; i++)
        {
            if(sound[i].name == _name)
            {
                sound[i].Play();
                return;
            }
        }

        //no sound with _name
        Debug.Log("AudioManager: Sound not found in list: " + _name);
    }
    public void StopSound(string _name)
    {
        for (int i = 0; i < sound.Length; i++)
        {
            if (sound[i].name == _name)
            {
                sound[i].Stop();
                return;
            }
        }

        //no sound with _name
        Debug.Log("AudioManager: Sound not found in list: " + _name);
    }
    public void PauseSound(string _name)
    {
        for (int i = 0; i < sound.Length; i++)
        {
            if (sound[i].name == _name)
            {
                sound[i].Pause();
                return;
            }
        }

        //no sound with _name
        Debug.Log("AudioManager: Sound not found in list: " + _name);
    }
}
