namespace LaboratoryWork7
{

	public partial class Polygon
	{
		[TestClass]
		public class PolygonTest
		{
			[DataRow(0, 5, 0, -5, -1, 0, true)]

			[DataRow(0, 5, 0, -5, 0, 0, true)]

			[DataRow(0, 5, 0, -5, 1, 0, false)]

			[DataRow(0, 5, 0, -5, 0, -6, false)]

			[DataTestMethod]

			public void TestIntersect(double x1, double y1, double x2, double y2, double x3, double y3, bool expected)
			{
				Point first = new(x1, y1);
				Point second = new(x2, y2);
				Point point = new(x3, y3);

				Assert.AreEqual(expected, IsIntersect(first, second, point));
			}

			[DataRow(0, 5, 0, -5, 0, 0, true)]

			[DataRow(0, 5, 0, -5, 0, 5, true)]

			[DataRow(0, 5, 0, -5, 0, -5, true)]

			[DataRow(0, 5, 0, -5, 0, -6, false)]

			[DataRow(0, 5, 0, -5, 1, 0, false)]

			[DataTestMethod]

			public void TestOnLine(double x1, double y1, double x2, double y2, double x3, double y3, bool expected)
			{
				Point first = new(x1, y1);

				Point second = new(x2, y2);

				Point point = new(x3, y3);

				Assert.AreEqual(expected, IsOnLine(first, second, point));
			}

			[DynamicData(nameof(InsideGenerator), DynamicDataSourceType.Method)]

			[DataTestMethod]
			public void TestInside(Polygon poly, Point point, int expected)
			{
				Assert.AreEqual(expected, poly.IsInside(point));
			}

			private static IEnumerable<object[]> InsideGenerator()
			{
				Polygon square = new(new Point[]
				{
					(0, -5),
					(0, 5),
					(10, 5),
					(15, 0),
					(10, -5)
				});

				yield return new object[] { square, (Point)(0, 0), 0 };

				yield return new object[] { square, (Point)(0, 5), 0 };

				yield return new object[] { square, (Point)(0, -6), -1 };

				yield return new object[] { square, (Point)(-1, -5), -1 };

				yield return new object[] { square, (Point)(-2, 3), -1 };

				yield return new object[] { square, (Point)(1, 1), 1 };

				yield return new object[] { square, (Point)(1, 0), 1 };
			}
		};
	}
}