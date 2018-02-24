using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharlesProjects
{
    namespace Interfaces
    {
        namespace Inventory
        {
            public interface IInventoryable
            {
                void add();
                void remove();
                void equip();
            }
        }

        namespace Weapons
        {
            public interface IWeapon
            {
                void attack();
            }
        }

        namespace Spells
        {
            public interface ISpell
            {
                void cast();
            }
        }
    }
}
