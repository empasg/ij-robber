using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    [SerializeField] private float _volumeChangeRate;

    private AudioSource _signalSource;
    private int _desiredVolume;
    private Coroutine _currentCoroutine;

    private void Awake()
    {
        _signalSource = GetComponent<AudioSource>();
    }

    public void StartSignal()
    {
        _desiredVolume = 1;

        StartChangeVolume();
    }

    public void StopSignal()
    {
        _desiredVolume = 0;

        StartChangeVolume();
    }

    private void StartChangeVolume()
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        while(_signalSource.volume != _desiredVolume)
        {
            _signalSource.volume = Mathf.MoveTowards(_signalSource.volume, _desiredVolume, _volumeChangeRate * Time.deltaTime);

            yield return null;
        }
    }
}
