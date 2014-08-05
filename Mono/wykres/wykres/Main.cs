using System;
using Gtk;
using Medsphere.Widgets;

namespace wykres
{
	class MainClass
	{
		
		
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			Moja moj = new Moja();
			moj.Dupa (win);
			win.ShowAll ();
			Application.Run ();
		}
		
		
		
		
	}
}
