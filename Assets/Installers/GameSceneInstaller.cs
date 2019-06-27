using UnityEngine;
using Zenject;
using Presentation.View;
using Presentation.Presenter;
using Domain.UseCase;
using Domain.Entity;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private PlayerView playerPrefab;
    [SerializeField] private BlockView blockPrefab;

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

        Container
            .Bind<IInputView>()
            .To<InputView>()
            .AsCached();

        Container
            .Bind<IInputPresenter>()
            .To<InputPresenter>()
            .AsCached();

        Container
            .BindInterfacesTo<MovePlayerUseCase>()
            .AsCached();

        Container
            .Bind<IBlockView>()
            .To<BlockView>()
            .AsCached();

        Container
            .Bind<IBlockPresenter>()
            .To<BlockPresenter>()
            .AsCached();

        Container
            .BindIFactory<Vector3, IBlockView>()
            .To<BlockView>()
            .FromComponentInNewPrefab(blockPrefab);

        Container
            .Bind<IScoreEntity>()
            .To<ScoreEntity>()
            .AsCached();

        // UseCaseをBindする順序(UseCaseを生成する順序)に注意
        // InitializeBlockUseCaseのInitializeが行われてから、GetScoreUseCaseのInitializeが行われなければいけない
        Container
            .BindInterfacesTo<InitializeBlockUseCase>()
            .AsCached();

        Container
            .BindInterfacesTo<GetScoreUseCase>()
            .AsCached();
    }
}
