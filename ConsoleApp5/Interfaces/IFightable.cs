﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    interface IFightable
    {
        int health { get; set; }
        int maxHealth { get; set; }
        int baseAttack { get; set; }
        int baseDefence { get; set; }
        void ChangeHealth(int value);
        void DealDamage(int value, IFightable opponent);
    }
}