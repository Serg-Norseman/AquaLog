/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Collections.Generic;
using NUnit.Framework;

namespace AquaMate.Prognostics
{
    [TestFixture]
    public class LogicServiceTests
    {
        [Test]
        public void Test_Common()
        {
            var service = new LogicService();

            service.AddFact("human(socrates)");
            service.AddFact("droid(r2d2)");
            service.AddFact("mortal(X) :- human(X)");

            IList<LogicResult> queryResult = service.GetQuerySolutions("mortal(socrates)");
            Assert.AreEqual(1, queryResult.Count); // = "True" (Yes)

            queryResult = service.GetQuerySolutions("mortal(r2d2)");
            Assert.AreEqual(1, queryResult.Count); // = "False" (No)
            Assert.AreEqual(false, queryResult[0].Solved);
        }

        [Test]
        public void Test_AM()
        {
            var service = new LogicService();

            service.AddFact("fish(\"Poecilia reticulata\")");
            service.AddFact("fish(\"Xiphophorus hellerii\")");

            IList<LogicResult> queryResult = service.GetQuerySolutions("fish(X)");
            Assert.AreEqual(2, queryResult.Count);

            LogicResult solution = queryResult[0];
            Assert.AreEqual(1, solution.Variables.Count);
            var varSubst = solution.Variables[0];
            Assert.AreEqual("X", varSubst.Name);
            Assert.AreEqual("\"Poecilia reticulata\"", varSubst.TextValue);

            solution = queryResult[1];
            Assert.AreEqual(1, solution.Variables.Count);
            varSubst = solution.Variables[0];
            Assert.AreEqual("X", varSubst.Name);
            Assert.AreEqual("\"Xiphophorus hellerii\"", varSubst.TextValue);
        }

        [Test]
        public void Test_EnumerateVariables()
        {
            var service = new LogicService();

            var addFactResult = service.AddFact("dog(ripley)");
            AssertResponseOk(addFactResult);

            addFactResult = service.AddFact("dog(charlie)");
            AssertResponseOk(addFactResult);

            addFactResult = service.AddFact("mammal(X):-dog(X)");
            AssertResponseOk(addFactResult);

            IList<LogicResult> queryResult = service.GetQuerySolutions("mammal(X)");
            Assert.AreEqual(2, queryResult.Count);

            LogicResult solution = queryResult[0];
            Assert.AreEqual(1, solution.Variables.Count);
            Assert.AreEqual("X", solution.Variables[0].Name);
            Assert.AreEqual("ripley", solution.Variables[0].TextValue);

            solution = queryResult[1];
            Assert.AreEqual(1, solution.Variables.Count);
            Assert.AreEqual("X", solution.Variables[0].Name);
            Assert.AreEqual("charlie", solution.Variables[0].TextValue);
        }

        [Test]
        public void Test_MathTest1()
        {
            var service = new LogicService();

            var addFactResult = service.AddFact("match(input1,nn1,0.75)");
            AssertResponseOk(addFactResult);

            addFactResult = service.AddFact("match(input2,nn1,0.80)");
            AssertResponseOk(addFactResult);

            addFactResult = service.AddFact("match(input3,nn1,0.99)");
            AssertResponseOk(addFactResult);

            addFactResult = service.AddFact("match(input4,nn1,1)");
            AssertResponseOk(addFactResult);

            addFactResult = service.AddFact("match(input5,nn1,0.25)");
            AssertResponseOk(addFactResult);

            addFactResult = service.AddFact("match(input6,nn1,-0.25)");
            AssertResponseOk(addFactResult);

            addFactResult = service.AddFact("strongmatch(Result,NeuralNet):-(match(Result,NeuralNet,ActivationLevel),ActivationLevel > 0.5)");
            AssertResponseOk(addFactResult);

            var queryHasSolution = service.QueryHasSolution("strongmatch(input1,nn1)");
            Assert.IsTrue(queryHasSolution);

            queryHasSolution = service.QueryHasSolution("strongmatch(input5,nn1)");
            Assert.IsFalse(queryHasSolution);

            var queryResult = service.GetQuerySolutions("strongmatch(X,nn1)");
            Assert.AreEqual(5, queryResult.Count);

            Assert.AreEqual("input1", queryResult[0].Variables[0].TextValue);
            Assert.AreEqual("X", queryResult[0].Variables[0].Name);

            Assert.AreEqual("input2", queryResult[1].Variables[0].TextValue);
            Assert.AreEqual("X", queryResult[0].Variables[0].Name);

            Assert.AreEqual("input3", queryResult[2].Variables[0].TextValue);
            Assert.AreEqual("X", queryResult[0].Variables[0].Name);

            Assert.AreEqual("input4", queryResult[3].Variables[0].TextValue);
            Assert.AreEqual("X", queryResult[0].Variables[0].Name);

            Assert.AreEqual(false, queryResult[4].Solved);

            queryResult = service.GetQuerySolutions("match(input6,nn1,X)");
            Assert.AreEqual(1, queryResult.Count);
            Assert.AreEqual("-0.25", queryResult[0].Variables[0].TextValue);
            Assert.AreEqual("X", queryResult[0].Variables[0].Name);
        }

        [Test]
        public void Test_DoesNotBindVariable()
        {
            var service = new LogicService();

            service.AddFact("mammal(X):-dog(X)");

            var queryResult = service.GetQuerySolutions("mammal(X)");

            Assert.AreEqual(1, queryResult.Count);
            Assert.AreEqual(false, queryResult[0].Solved);
        }

        [Test]
        public void Test_NoSolution()
        {
            var service = new LogicService();

            service.AddFact("dog(ripley)");
            service.AddFact("cat(misterkitty)");
            service.AddFact("friendly(X):-dog(X)");

            var queryHasSolution = service.QueryHasSolution("friendly(misterkitty)");
            Assert.IsFalse(queryHasSolution);
        }

        private void AssertResponseOk(LogicResult result)
        {
            Assert.IsTrue(result.Solved);
            Assert.IsTrue(string.IsNullOrWhiteSpace(result.Message));
        }
    }
}
