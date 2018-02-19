using UnityEngine;

[CreateAssetMenu]
public class TankResources : ScriptableObject
{
    [SerializeField]
    public GameObject TanksNormalPrefab;

    [SerializeField]
    public GameObject TanksFastPrefab;

    [SerializeField]
    public GameObject TanksImpostorPrefab;

    [SerializeField]
    public GameObject TanksBadassPrefab;

    [SerializeField]
    public GameObject TankUIIcon;
}
