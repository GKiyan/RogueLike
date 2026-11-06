using Roguelike.Core;
using Roguelike.Characters;

namespace Roguelike.Skills
{
    public abstract class ComboSkill : Skill
    {
        public int Id;
        
        protected ComboSkill(string name, int spCost, TargetType targetType, CharacterType casterType, ICharacter caster, List<ITargetable> targets) 
            : base(name, spCost, targetType, casterType, caster, targets)
        {
        }
    }
}