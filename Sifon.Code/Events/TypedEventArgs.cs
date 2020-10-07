using System;

namespace Sifon.Code.Events
{
    public class EventArgs<T> : EventArgs
    {
        private readonly T _value;

        public EventArgs(T value)
        {
            _value = value;
        }

        public T Value
        {
            get { return _value; }
        }
    }
    public class EventArgs<T, U> : EventArgs
    {
        private readonly T _value1;
        private readonly U _value2;

        public EventArgs(T value1, U value2)
        {
            _value1 = value1;
            _value2 = value2;
        }

        public T Value1 => _value1;
        public U Value2 => _value2;
    }
}
