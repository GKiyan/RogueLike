using Roguelike.Core;

namespace Roguelike.Effects
{
    public class AtkBuffEffect : Effect
    {
        public int Percentage;

        public AtkBuffEffect(EffectType type, int duration, int percentage) : base(type, duration)
        {
            Percentage = percentage;
        }

        public override void OnExpire(ITargetable target)
        {
            target.ActiveEffects.Remove(this);
            target.Atk *= (1 - Percentage / 100);
        }
        
        public override void OnApply(ITargetable target)
        {
            target.Atk *= (1 + Percentage / 100);
        }
        
        public override void OnTick(ITargetable target)
        {
            Duration -= 1;
            if (Duration <= 0)
            {
                OnExpire(target);
            }
        }
    }
    
}

