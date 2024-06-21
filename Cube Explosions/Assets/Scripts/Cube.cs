using UnityEngine;

public class Cube : MonoBehaviour
{
    private const float _numberDivision = 2;
    private const int _minCube = 2;
    private const int _maxCube = 7;

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private ColorSwitcher _colorSwitcher;
    [SerializeField] private Exploder _exploder;

    private float _splitChance = 1.0f;

    private void OnMouseDown()
    {
        SplitCube();
    }

    public void ReduceChance() => _splitChance /= _numberDivision;

    private void SplitCube()
    {
        if (Random.value <= _splitChance)
        {
            int newCubeCount = Random.Range(_minCube, _maxCube);
            Vector3 scale = transform.localScale / _numberDivision;

            for (int i = 0; i < newCubeCount; i++)
            {
                Cube newCube = _spawner.Spawn(this);
                newCube.transform.localScale = scale;
                _colorSwitcher.SwitchColor(newCube);
                _exploder.Explosion(newCube);
                newCube.ReduceChance();
            }
        }

        Destroy(gameObject);
    }
}
