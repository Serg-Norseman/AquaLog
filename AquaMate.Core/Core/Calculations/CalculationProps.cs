/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

namespace AquaMate.Core.Calculations
{
    public class CalcParam
    {
        public readonly string PropName;
        public readonly string DispName;

        public CalcParam(string propName, string dispName)
        {
            PropName = propName;
            DispName = dispName;
        }
    }


    public delegate double CalcHandler(double arg);


    public class CalculationProps
    {
        public readonly string Name;
        public readonly string Description;
        public readonly CalcParam[] Args;
        public readonly CalcParam Result;
        public readonly CalcHandler Handler;

        public CalculationProps(string name, string description, CalcParam[] args, CalcParam result, CalcHandler calcHandler)
        {
            Name = name;
            Description = description;
            Args = args;
            Result = result;
            Handler = calcHandler;
        }
    }
}
