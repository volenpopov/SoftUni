
using NUnit.Framework;

namespace SkeletonTests
{
    public class DummyTests
    {


        [Test]
        public void DummyLosesHealthWhenAttacked()
        {
            int hp = 3;
            int exp = 1;
            int attackPoints = 1;

            Dummy dummy = new Dummy(hp, exp);
            dummy.TakeAttack(attackPoints);
            Assert.That(dummy.Health, Is.EqualTo(hp - 1),
                "Dummy loses health properly when attacked!");
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            int hp = 0;
            int exp = 1;
            int attackpoints = 1;
            Dummy dummy = new Dummy(hp, exp);

            Assert.That(() => dummy.TakeAttack(attackpoints),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DummyGivesXPWhenItDies()
        {
            int hp = 0;
            int exp = 1;
            Dummy dummy = new Dummy(hp, exp);

            Assert.That(dummy.GiveExperience(), Is.EqualTo(1));
        }

        [Test]
        public void DummyCantGiveXPIfAlive()
        {
            int hp = 3;
            int exp = 1;
            Dummy dummy = new Dummy(hp, exp);

            Assert.That(() => dummy.GiveExperience(),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Target is not dead."));
        }

    }
}
