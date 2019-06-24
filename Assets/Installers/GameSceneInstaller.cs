using UnityEngine;
using Zenject;
using Presentation.View;
using Presentation.Presenter;
using Domain.UseCase;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private PlayerView playerPrefab;

    public override void InstallBindings()
    {
        Container
            .BindIFactory<IPlayerView>()
            .To<PlayerView>()
            .FromComponentInNewPrefab(playerPrefab);

        Container
            .Bind<IPlayerView>()
            .To<PlayerView>()
            .AsTransient();

        Container
            .Bind<IPlayerPresenter>()
            .To<PlayerPresenter>()
            .AsCached();

        Container
            .BindInterfacesTo<CreatePlayerUseCase>()
            .AsCached();
    }
}