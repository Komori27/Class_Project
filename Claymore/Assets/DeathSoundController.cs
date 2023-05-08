using UnityEngine;

public class DeathSoundController : MonoBehaviour
{
    public AudioSource attackAudioSource;
    public AudioClip[] attackSounds;

    private void Update()
    {


    }
    public void AttackSound()
    {
        int randomIndex = Random.Range(0, attackSounds.Length);
        AudioClip randomClip = attackSounds[randomIndex];

        attackAudioSource.PlayOneShot(randomClip);
    }
}
