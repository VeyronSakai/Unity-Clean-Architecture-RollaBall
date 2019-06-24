using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;
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
            // Use the Assert class to test conditions

            var createPlayerUseCase = Container.Resolve<CreatePlayerUseCase>();

            Assert.IsNotNull(createPlayerUseCase);

            var playerObject = GameObject.Find(player);

            Assert.IsNotNull(playerObject);

            Assert.AreEqual(new Vector3(0, 1, 0), playerObject.transform.position);
        }
    }
}
