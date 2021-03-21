using System.Collections.Generic;
using Lab5Gpss52.Randoms;

namespace Lab5Gpss52.Classes
{
    public class TransactGenerator
    {
        private readonly UniformRandom _rand;

        public double Time { get; set; }

        public double LowerBound
        {
            get { return _rand.LowerBound; }
            set { _rand.LowerBound = value; }
        }

        public double UpperBound
        {
            get { return _rand.UpperBound; }
            set { _rand.UpperBound = value; }
        }

        public TransactGenerator(double lowerBound, double upperBound)
        {
            Time = 0;
            _rand = new UniformRandom(lowerBound,upperBound);
        }

        public Transact Generate()
        {
            Time += _rand.Next();
            return new Transact { Time = Time, Status = TransactStatus.Prepared};
        }

        public List<Transact> Generate(int count)
        {
            var transacts = new List<Transact>(count);
            for(var i = 0; i < count;i++)
            {
                transacts.Add(Generate());
            }
            return transacts;
        }
    }
}