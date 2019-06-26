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
        private string Player = "PlayerPresenter";

        [SetUp]
        public void SetUp()
        {
            
        }

        // A Test behaves as an ordinary method
        [UnityTest]
        public IEnumerator PlayerPresenterTestSimplePasses()
        {
            PreInstall();

            GameObject playerPrefab = new GameObject();
            playerPrefab.AddComponent<PlayerView>();

            Container
                .BindIFactory<IPlayerView>()
                .To<PlayerView>()
                .FromComponentInNewPrefab(playerPrefab)
                .WithGameObjectName(Player);

            Container
                .Bind<IPlayerView>()
                .To<PlayerView>()
                .AsTransient();

            Container
                .Bind<IPlayerPresenter>()
                .To<PlayerPresenter>()
                .AsCached();

            PostInstall();

            yield return null;

            var playerPresenter = Container.Resolve<IPlayerPresenter>();
            Assert.IsNotNull(playerPresenter);

            yield return null;

            var playerView = playerPresenter.CreatePlayer();
            Assert.IsNotNull(playerView);
            Assert.AreEqual(new Vector3(0.0f, 1.0f, 0.0f), playerPresenter.PlayerPosition);
            Assert.AreEqual(new Vector3(0.0f, 1.0f, 0.0f), playerView.PlayerPostion);

            yield return null;

            playerPresenter.ReInitializePlayer(new Vector3(1.0f, 1.0f, 0.0f));

            yield return null;

            Assert.AreEqual(new Vector3(1.0f, 1.0f, 0.0f), playerPresenter.PlayerPosition);
            Assert.AreEqual(new Vector3(1.0f, 1.0f, 0.0f), playerView.PlayerPostion);

            yield return null;

            playerPresenter.ReInitializePlayer(new Vector3(2.0f, 1.0f, 2.0f));

            yield return null;

            Assert.AreEqual(new Vector3(2.0f, 1.0f, 2.0f), playerPresenter.PlayerPosition);

            yield return null;

            var playerObject = GameObject.Find(Player);

            Assert.IsNotNull(playerObject);
        }

        [UnityTest]
        public IEnumerator MoveTest()
        {
            PreInstall();

            GameObject playerPrefab = new GameObject();
            playerPrefab.AddComponent<PlayerView>();
            playerPrefab.AddComponent<Rigidbody>();

            Container
                .BindIFactory<IPlayerView>()
                .To<PlayerView>()
                .FromComponentInNewPrefab(playerPrefab)
                .WithGameObjectName(Player);

            Container
                .Bind<IPlayerView>()
                .To<PlayerView>()
                .AsTransient();

            Container
                .Bind<IPlayerPresenter>()
                .To<PlayerPresenter>()
                .AsCached();

            PostInstall();

            var playerPresenter = Container.Resolve<IPlayerPresenter>();
            var playerView = playerPresenter.CreatePlayer();
            var playerObject = GameObject.Find(Player);

            yield return null;

            playerView.Move(new Vector3(10, 0, 0));

            yield return new WaitForSeconds(1.0f);

            Assert.AreNotEqual(1, playerObject.transform.position.x);
        }
    }
}
