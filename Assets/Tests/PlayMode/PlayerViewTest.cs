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
        GameObject playerPrefab;
        IPlayerView playerView;
        IPlayerView playerViewInstance;
        IFactory<IPlayerView> playerPrefabFactory;


        [SetUp]
        public void SetUp(){

            PreInstall();

            playerPrefab = new GameObject();
            playerPrefab.AddComponent<PlayerView>();

            Container
                .BindIFactory<IPlayerView>()
                .To<PlayerView>()
                .FromComponentInNewPrefab(playerPrefab);

            Container
                .Bind<IPlayerView>()
                .To<PlayerView>()
                .AsTransient();

            PostInstall();

            playerPrefabFactory = Container.Resolve<IFactory<IPlayerView>>();
        }

        [Test]
        public void InitializeTest(){

            Assert.IsNotNull(playerPrefabFactory);
            Assert.IsNull(playerViewInstance);
            playerViewInstance = playerPrefabFactory.Create();
            Assert.IsNotNull(playerViewInstance);

            Assert.AreEqual(new Vector3(0,1,0),playerViewInstance.Tr.position);
        }

        // A Test behaves as an ordinary method
        [Test]
        public void UpdatePositionTest()
        {
            // Use the Assert class to test conditions
            playerViewInstance = playerPrefabFactory.Create();
            playerViewInstance.UpdatePosition(new Vector3(1,1,0));
            Assert.AreEqual(1,playerViewInstance.Tr.position.x);
            playerViewInstance.UpdatePosition(new Vector3(2,1,2));
            Assert.AreEqual(new Vector3(2,1,2),playerViewInstance.Tr.position);
        }
    }
}
