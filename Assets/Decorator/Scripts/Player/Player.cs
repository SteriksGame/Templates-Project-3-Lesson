using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerConfig _config;

    private RaceTypes _race => _config.Race;
    private SpecificationTypes _specification => _config.Specification;
    private PassiveAbilitiesTypes _passiveAbilities => _config.PassiveAbilities;


    private IStatProvider _statProvider;

    public void Initialized(Stat stat)
    {
        _statProvider = new RaceProvider(stat, _race);
        _statProvider = new SpecificationProvider(_statProvider, _specification);
        _statProvider = new PassiveAbilitesProvider(_statProvider, _passiveAbilities);

        _statProvider.StatCalculation();

        ViewStat();
    }

    private void ViewStat()
    {
        Debug.Log("Интеллект: " + _statProvider.Stat.Intellect);
        Debug.Log("Сила: " + _statProvider.Stat.Power);
        Debug.Log("Ловкость: " + _statProvider.Stat.Agility);
    }
}