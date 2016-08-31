using System;
using System.Drawing;
using OpenTK;
using OpenTK.Input;
using PearXGL.Args;

namespace PearXGL
{
	public interface IWidget
	{
		WidgetCollection Widgets { get; set; }

		Size ClientSize { get; set; }
		Size Size { get; set; }
		int Width { get; set; }
		int Height { get; set; }
		Point Location { get; set; }
		int X { get; set; }
		int Y { get; set; }
		bool Visible { get; set; }
	    bool Enabled { get; set; }
		MouseCursor Cursor { get; set; }
		MouseDevice Mouse { get; }
		KeyboardDevice Keyboard { get; }

		bool FucusOnClick { get; set; }
		bool IsFocused { get; set; }
		void Focus();


		//Events \/

		void OnMouseMove(object sender, MouseMoveEventArgs e);
		event EventHandler<MouseMoveEventArgs> MouseMove;

		void OnMouseLeave(object sender, EventArgs e);
		event EventHandler MouseLeave;

		void OnMouseEnter(object sender, EventArgs e);
		event EventHandler MouseEnter;

		void OnMouseDown(object sender, MouseButtonEventArgs e);
		event EventHandler<MouseButtonEventArgs> MouseDown;

		void OnMouseUp(object sender, MouseButtonEventArgs e);
		event EventHandler<MouseButtonEventArgs> MouseUp;

		void OnResize(object sender, SizeEventArgs e);
		event EventHandler<SizeEventArgs> Resize;

		void OnFocused(object sender, EventArgs e);
		event EventHandler Focused;

		void OnMove(object sender, MoveEventArgs e);
		event EventHandler<MoveEventArgs> Move;

		void OnKeyPress(object sender, KeyPressEventArgs e);
		event EventHandler<KeyPressEventArgs> KeyPress;

		void OnPrePaint(object sender, PaintEventArgs e);
		event EventHandler<PaintEventArgs> PrePaint;
		void OnPaint(object sender, PaintEventArgs e);
		event EventHandler<PaintEventArgs> Paint;
		void OnPostPaint(object sender, PaintEventArgs e);
		event EventHandler<PaintEventArgs> PostPaint;
	}
}
