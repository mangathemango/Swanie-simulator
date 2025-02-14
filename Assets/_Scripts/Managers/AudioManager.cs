using UnityEngine;

public class AudioManager: Singleton<AudioManager> {
    public AudioClip jumpSound;
    public AudioClip shootSound;
    public AudioClip backgroundMusic;
    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
    public void PlayJumpSound() {
        audioSource.PlayOneShot(jumpSound);
    }

    public void PlayShootSound() {
        audioSource.PlayOneShot(shootSound);
    }
}