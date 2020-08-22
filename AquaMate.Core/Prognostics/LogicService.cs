/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using Prolog;
using System.Collections.Generic;

namespace AquaMate.Prognostics
{
    public sealed class LogicService
    {
        private PrologEngine fEngine;

        public LogicService()
        {
            fEngine = new PrologEngine(false);
        }

        public LogicService(BasicIo io)
        {
            fEngine = new PrologEngine(io, false);
        }

        public LogicResult AddFact(string fact)
        {
            fact = fact.Trim();

            // Make sure fact doesn't end in period.
            if (fact.EndsWith(".")) {
                fact = fact.Substring(0, fact.Length - 1);
            }

            fEngine.Query = string.Format("assert({0}).", fact);

            foreach (var s in fEngine.SolutionIterator) {
                if (!s.Solved) {
                    return new LogicResult() {
                        Solved = false,
                        Message = s.ToString()
                    };
                }
            }

            return new LogicResult() {
                Solved = true,
                Message = null
            };
        }

        public IList<LogicResult> GetQuerySolutions(string query)
        {
            query = query.Trim();
            query = query.AddEndDot();
            fEngine.Query = query;

            var retVal = new List<LogicResult>();

            foreach (var solution in fEngine.SolutionIterator) {
                var returnedSolution = new LogicResult();
                returnedSolution.IsLast = solution.IsLast;
                returnedSolution.Solution = solution.ToString();
                returnedSolution.Solved = solution.Solved;

                returnedSolution.Variables = new List<Variable>();
                foreach (var variableBinding in solution.VarValuesIterator) {
                    returnedSolution.Variables.Add(new Variable() {
                        Name = variableBinding.Name,
                        TextValue = variableBinding.Value.ToString(),
                        DataType = variableBinding.DataType
                    });
                }

                retVal.Add(returnedSolution);
            }

            return retVal;
        }

        public bool QueryHasSolution(string query)
        {
            query = query.Trim();
            query = query.AddEndDot();
            fEngine.Query = query;

            foreach (var solution in fEngine.SolutionIterator) {
                return solution.Solved;
            }

            return false;
        }
    }
}
