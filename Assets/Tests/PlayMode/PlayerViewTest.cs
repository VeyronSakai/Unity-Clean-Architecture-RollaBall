using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

namespace Tests
{
    public class PlayerViewTest : ZenjectIntegrationTestFixture
    {
        GameObject playerObject;
        PlayerView playerView;
        Vector3 pos;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            playerObject = new GameObject();
            playerObject.transform.position = new Vector3(0, 1, 0);
            playerObject.AddComponent<PlayerView>();
            playerView = playerObject.GetComponent<PlayerView>();
        }

        // A Test behaves as an ordinary method
        [Test]
        public void UpdatePositionTest()
        {
            // Use the Assert class to test conditions
            Assert.AreEqual(new Vector3(0, 1, 0), playerObject.transform.position);

            pos = new Vector3(1, 1, 1);
            playerView.UpdatePosition(pos);
            Assert.AreEqual(pos, playerObject.transform.position);

            pos = new Vector3(2, 1, 1);
            playerView.UpdatePosition(pos);
            Assert.AreEqual(2, playerObject.transform.position.x);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator PlayerViewTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
