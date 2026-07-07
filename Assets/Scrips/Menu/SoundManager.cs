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
    private AudioSource audioSourceLoop; // Para caminar/correr en loop

    void Awake()
    {
        // Singleton para acceder desde cualquier script
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
        // Dos AudioSource: uno para efectos, otro para pasos en loop
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSourceLoop = gameObject.AddComponent<AudioSource>();
        audioSourceLoop.loop = true;
    }

    // Reproducir sonido una vez
    public void Play(AudioClip clip)
    {
        if (clip == null) return;
        audioSource.PlayOneShot(clip);
    }

    // Sonidos específicos
    public void PlayDerrota() => Play(sonidoDerrota);
    public void PlaySaltar() => Play(sonidoSaltar);
    public void PlayInteractuar() => Play(sonidoInteractuar);

    // Caminar y correr en loop
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