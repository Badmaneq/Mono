using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnTogglebutton1Clicked (object sender, System.EventArgs e)
	{
		Console.WriteLine ("Przycisk\n");
		//throw new System.NotImplementedException ();
	}
}
