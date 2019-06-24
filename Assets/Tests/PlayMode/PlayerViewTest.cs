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

            Assert.AreEqual(new Vector3(0,1,0),playerViewInstance.Tr.position);
        }

        // A Test behaves as an ordinary method
        [Test]
        public void UpdatePositionTest()
        {
            var playerPrefabFactory = Container.Resolve<IFactory<IPlayerView>>();
            var playerViewInstance = playerPrefabFactory.Create();
            playerViewInstance.UpdatePosition(new Vector3(1,1,0));
            Assert.AreEqual(1,playerViewInstance.Tr.position.x);
            playerViewInstance.UpdatePosition(new Vector3(2,1,2));
            Assert.AreEqual(new Vector3(2,1,2),playerViewInstance.Tr.position);
        }

        [UnityTest]
        public IEnumerator DestroyPlayerTest()
        {
            var playerPrefabFactory = Container.Resolve<IFactory<IPlayerView>>();
            var playerViewInstance = (PlayerView)playerPrefabFactory.Create();
            Assert.IsNotNull(playerViewInstance);

            yield return null;

            playerViewInstance.DestroyPlayer();

            yield return null;

            var playerObject = GameObject.Find("Player");
            Assert.IsNull(playerObject);
        }
    }
}
