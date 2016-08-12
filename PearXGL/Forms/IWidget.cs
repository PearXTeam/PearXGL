using System;
using System.Drawing;
using OpenTK.Input;
using PearXGL.Args;

namespace PearXGL
{
	public interface IWidget
	{
		WidgetCollection Widgets { get; set; }
		Size Size { get; set; }
		Point Location { get; set; }
		bool Visible { get; set; }
	    bool Enabled { get; set; }
		MouseDevice Mouse { get; }
		KeyboardDevice Keyboard { get; }

		bool FucusOnClick { get; set; }
		bool IsFocused { get; set; }
		void Focus();

		//Events \/
		void OnPaint(object sender, PaintArgs e);
		event PaintEventHandler Paint;

		void OnMouseMove(object sender, MouseArgs e);
		event MouseEventHandler MouseMove;

		void OnMouseLeave(object sender, MouseArgs e);
		event MouseEventHandler MouseLeave;

		void OnMouseEnter(object sender, MouseArgs e);
		event MouseEventHandler MouseEnter;

		void OnMouseDown(object sender, MouseButtonArgs e);
		event MouseButtonEventHandler MouseDown;

		void OnMouseUp(object sender, MouseButtonArgs e);
		event MouseButtonEventHandler MouseUp;

		void OnResize(object sender, SizeArgs e);
		event SizeEventHandler Resize;

		void OnFocused(object sender, EventArgs e);
		event EventHandler Focused;
	}
}
