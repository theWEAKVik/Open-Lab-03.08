using System;
using System.Collections;
using NUnit.Framework;

namespace Open_Lab_03._08
{
    [TestFixture]
    public class Tests
    {

        private Checker checker;

        private const int RandSeed = 308308308;
        private const int RandWordMinSize = 5;
        private const int RandWordMaxSize = 10;
        private const int RandPluralChance = 2;
        private const int RandTestCasesCount = 96;

        [OneTimeSetUp]
        public void Init() => checker = new Checker();

        [TestCase("changes", true)]
        [TestCase("change", false)]
        [TestCase("dudes", true)]
        [TestCase("magic", false)]
        [TestCaseSource(nameof(GetRandom))]
        public void IsPluralTest(string word, bool expected) =>
            Assert.That(checker.IsPlural(word), Is.EqualTo(expected));

        private static IEnumerable GetRandom()
        {
            var rand = new Random(RandSeed);

            for (var i = 0; i < RandTestCasesCount; i++)
            {
                var arr = new char[rand.Next(RandWordMinSize, RandWordMaxSize + 1)];
                var isPlural = rand.Next(RandPluralChance) == 0;

                for (var j = 0; j < arr.Length - 1; j++)
                    arr[j] = (char) rand.Next('a', 'z' + 1);

                if (!isPlural)
                    do
                        arr[^1] = (char) rand.Next('a', 'z' + 1);
                    while (arr[^1] == 's');
                else
                    arr[^1] = 's';

                yield return new TestCaseData(new string(arr), isPlural);
            }
        }

    }
}
