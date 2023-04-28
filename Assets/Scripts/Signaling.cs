using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    [SerializeField] private float _volumeChangeRate;

    private AudioSource _signalSource;
    private float _volumeMultiplier;

    private void Awake()
    {
        _signalSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _signalSource.volume = Mathf.MoveTowards(_signalSource.volume, 1, _volumeChangeRate * Time.deltaTime * _volumeMultiplier);

        if (_signalSource.volume <= 0)
            _signalSource.Stop();
    }

    public void StartSignal()
    {
        _signalSource.Play();
        _volumeMultiplier = 1;
    }

    public void StopSignal()
    {
        _volumeMultiplier = -1;
    }
}
