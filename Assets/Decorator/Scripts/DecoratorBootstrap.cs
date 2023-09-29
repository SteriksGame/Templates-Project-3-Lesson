using UnityEngine;

public class DecoratorBootstrap : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Awake()
    {
        Stat stat = new Stat(5, 5, 5);

        _player.Initialized(stat);
    }
}
