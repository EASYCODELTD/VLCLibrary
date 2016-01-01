using System;

namespace VLCLibrary
{


	public abstract class VLCBase : IDisposable
	{
		private bool m_isDisposed;

		public void Dispose()
		{
			if (!m_isDisposed)
			{
				Dispose(true);
				GC.SuppressFinalize(this);

				m_isDisposed = true;
			}
		}

		protected abstract void Dispose(bool disposing);

		~VLCBase()
		{
			if (!m_isDisposed)
			{
				Dispose(false);
				m_isDisposed = true;
			}
		}

		protected void VerifyObjectNotDisposed()
		{
			if (m_isDisposed)
			{
				throw new ObjectDisposedException(this.GetType().Name);
			}
		}
	}
}

