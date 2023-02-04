using System;

namespace FixMusic
{
    public class ActionOnDispose : IDisposable
    {
        public ActionOnDispose(Action action)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            _action = action;
        }

        private readonly Action _action;

        #region Dispose Pattern

        protected virtual void Dispose(bool isExplicit)
        {
            if (_isDisposed)
            {
                return;
            }

            if (isExplicit)
            {
                _action();
            }

            _isDisposed = true;
        }

        public void Dispose() => Dispose(isExplicit: true);

        private bool _isDisposed;

        #endregion
    }
}
