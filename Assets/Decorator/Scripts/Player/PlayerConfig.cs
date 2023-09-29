using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Decorator/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] private RaceTypes _race;
    [SerializeField] private SpecificationTypes _specification;
    [SerializeField] private PassiveAbilitiesTypes _passiveAbilities;

    public RaceTypes Race => _race;
    public SpecificationTypes Specification => _specification;
    public PassiveAbilitiesTypes PassiveAbilities => _passiveAbilities;
}