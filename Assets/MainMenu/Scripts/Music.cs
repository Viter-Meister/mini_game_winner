using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip[] music;

    private int previousTrack = -1;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (!audioSource.isPlaying || Input.GetKeyDown(KeyCode.N))
        {
            int track;
            do track = Random.Range(0, music.Length);
            while (track == previousTrack);
            previousTrack = track;
            audioSource.clip = music[track];
            audioSource.Play();
        }
    }
}
