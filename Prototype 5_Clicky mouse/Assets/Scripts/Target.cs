using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody _targetRb;
    private GameManager _gameManager;
    private float _minSpeed = 12;
    private float _maxSpeed = 15.5f;
    private float _maxTorque = 10;
    private float _xRange = 4;
    private float _ySpawnPos = -2;

    [SerializeField] private int _pointValue;
    [SerializeField] private ParticleSystem _explosionParticle;

    private void Start()
    {
        _targetRb = GetComponent<Rigidbody>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        _targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        _targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = SpawnPosition();
    }

    private void OnMouseDown()
    {
        if (_gameManager._isGameActive)
        {
            Destroy(gameObject);
            Instantiate(_explosionParticle, transform.position, _explosionParticle.transform.rotation);
            _gameManager.UpdateScore(_pointValue);

            if (gameObject.CompareTag("Bad"))
            {
                _gameManager.GameOver();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        
        if (!gameObject.CompareTag("Bad"))
        {
            _gameManager.GameOver();
        }
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(_minSpeed, _maxSpeed);
    }

    private float RandomTorque()
    {
        return Random.Range(-_maxTorque, _maxTorque);
    }

    private Vector3 SpawnPosition()
    {
        return new Vector3(Random.Range(-_xRange, _xRange), _ySpawnPos);
    }
}
