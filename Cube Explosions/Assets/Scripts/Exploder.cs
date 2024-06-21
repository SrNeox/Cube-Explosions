using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 50f;

    private float _explosionRadius = 5;

    public void Explosion(Cube cube)
    {
        if (cube.TryGetComponent(out Rigidbody rigidbody))
            rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }
}
