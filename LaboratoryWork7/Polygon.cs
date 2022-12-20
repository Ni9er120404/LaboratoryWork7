namespace LaboratoryWork7
{
	public partial class Polygon
	{
		private readonly Point[] _points;

		public Polygon(Point[] points)
		{
			_points = points;
		}

		private static bool IsIntersect(Point first, Point second, Point point)
		{
			if (point.X > Math.Max(first.X, second.X))
			{
				return false;
			}

			double max_y, min_y;

			if (first.Y > second.Y)
			{
				max_y = first.Y;
				min_y = second.Y;
			}
			else
			{
				max_y = second.Y;
				min_y = first.Y;
			}
			return (point.Y <= max_y) && (point.Y > min_y);
		}

		private static bool IsOnLine(Point first, Point second, Point point, double epsilon = 2.220446049250313e-16)
		{
			if (point.X - Math.Max(first.X, second.X) > epsilon ||
				Math.Min(first.X, second.X) - point.X > epsilon ||
				point.Y - Math.Max(first.Y, second.Y) > epsilon ||
				Math.Min(first.Y, second.Y) - point.Y > epsilon)
			{
				return false;
			}

			if (Math.Abs(second.X - first.X) < epsilon)
			{
				return Math.Abs(first.X - point.X) < epsilon || Math.Abs(second.X - point.X) < epsilon;
			}

			if (Math.Abs(second.Y - first.Y) < epsilon)
			{
				return Math.Abs(first.Y - point.Y) < epsilon || Math.Abs(second.Y - point.Y) < epsilon;
			}

			double x = first.X + ((point.Y - first.Y) * (second.X - first.X) / (second.Y - first.Y));

			double y = first.Y + ((point.X - first.X) * (second.Y - first.Y) / (second.X - first.X));

			return Math.Abs(point.X - x) < epsilon || Math.Abs(point.Y - y) < epsilon;
		}

		public int IsInside(Point point)
		{
			uint count = 0;

			for (int i = 0, j = 1; i < _points.Length; i++, j = (++j) % _points.Length)
			{
				if (IsOnLine(_points[i], _points[j], point))
				{
					return 0;
				}

				count += Convert.ToUInt32(IsIntersect(_points[i], _points[j], point));
			}
			return -1 + ((byte)(count % 2) * 2);
		}
	}
}