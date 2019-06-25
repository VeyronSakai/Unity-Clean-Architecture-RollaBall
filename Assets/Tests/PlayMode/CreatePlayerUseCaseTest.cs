using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;
using UniRx;
using Domain.UseCase;
using Presentation.View;
using Presentation.Presenter;

namespace Tests
{
    public class CreatePlayerUseCaseTest : ZenjectIntegrationTestFixture
    {
        private string player = "Player";

        [SetUp]
        public void SetUp()
        {
            PreInstall();

            Container
                .BindIFactory<IPlayerView>()
                .To<PlayerView>()
                .FromNewComponentOnNewGameObject()
                .WithGameObjectName(player);

            Container
                .Bind<IPlayerView>()
                .To<PlayerView>()
                .AsTransient();

            Container
                .Bind<IPlayerPresenter>()
                .To<PlayerPresenter>()
                .AsCached();

            Container
                .BindInterfacesAndSelfTo<CreatePlayerUseCase>()
                .AsCached();

            PostInstall();
        }

        // A Test behaves as an ordinary method
        [Test]
        public void CreatePlayerUseCaseSimplePasses()
        {
            var createPlayerUseCase = Container.Resolve<CreatePlayerUseCase>();

            Assert.IsNotNull(createPlayerUseCase);

            var playerObject = GameObject.Find(player);

            Assert.IsNotNull(playerObject);
        }

        [UnityTest]
        public IEnumerator ReInitializePlayerTest()
        {
            var createPlayerUseCase = Container.Resolve<CreatePlayerUseCase>();

            Assert.IsNotNull(createPlayerUseCase);

            yield return null;

            var playerObject = GameObject.Find(player);

            Assert.IsNotNull(playerObject);

            var playerView = playerObject.GetComponent<IPlayerView>();

            playerView.UpdatePosition(new Vector3(0,-3, 0));

            yield return null;

            playerView.UpdatePosition(new Vector3(0, -4, 0));

            yield return null;

            playerObject = GameObject.Find(player);
            playerView = playerObject.GetComponent<IPlayerView>();

            yield return null;

            Assert.IsNotNull(playerObject);

            Assert.AreEqual(new Vector3(0, 1, 0), playerObject.transform.position);
            Assert.AreEqual(new Vector3(0, 1, 0), playerView.PlayerPostion);
        }
    }
}
