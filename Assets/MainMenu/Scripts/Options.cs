using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public TMP_Dropdown quality;
    public TMP_Dropdown resolution;
    public Toggle windowed;
    public Slider maxFPS;
    public TextMeshProUGUI nowMaxFPS;

    public Slider volume;
    public Slider sound;
    public Slider music;

    public AudioMixer master;
    private Resolution[] screenResolution;
    private AudioSource audioSource;

    public void Start()
    {
        screenResolution = Screen.resolutions;
        string[] strScreenResolution = new string[screenResolution.Length];

        for (int i = 0; i < screenResolution.Length; i++)
            strScreenResolution[i] = screenResolution[i].ToString();

        resolution.ClearOptions();
        resolution.AddOptions(strScreenResolution.ToList());

        quality.value = PlayerPrefs.GetInt("quality");

        resolution.value = PlayerPrefs.HasKey("resolution") ?
            PlayerPrefs.GetInt("resolution") : screenResolution.Length - 1;

        windowed.isOn = !Screen.fullScreen;

        maxFPS.value = PlayerPrefs.HasKey("maxfps") ? PlayerPrefs.GetInt("maxfps") : 120;
        nowMaxFPS.text = maxFPS.value.ToString();

        volume.value = PlayerPrefs.HasKey("volume") ?
            PlayerPrefs.GetFloat("volume") : 0.5f;
        sound.value = PlayerPrefs.HasKey("sound") ?
            PlayerPrefs.GetFloat("sound") : 0.5f;
        music.value = PlayerPrefs.HasKey("music") ?
            PlayerPrefs.GetFloat("music") : 0.5f;
    }

    public void StartOptions()
    {
        audioSource = GameObject.Find("Click(Clone)").GetComponent<AudioSource>();

        screenResolution = Screen.resolutions;

        {
            int value;
            value = PlayerPrefs.GetInt("quality");
            QualitySettings.SetQualityLevel(2 - value);

            value = PlayerPrefs.HasKey("resolution") 
                && PlayerPrefs.GetInt("resolution") < screenResolution.Length ?
                PlayerPrefs.GetInt("resolution") : screenResolution.Length - 1;
            Screen.SetResolution(screenResolution[value].width,
                screenResolution[value].height, Screen.fullScreen);

            value = PlayerPrefs.HasKey("maxfps") ? PlayerPrefs.GetInt("maxfps") : 300;
            Application.targetFrameRate = value;
        }
        
        {
            float value;
            value = PlayerPrefs.HasKey("volume") ? PlayerPrefs.GetFloat("volume") : 0.5f;
            master.SetFloat("Volume", Mathf.Log10(value) * 20);
            value = PlayerPrefs.HasKey("sound") ? PlayerPrefs.GetFloat("sound") : 0.5f;
            master.SetFloat("Sound", Mathf.Log10(value) * 20);
            value = PlayerPrefs.HasKey("music") ? PlayerPrefs.GetFloat("music") : 0.5f;
            master.SetFloat("Music", Mathf.Log10(value) * 20);
        }
    }

    public void Quality()
    {
        QualitySettings.SetQualityLevel(2 - quality.value);
        PlayerPrefs.SetInt("quality", quality.value);
    }

    public void Resolution()
    {
        Screen.SetResolution(screenResolution[resolution.value].width,
            screenResolution[resolution.value].height, Screen.fullScreen);
        PlayerPrefs.SetInt("resolution", resolution.value);
    }

    public void Windowed()
    {
        Screen.fullScreen = !windowed.isOn;
    }

    public void MaxFPS()
    {
        int value = (int)maxFPS.value;
        Application.targetFrameRate = value;
        nowMaxFPS.text = maxFPS.value.ToString();
        PlayerPrefs.SetInt("maxfps", value);
    }

    public void Volume()
    {
        master.SetFloat("Volume", Mathf.Log10(volume.value) * 20);
        PlayerPrefs.SetFloat("volume", volume.value);
    }

    public void Sound()
    {
        master.SetFloat("Sound", Mathf.Log10(sound.value) * 20);
        PlayerPrefs.SetFloat("sound", sound.value);
    }

    public void Music()
    {
        master.SetFloat("Music", Mathf.Log10(music.value) * 20);
        PlayerPrefs.SetFloat("music", music.value);
    }

    public void URL(string url)
    {
        Application.OpenURL(url);
    }

    public void MusicByMouseEnter(TextMeshProUGUI url)
    {
        url.color = new Color32(0, 132, 255, 255);
    }

    public void MusicByMouseExit(TextMeshProUGUI url)
    {
        url.color = new Color32(0, 183, 255, 255);
    }

    public void Back()
    {
        PlayerPrefs.Save();
        gameObject.SetActive(false);
    }

    public void AudioPlay()
    {
        audioSource.Play();
    }
}
