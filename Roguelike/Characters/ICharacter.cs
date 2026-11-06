using Roguelike.Core;

namespace Roguelike.Characters
{
    public interface ICharacter
    {
        int GetStat(StatType statType);
    }
}