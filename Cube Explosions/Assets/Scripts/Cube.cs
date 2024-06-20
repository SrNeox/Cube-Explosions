using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 50f;
    [SerializeField] private float _splitChance = 1.0f;

    private Vector3 _explosionRadius = new(5f, 5f, 5f);

    private void OnMouseDown()
    {
        SplitCube();
    }

    public void ReduceChance() => _splitChance /= 2;

    private void SplitCube()
    {
        if (Random.value <= _splitChance)
        {
            int newCubeCount = Random.Range(2, 7);

            for (int i = 0; i < newCubeCount; i++)
            {
                Cube newCube = Instantiate(this, transform.position, Random.rotation);
                newCube.transform.localScale = transform.localScale / 2;

                newCube.TryGetComponent(out Renderer renderer);
                renderer.material.color = new Color(Random.value, Random.value, Random.value, 1f);

                newCube.TryGetComponent(out Rigidbody rigidbody);
                rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius.x);

                newCube.ReduceChance();
            }
        }

        Destroy(gameObject);
    }
}
