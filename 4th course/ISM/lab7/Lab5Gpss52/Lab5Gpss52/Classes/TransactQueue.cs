using System.Collections.Generic;
using System.Linq;

namespace Lab5Gpss52.Classes
{
    public class TransactQueue
    {
        private List<Transact> _transacts;

        public TransactQueue(List<Transact> transacts)
        {
            _transacts = transacts;
        }

        public void AddTransact(Transact transact)
        {
            _transacts.Add(transact);
        }

        public Transact GetNextForProccess()
        {
            return _transacts.OrderBy(t=>t.Time).First();
        }

        public void DeleteTransact(Transact transact)
        {
            _transacts.Remove(transact);
        }
    }
}