using UnityEngine;

[CreateAssetMenu]
public class GenericResources : ScriptableObject // todo rename to generic
{
    [SerializeField]
    public Block[] Blocks;

    [SerializeField]
    public GameObject SmallExplosion;

    [SerializeField]
    public GameObject TankExplosion;

    [SerializeField]
    public GameObject SpawnAnimation;
}
