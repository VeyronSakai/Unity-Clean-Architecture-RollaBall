using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;
using Presentation.Presenter;
using Presentation.View;
using Domain.UseCase;

namespace Tests
{
    public class PlayerPresenterTest : ZenjectUnitTestFixture
    {

        [SetUp]
        public void SetUp()
        {
            Container
                .Bind<IPlayerPresenter>()
                .To<PlayerPresenter>()
                .AsCached();

            Container
               .BindIFactory<IPlayerView>()
               .To<PlayerView>()
               .FromNewComponentOnNewGameObject();

            Container
                .Bind<IPlayerView>()
                .To<PlayerView>()
                .AsTransient();   
        }

        // A Test behaves as an ordinary method
        [Test]
        public void PlayerPresenterTestSimplePasses()
        {
            var playerPresenter = Container.Resolve<IPlayerPresenter>();
            Assert.IsNotNull(playerPresenter);

            var playerView = playerPresenter.CreatePlayer();
            Assert.IsNotNull(playerView);
            Assert.AreEqual(new Vector3(0, 1, 0), playerPresenter.Tr.position);
            Assert.AreEqual(new Vector3(0, 1, 0), playerView.Tr.position);

            playerPresenter.UpdatePlayerPosition(new Vector3(1, 1, 0));
            Assert.AreEqual(new Vector3(1, 1, 0), playerPresenter.Tr.position);
            Assert.AreEqual(new Vector3(1, 1, 0), playerView.Tr.position);

            playerPresenter.UpdatePlayerPosition(new Vector3(2, 1, 2));
            Assert.AreEqual(new Vector3(2, 1, 2), playerPresenter.Tr.position);
        }
    }
}
