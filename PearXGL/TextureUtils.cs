using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;

namespace PearXGL
{
	public class TextureUtils
	{
		public static int LoadTexture(Bitmap bmp)
		{
			int id;

			GL.Enable(EnableCap.Texture2D);

			GL.GenTextures(1, out id);
			GL.BindTexture(TextureTarget.Texture2D, id);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);

			BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
				ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

			GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
				OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

			bmp.UnlockBits(data);

			return id;
		}

		public static void DrawImage(int id, Rectangle rect)
		{
			GL.Enable(EnableCap.Blend);
			GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);


			GL.MatrixMode(MatrixMode.Modelview);
			GL.LoadIdentity();
			GL.BindTexture(TextureTarget.Texture2D, id);

			GL.Begin(PrimitiveType.Quads);

			GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(rect.X, rect.Y + rect.Height);
			GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(rect.X + rect.Width, rect.Y + rect.Height);
			GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(rect.X + rect.Width, rect.Y);
			GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(rect.X, rect.Y);

			GL.End();
		}

		public static void DrawImage(Image img, Rectangle rect)
		{
			using (Bitmap bmp = new Bitmap(img))
			{
				int id = LoadTexture(bmp);
				DrawImage(id, rect);
				GL.DeleteTexture(id);
			}
		}
	}
}
