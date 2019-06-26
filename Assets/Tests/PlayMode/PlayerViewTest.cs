using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;
using Presentation.View;
using Presentation.Presenter;

namespace Tests
{
    public class PlayerViewTest : ZenjectIntegrationTestFixture
    {
        [SetUp]
        public void SetUp(){

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

            PostInstall();
        }

        [Test]
        public void InitializeTest(){
            var playerPrefabFactory = Container.Resolve<IFactory<IPlayerView>>();
            Assert.IsNotNull(playerPrefabFactory);
            var playerViewInstance = playerPrefabFactory.Create();
            Assert.IsNotNull(playerViewInstance);

            Assert.AreEqual(new Vector3(0,1,0), playerViewInstance.PlayerPostion);
        }

        // A Test behaves as an ordinary method
        [UnityTest]
        public IEnumerator UpdatePositionTest()
        {
            var playerPrefabFactory = Container.Resolve<IFactory<IPlayerView>>();
            var playerViewInstance = playerPrefabFactory.Create();
            playerViewInstance.ReInitializePlayer(new Vector3(1,1,0));
            yield return null;

            Assert.AreEqual(1,playerViewInstance.PlayerPostion.x);
            playerViewInstance.ReInitializePlayer(new Vector3(2,1,2));

            yield return null;
            Assert.AreEqual(new Vector3(2,1,2),playerViewInstance.PlayerPostion);
        }
    }
}
