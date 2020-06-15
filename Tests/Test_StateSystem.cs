using GameStructure;
using NUnit.Framework;

[TestFixture]
public class Test_StateSystem {
    [Test]
    public void TestAddedStateExists() {
        StateSystem stateSystem = new StateSystem();
        stateSystem.AddState("splash", new SplashScreenState(stateSystem));

        // Does the added function now exist?
        Assert.IsTrue(stateSystem.Exists("splash"));
    }
}