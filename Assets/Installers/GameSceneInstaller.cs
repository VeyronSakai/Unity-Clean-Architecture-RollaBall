using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private PlayerView playerPrefab;

    public override void InstallBindings()
    {
        Container
            .BindIFactory<IPlayerView>()
            .To<PlayerView>()
            .FromComponentInNewPrefab(playerPrefab);
    }
}