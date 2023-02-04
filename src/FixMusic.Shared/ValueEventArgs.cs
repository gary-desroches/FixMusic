using System;

namespace FixMusic
{
    public class ValueEventArgs<T>
    {
        public ValueEventArgs(T value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            _value = value;
        }

        private readonly T _value;
        public T Value => _value;
    }
}
