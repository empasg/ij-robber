using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    [SerializeField] private float _volumeChangeRate;

    private AudioSource _signalSource;
    private int _desiredVolume;

    private void Awake()
    {
        _signalSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_signalSource.volume == _desiredVolume)
            return;

        _signalSource.volume = Mathf.MoveTowards(_signalSource.volume, _desiredVolume, _volumeChangeRate * Time.deltaTime);

        if (_signalSource.volume <= 0)
            _signalSource.Stop();
    }

    public void StartSignal()
    {
        _signalSource.Play();
        _desiredVolume = 1;
    }

    public void StopSignal()
    {
        _desiredVolume = 0;
    }
}
