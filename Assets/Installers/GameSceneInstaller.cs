using UnityEngine;
using Zenject;
using Presentation.View;
using Presentation.Presenter;

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