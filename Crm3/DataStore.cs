using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm3
{

    public class DataStore : IObservable<int>
    {
        private int x;
        private List<IObserver<int>> observers;

        public DataStore(int x)
        {
            this.x = x;
            observers = new List<IObserver<int>>();
        }

        public int X
        {
            get => x;
            set
            {
                if (value != x)
                {
                    x = value;
                    NotifyObservers();
                }
            }
        }

        public IDisposable Subscribe(IObserver<int> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        private void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.OnNext(x);
            }
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<int>> observers;
            private IObserver<int> observer;

            public Unsubscriber(List<IObserver<int>> observers, IObserver<int> observer)
            {
                this.observers = observers;
                this.observer = observer;
            }

            public void Dispose()
            {
                if (observers.Contains(observer))
                    observers.Remove(observer);
            }
        }
    }
}