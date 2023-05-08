using UnityEngine;

public class AttackSoundController : MonoBehaviour
{
    public AudioSource attackAudioSource;
    public AudioClip[] attackSounds;
    public AudioClip deathSound;
    public AudioClip dodgeSound;

    private void Update()
    {
        

    }
    public void AttackSound()
    {
        int randomIndex = Random.Range(0, attackSounds.Length);
        AudioClip randomClip = attackSounds[randomIndex];

        attackAudioSource.PlayOneShot(randomClip);
    }
    public void DeathSound()
    {
        attackAudioSource.clip = deathSound;

        attackAudioSource.Play();
    }

    public void DodgeSound()
    {
        attackAudioSource.clip = dodgeSound;
        attackAudioSource.Play();

    }
}
