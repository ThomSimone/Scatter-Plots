using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScatterPlots
{
	class StrangeAttractors
	{
		private double x = 0.0,
					   y = 0.0;
		private const double A = 0.65343,
							 B = 0.7345345;
		public List<double> Xs = new List<double>(),
							Ys = new List<double>();

		private void Attractor(ref double x, ref double y)
		{
			double newX = Math.Sin(x * y / B) * y + Math.Cos(A * x - y);
			y = (x + Math.Sin(y) / B);
			x = newX;
		}
		public StrangeAttractors()
		{
			PopulateStrangeAttractors(1_000_000);
		}
		public StrangeAttractors(int count)
		{
			PopulateStrangeAttractors(count);
		}
		public void PopulateStrangeAttractors(int count)
		{
			for (int i = 0; i < count; i++)
			{
				Attractor(ref x, ref y);
				Xs.Add(x);
				Ys.Add(y);
			}
		}
	}
}
