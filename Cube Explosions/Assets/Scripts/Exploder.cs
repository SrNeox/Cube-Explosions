using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 50f;

    private float _explosionRadius = 5;

    public void Explosion(Cube cube , float buffExlosions = 1)
    {
        if (cube.TryGetComponent(out Rigidbody rigidbody))
            rigidbody.AddExplosionForce(_explosionForce * buffExlosions, transform.position, _explosionRadius);
    }

    public float CalculateExplosionForce(Transform transformCube)
    {
        float distance = Vector3.Distance(transform.position, transformCube.position);
        float buffExplosion = 1f - (distance / _explosionRadius);
        return Mathf.Max(0,buffExplosion);
    }
}
