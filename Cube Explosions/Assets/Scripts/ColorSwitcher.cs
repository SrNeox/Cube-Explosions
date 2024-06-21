using UnityEngine;

public class ColorSwitcher : MonoBehaviour
{
    public void SwitchColor(Cube cube)
    {
        if (cube.TryGetComponent(out Renderer renderer))
            renderer.material.color = new Color(Random.value, Random.value, Random.value, 1f);

    }
}
