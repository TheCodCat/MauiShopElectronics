namespace MauiShopElectronics.Reactive
{
    public class ReactiveProperty<T>
    {
        public event Action<T,T> OnChanged;
        public T _value;
        public readonly IEqualityComparer<T> _comparer;
        public T Value 
        {
            get => _value;
            set
            {
                var oldValue = _value;
                _value = value;

                if(!_comparer.Equals(oldValue, _value))
                    OnChanged?.Invoke(oldValue, _value);
            }
        }
        public ReactiveProperty() : this (default(T), EqualityComparer<T>.Default)
        {

        }
        public ReactiveProperty(T value) : this (value, EqualityComparer<T>.Default)
        {

        }
        public ReactiveProperty(T value, IEqualityComparer<T> comparer)
        {
            _value = value;
            _comparer = comparer;
        }
    }
}
