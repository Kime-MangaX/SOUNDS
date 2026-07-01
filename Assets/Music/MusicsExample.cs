using UnityEngine;

public class MusicsExample : MonoBehaviour
{
    public AudioSource sounds;
    void Start()
    {
        sounds.Pause();
        sounds.Stop();
        sounds.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
