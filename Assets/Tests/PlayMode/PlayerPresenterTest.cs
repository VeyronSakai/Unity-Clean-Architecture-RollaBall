using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;
using Presentation.View;
using Presentation.Presenter;
using Domain.UseCase;

namespace Tests
{
    public class PlayerPresenterTest : ZenjectIntegrationTestFixture
    {
        [SetUp]
        public void SetUp()
        {

            PreInstall();

            GameObject playerPrefab = new GameObject();
            playerPrefab.AddComponent<PlayerView>();

            Container
                .BindIFactory<IPlayerView>()
                .To<PlayerView>()
                .FromComponentInNewPrefab(playerPrefab)
                .WithGameObjectName("Player");

            Container
                .Bind<IPlayerView>()
                .To<PlayerView>()
                .AsTransient();

            Container
                .Bind<IPlayerPresenter>()
                .To<PlayerPresenter>()
                .AsCached();

            PostInstall();
        }

        // A Test behaves as an ordinary method
        [UnityTest]
        public IEnumerator PlayerPresenterTestSimplePasses()
        {
            var playerPresenter = Container.Resolve<IPlayerPresenter>();
            Assert.IsNotNull(playerPresenter);

            yield return null;

            var playerView = playerPresenter.CreatePlayer();
            Assert.IsNotNull(playerView);
            Assert.AreEqual(new Vector3(0, 1, 0), playerPresenter.Tr.position);
            Assert.AreEqual(new Vector3(0, 1, 0), playerView.Tr.position);

            yield return null;

            playerPresenter.UpdatePlayerPosition(new Vector3(1, 1, 0));
            Assert.AreEqual(new Vector3(1, 1, 0), playerPresenter.Tr.position);
            Assert.AreEqual(new Vector3(1, 1, 0), playerView.Tr.position);

            yield return null;

            playerPresenter.UpdatePlayerPosition(new Vector3(2, 1, 2));
            Assert.AreEqual(new Vector3(2, 1, 2), playerPresenter.Tr.position);

            playerPresenter.DestroyPlayer();

            yield return null;

            var playerObject = GameObject.Find("Player");

            Assert.IsNull(playerObject);

            playerPresenter.CreatePlayer();

            playerObject = GameObject.Find("Player");

            Assert.IsNotNull(playerObject);
       }
    }
}
