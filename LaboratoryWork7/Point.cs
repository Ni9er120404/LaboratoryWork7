namespace LaboratoryWork7
{
	public class Point
	{
		public double X { get; set; }

		public double Y { get; set; }

		public Point(double x, double y)
		{
			X = x;
			Y = y;
		}

		public static implicit operator Point((double, double) coordinates)
		{
			return new Point(coordinates.Item1, coordinates.Item2);
		}
	}
}