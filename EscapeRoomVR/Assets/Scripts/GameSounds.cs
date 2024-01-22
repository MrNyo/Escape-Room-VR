using UnityEngine;

public class GameSounds : MonoBehaviour
{
    [Tooltip("The sound that is played when a button is pressed")]
    public AudioClip buttonPress;

    [Tooltip("The sound that is played when challenge is won")]
    public AudioClip wonChallenge;

    [Tooltip("The sound that is played when challenge is failed")]
    public AudioClip failedChallenge;

    [Tooltip("The sound that is played when game is won")]
    public AudioClip gameWon;

    [Tooltip("The volume of the sound")] public float volume = 1.0f;

    [Tooltip("The range of pitch the sound is played at (-pitch, pitch)")] [Range(0, 1)]
    public float randomPitchVariance;

    private AudioSource _audioSource;

    private const float DefaultPitch = 1.0f;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.OnSoundPlayed += PlaySound;
    }

    /**
     * Plays different sound depending on what event is triggered
     */
    void PlaySound(SoundTypes sound)
    {
        float randomVariance = Random.Range(-randomPitchVariance, randomPitchVariance);
        randomVariance += DefaultPitch;

        _audioSource.pitch = randomVariance;
        switch (sound)
        {
            case SoundTypes.Button:
                _audioSource.PlayOneShot(buttonPress, volume);
                break;
            case SoundTypes.ChallengeWon:
                _audioSource.PlayOneShot(wonChallenge, volume);
                break;
            case SoundTypes.ChallengeFailed:
                _audioSource.PlayOneShot(failedChallenge, volume);
                break;
            case SoundTypes.GameWon:
                _audioSource.PlayOneShot(gameWon, volume);
                break;
            default:
                print("Should not have happened!");
                break;
        }

        _audioSource.pitch = DefaultPitch;
    }
}