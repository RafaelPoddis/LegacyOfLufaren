using UnityEngine;

public class TavernMusic : MonoBehaviour
{
    [SerializeField] private float soundDistance = 30f;
    [SerializeField] private float volumeMusic = 1f;

    private PlayerMovement player;
    private AudioSource audioSource;
    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        VolumeChanger();
    }
    private void VolumeChanger()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < soundDistance && distance > 0)
        {
            audioSource.volume = Mathf.Clamp(volumeMusic / distance, 0f, 1f);
        }
        else
        {
            audioSource.volume = 0f;
        }
    }
}
