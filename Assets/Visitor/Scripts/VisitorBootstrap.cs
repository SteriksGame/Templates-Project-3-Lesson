using UnityEngine;

public class VisitorBootstrap : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private Score _score;

    private PlayerInput _input;

    private void Awake()
    {
        _score = new Score(_spawner);

        _input = new PlayerInput();
        _input.OnPressedSpace += _spawner.KillRandomEnemy;

        _spawner.StartWork();
    }

    private void Update() => _input.Update();
}
