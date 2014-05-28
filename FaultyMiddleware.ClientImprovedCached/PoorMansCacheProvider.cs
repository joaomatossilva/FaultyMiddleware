using System.Collections;

namespace FaultyMiddleware.Client
{
    public interface ICacheProvider
    {
        bool TryGet(object key, out object value);
        void Set(object key, object value);
    }

    public class PoorMansCacheProvider : ICacheProvider
    {
        private readonly Hashtable _hash;

        public PoorMansCacheProvider()
        {
            _hash = new Hashtable();
        }

        public bool TryGet(object key, out object value)
        {
            if (_hash.ContainsKey(key))
            {
                value = _hash[key];
                return true;
            }
            value = null;
            return false;
        }

        public void Set(object key, object value)
        {
            _hash[key] = value;
        }
    }
}
