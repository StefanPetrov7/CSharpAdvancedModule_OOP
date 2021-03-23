using System.Collections.Generic;
using System.Linq;
using HAD.Contracts;

namespace HAD.Entities.Items
{
    public class Recipe : BaseItem, IRecipe
    {
        private readonly ICollection<string> reuieredItems;

        public Recipe(string name,
            long strengthBonus,
            long agilityBonus,
            long intelligenceBonus,
            long hitPointsBonus,
            long damageBonus, params string[] items)
           : base(name,
             strengthBonus,
             agilityBonus,
             intelligenceBonus,
             hitPointsBonus,
             damageBonus)
        {
            this.reuieredItems = items;
        }

        public IReadOnlyList<string> RequiredItems => this.reuieredItems.ToList().AsReadOnly();
    }
}
