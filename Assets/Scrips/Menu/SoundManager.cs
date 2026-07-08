using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Sonidos")]
    public AudioClip sonidoDerrota;
    public AudioClip sonidoSaltar;
    public AudioClip sonidoCorrer;
    public AudioClip sonidoCaminar;
    public AudioClip sonidoInteractuar;

    private AudioSource audioSource;
    private AudioSource audioSourceLoop; 

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSourceLoop = gameObject.AddComponent<AudioSource>();
        audioSourceLoop.loop = true;
    }

    public void Play(AudioClip clip)
    {
        if (clip == null) return;
        audioSource.PlayOneShot(clip);
    }


    public void PlayDerrota() => Play(sonidoDerrota);
    public void PlaySaltar() => Play(sonidoSaltar);
    public void PlayInteractuar() => Play(sonidoInteractuar);


    public void PlayPasos(bool corriendo)
    {
        AudioClip clip = corriendo ? sonidoCorrer : sonidoCaminar;

        if (audioSourceLoop.clip == clip && audioSourceLoop.isPlaying) return;

        audioSourceLoop.clip = clip;
        audioSourceLoop.Play();
    }

    public void StopPasos()
    {
        if (audioSourceLoop.isPlaying)
            audioSourceLoop.Stop();
    }
}