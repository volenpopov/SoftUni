using Moq;
using NUnit.Framework;
using Skeleton;

namespace SkeletonTests
{
    public class HeroTests
    {
        private const string HeroName = "Marko";
        
        [Test]
        public void HeroGainsXPIfTargetDies()
        {
            IWeapon fakeWeapon = new FakeWeapon();
            ITarget fakeTarget = new FakeTarget();

            Hero hero = new Hero(HeroName, fakeWeapon);

            hero.Attack(fakeTarget);

            Assert.That(hero.Experience, Is.EqualTo(1));
        }

        //using Moq
        [Test]
        public void HeroGainsXPWhenTargetDies()
        {
            Mock<ITarget> fakeTarget = new Mock<ITarget>();            
            fakeTarget.Setup(t => t.Health).Returns(0);
            fakeTarget.Setup(t => t.GiveExperience()).Returns(1);
            fakeTarget.Setup(t => t.IsDead()).Returns(true);

            Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();

            Hero hero = new Hero(HeroName, fakeWeapon.Object);
            hero.Attack(fakeTarget.Object);

            Assert.That(hero.Experience, Is.EqualTo(1));
        }
    }
}
