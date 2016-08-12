using System.Drawing;
using System.Drawing.Imaging;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace PearXGL
{
	public static class GLUtils
	{
		public static void DrawRectangle(float x, float y, float width, float height, Color? c = null)
		{
			DrawRectangle(new RectangleF(x, y, width, height), c);
		}

		public static void DrawRectangle(RectangleF rect, Color? c = null)
		{
			if (c != null)
				GL.Color3(c.Value);

			GL.Begin(PrimitiveType.Quads);
			GL.Vertex2(rect.X, rect.Y);
			GL.Vertex2(rect.X + rect.Width, rect.Y);
			GL.Vertex2(rect.X + rect.Width, rect.Y + rect.Height);
			GL.Vertex2(rect.X, rect.Y + rect.Height);
			GL.End();
		}

		public static MouseCursor GetCursor(Image img)
		{
			using (Bitmap bmp = new Bitmap(img))
			{
				return GetCursor(bmp, 0, 0, img.Width, img.Height);
			}
		}

		public static MouseCursor GetCursor(Bitmap bmp, int hitX, int hitY, int width, int height)
		{
			MouseCursor c;
			var v = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			c = new MouseCursor(hitX, hitY, width, height, v.Scan0);
			bmp.UnlockBits(v);
			return c;
		}

		public static void PrepareOrtho(int x, int y, int width, int height)
		{
			GL.Viewport(x, y, width, height);

			GL.MatrixMode(MatrixMode.Projection);
			GL.LoadIdentity();
			GL.Ortho(x, width, height, y, 0f, 1f);
			GL.MatrixMode(MatrixMode.Modelview);
		}
	}
}