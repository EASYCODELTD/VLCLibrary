using System;
using System.Runtime.InteropServices;

namespace VLCLibrary
{



	public class VLCVideoBuffer  : VLCBase
	{
		public VLCVideoBuffer(uint width, uint height,uint bytes)
		{
			Width = width;
			Height = height;
			Stride = Width * bytes;
			Bytes = bytes;
			Lines = Height;
			FrameBuffer = new byte[Stride * Lines];

		}

		~VLCVideoBuffer ()
		{
			Dispose(false);

		}

		protected override void Dispose(bool disposing)
		{

			if (disposing) {
				//FrameBuffer = null;
				//if (m_GCHandle.IsAllocated) {
				//	m_GCHandle.Free();
				//	isLock = false;
				//}
			}

			Dispose(true);
			GC.SuppressFinalize(this); // No need to call finalizer now
		}

		private GCHandle m_GCHandle = default(GCHandle);

		internal IntPtr Lock()
		{
			
			isLock = true;
			return (m_GCHandle = GCHandle.Alloc(FrameBuffer, GCHandleType.Pinned)).AddrOfPinnedObject();
		}

	
		internal void Unlock()
		{


			
			m_GCHandle.Free();

			isLock = false;
		}

	
		public bool isLock;
		public uint Bytes;
		public uint Width;
		public uint Height;
		public uint Stride;
		public uint Lines;
		public byte[] FrameBuffer;
	}
}

