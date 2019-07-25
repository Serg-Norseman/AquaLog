/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaLog.Core.Types;

namespace AquaLog.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Fish : Animal
    {


        public Fish()
        {
        }

        public override SpeciesType GetSpeciesType()
        {
            return SpeciesType.Fish;
        }
    }
}
