using DG.Tweening;
using System.Collections.Generic;

namespace ColorMixer.Storages
{
    public class SequncesStorage
    {
        public List<Sequence> _storage = new List<Sequence>();

        public void AddSequnce(Sequence sequence)
        {
            if (sequence != null)
                _storage.Add(sequence);
        }
        public int GetSequncesCount()
        {
            return _storage.Count;
        }
        public void RemoveSequnce(Sequence sequence)
        {
            if (sequence != null)
                _storage.Remove(sequence);
        }
        public List<Sequence> GetSequnces()
        {
            return _storage;
        }
    }
}
