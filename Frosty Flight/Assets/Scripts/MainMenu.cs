using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private AudioClip confirmSound;

    [SerializeField]
    private AudioClip quitSound;

    [SerializeField]
    private AudioSource audioSource;

    public void PlayBtnClicked()
    {
        StartCoroutine(PlaySoundAndLoadScene(confirmSound));
    }

    public void QuitBtnClicked()
    {
        StartCoroutine(PlaySoundAndQuit(quitSound));
    }

    private System.Collections.IEnumerator PlaySoundAndLoadScene(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
        yield return new WaitForSeconds(clip.length);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private System.Collections.IEnumerator PlaySoundAndQuit(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
        yield return new WaitForSeconds(clip.length);
        Application.Quit();
    }
}
