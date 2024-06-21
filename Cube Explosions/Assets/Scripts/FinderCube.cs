using UnityEngine;

public class FinderCube : MonoBehaviour
{
    [SerializeField] private float _scanRadius = 50;

    private Collider[] colliders; 

    public Collider[] Scan() => colliders = Physics.OverlapSphere(transform.position, _scanRadius);
}
