using System;
using System.Runtime.InteropServices;

namespace VLCLibrary
{



	public class VLCVideoBuffer : VLCBase
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

		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				FrameBuffer = null;
			}

			if (m_GCHandle.IsAllocated) {
				m_GCHandle.Free();
				isLock = false;
			}
		}

		private GCHandle m_GCHandle = default(GCHandle);

		internal IntPtr Lock()
		{
			if (isLock)
				throw new Exception ("Object is lock");
			
			isLock = true;
			return (m_GCHandle = GCHandle.Alloc(FrameBuffer, GCHandleType.Pinned)).AddrOfPinnedObject();
		}

		internal Gdk.Pixbuf Pixbuf()
		{
			//8bits per color
			//if (isLock) return null;

				
			return new Gdk.Pixbuf (FrameBuffer, Gdk.Colorspace.Rgb, true, 8, (int)Width, (int)Height,(int) Stride);
		}

		internal void Unlock()
		{

			if (!isLock)
				throw new Exception ("Object is not lock");
			
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

