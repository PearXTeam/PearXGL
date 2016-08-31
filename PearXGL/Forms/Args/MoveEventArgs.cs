using System.Drawing;
using System;

namespace PearXGL.Args
{
	public class MoveEventArgs : EventArgs
	{
		public int OldX { get; }
		public int OldY { get; }
		public int X { get; }
		public int Y { get; }

		public Point OldLocation
		{
			get
			{
				return new Point(OldX, OldY);
			}
		}
		public Point Location
		{
			get
			{
				return new Point(X, Y);
			}
		}
	}
}
