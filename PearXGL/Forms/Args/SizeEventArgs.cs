using System;
using System.Drawing;

namespace PearXGL.Args
{
	public class SizeEventArgs : EventArgs
	{
		public int OldWidth { get; }
		public int OldHeight { get; }
		public int Width { get; }
		public int Height { get; }

		public Size OldSize
		{
			get
			{
				return new Size(OldWidth, OldHeight);
			}
		}
		public Size Size
		{
			get
			{
				return new Size(Width, Height);
			}
		}
	}
}
