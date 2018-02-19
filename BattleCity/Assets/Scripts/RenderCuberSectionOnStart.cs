using UnityEngine;

public class RenderCuberSectionOnStart : MonoBehaviour
{
    [SerializeField]
    Vector3 offset = new Vector3(0.375f, 0.375f);

    Vector2 tiling;

    void Start()
    {
        tiling = new Vector2(transform.localScale.x, transform.localScale.y);
        var material = GetComponent<Renderer>().material;
        material.mainTextureScale = tiling;
        material.SetTextureOffset("_MainTex", transform.localPosition + offset);
    }
}
