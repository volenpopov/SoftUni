using NUnit.Framework;

namespace SkeletonTests
{
    public class AxeTests
    {
        private const int TargetHealth = 5;
        private const int TargetExperience = 5;
        private const int WeapongDamage = 1;
        private const int WeaponDurability = 2;

        private IWeapon axe;
        private ITarget dummy;

        [SetUp]
        public void Init()
        {
            this.axe = new Axe(WeapongDamage, WeaponDurability);
            this.dummy = new Dummy(TargetHealth, TargetExperience);
        }

        [Test]
        public void WeaponLosesDurabilityAfterAttack()
        {
            this.axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(WeaponDurability - 1)
                , "Axe durability doesnt change after attack!");
        }

        [Test]
        public void BrokenWeaponCantAttack()
        {
            this.axe.Attack(dummy);
            this.axe.Attack(dummy);

            Assert.That(() => this.axe.Attack(dummy),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Axe is broken."));
        }
    }
}
