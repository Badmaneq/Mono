using System;
using Gtk;
using Medsphere.Widgets;

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
}

public partial class Moja 
{
	
	public void Dupa (Window okno)
	{
		VBox vbox = new VBox (false, 0);
		okno.Add (vbox);
		graph = CreateRandomGraph ();

		vbox.PackStart (graph, true, true, 0);
	}
	
	private Graph graph;
	
	private	PlotColor[] plotColors = new PlotColor[] {
			PlotColor.Red,
			PlotColor.Blue,
			PlotColor.Green,
			PlotColor.Orange,
			PlotColor.Purple,
			PlotColor.Brown,
			PlotColor.DarkRed,
			PlotColor.DarkBlue,
			PlotColor.DarkGreen,
			PlotColor.DarkOrange,
			PlotColor.DarkPurple,
			PlotColor.DarkYellow,
			PlotColor.DarkBrown
		};
		
		private PointShape[] pointShapes = new PointShape[] {
			PointShape.Circle,
			PointShape.Square,
			PointShape.Diamond,
			PointShape.Triangle
		};
		
		private Graph CreateRandomGraph ()
		{
			Graph newGraph = new Graph2D ();
			newGraph.AppendAxis (new DateTimeAxis (0, AxisLocation.Bottom));
			newGraph.AppendAxis (new LinearAxis (1, AxisLocation.Left));
				
			AddRandomLinePlot (newGraph);
			
			return newGraph;
		}
		
		private void AddRandomLinePlot (Graph graph)
		{
			Random random = new Random ();
		
			LinePlot plot = new LinePlot (
				CreateRandomModel (), 
				GetRandomPlotColor (), 
				GetRandomPointShape ());

			plot.Name = "LinePlot";
			plot.ShowValues = Convert.ToBoolean (random.Next (2));

			plot.SetValueDataColumn (0, 0);
			plot.SetValueDataColumn (1, 1);

			graph.AddPlot (plot, graph.Axes);		
		}
		
		private TreeStore CreateRandomModel ()
		{
			TreeStore store = new TreeStore (typeof (DateTime), typeof (double));
			
			double[] numbers = CreateSomeNumbers ();
			DateTime[] dateTimes = CreateDateTimeSequence (numbers.Length);
			
			for (int i = 0; i < numbers.Length; i++) {
				store.AppendValues (dateTimes[i], numbers[i]);
			}
			
			return store;
		}
		
		private PlotColor GetRandomPlotColor ()
		{
			Random random = new Random ();
			int i = random.Next (plotColors.Length);
			return plotColors[i];
		}
		
		private PointShape GetRandomPointShape ()
		{
			Random random = new Random ();
			int i = random.Next (pointShapes.Length);
			return pointShapes[i];
		}
		
		private double[] CreateSomeNumbers ()
		{
			Random random = new Random ();
		
			double[] numbers = new double[30];
			double k = 0.5 + 0.1 * random.Next (4);
			double x;
		
			for (int i = 0; i < numbers.Length; i++) {
				x = 0.5 + 0.5 * i;
				numbers[i] = Math.Round (Math.Sin (k * x) / (k * x), 2);
				//numbers[i] = (numbers[i] + 0.3) * 60.0;
				numbers[i] = random.Next (20);
			}

			return numbers;
		}
		
		private DateTime[] CreateDateTimeSequence (int count)
		{
			DateTime[] dateTimes = new DateTime[count];
			
			// define date range by its last day equal to today and an
			// one day interval
			dateTimes[dateTimes.Length - 1] = DateTime.Now;
			for (int i = dateTimes.Length - 2; i >= 0; i--) {
				dateTimes[i] = dateTimes[i+1].Subtract (TimeSpan.FromDays (1.0));
			}
			
			return dateTimes;
		}
}
