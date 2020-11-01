using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itinero;
using Itinero.IO.Osm;
using Itinero.Osm.Vehicles;

namespace Project_transport_optimisation
{
	class Itinero
	{
		public void func()
		{
			var routerDb = new RouterDb();
			using (var stream = new FileInfo(@"C:/Users/Roman/Desktop/СПбГУ/Project_transport_optimisation/Project_transport_optimisation/bin/Debug/luxembourg-latest.osm.pbf").OpenRead())
			{
				routerDb.LoadOsmData(stream, Vehicle.Car);
			}
			var router = new Router(routerDb);

			// calculate a route.
			var route = router.Calculate(Vehicle.Car.Fastest(),
				51.26797020271655f, 4.801905155181885f, 51.26100849597512f, 4.780721068382263f);
			var geoJson = route.ToGeoJson();
		}
	}
}
