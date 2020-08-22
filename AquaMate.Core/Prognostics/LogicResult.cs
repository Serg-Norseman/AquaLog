/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Collections.Generic;

namespace AquaMate.Prognostics
{
    public class Variable
    {
        public string Name { get; set; }
        public string TextValue { get; set; }
        public string DataType { get; set; }
    }


    public class LogicResult
    {
        public bool Solved { get; set; }

        public string Message { get; set; }

        public IList<Variable> Variables { get; set; }

        public bool IsLast { get; set; }

        public string Solution { get; set; }
    }
}
