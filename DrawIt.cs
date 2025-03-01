using System.Windows;
using System.Windows.Media;

namespace WPFVisuals
{
	// Host container for DrawingVisual.
	class DrawIt : FrameworkElement
	{
		private readonly VisualCollection Children;
		public DrawIt()
		{
			// A megjelenített vizuális objektumok (gyermek objektumok) referenciáit tárolja.
			Children = new VisualCollection(this);
			// A DrawIt komponens betöltődésekor történik a rajzolás.
			Loaded += DrawIt_Loaded;
		}

		private void DrawIt_Loaded(object sender, RoutedEventArgs e)
		{
			int x = 0;
			// A két négyzet megrajzolása.
			for (int i = 0; i < 2; i++)
			{
				// Négyzet objektum létehozása.
				DrawingVisual Square = new();
				// Eszközkapcsolat megnyitása.
				using (DrawingContext dc = Square.RenderOpen())
				{
					// Négyzet megrajzolása.
					dc.DrawRectangle(Brushes.Red, new Pen(Brushes.Black, 2),
							new Rect(new Point(0 + x, 0), new Size(40, 40)));
				}
				// Négyzet objektum hozzáadása a drawIt gyermekeihez.
				_=Children.Add(Square);
				x += 60;
			}
		}
		protected override Visual GetVisualChild(int index)
		{
			return Children[index];
		}
		protected override int VisualChildrenCount => Children.Count;
	}
}
