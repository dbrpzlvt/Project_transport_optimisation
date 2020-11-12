using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using OsmSharp;
using OsmSharp.Db;
using OsmSharp.Logging;
using OsmSharp.Streams;
using OsmSharp.Streams.Complete;
using Project_transport_optimisation.Download;
using Project_transport_optimisation.Other;

namespace Project_transport_optimisation
{
	public partial class Form1 : Form
	{
		List<PointLatLng> _points;
		public Form1()
		{
			InitializeComponent();
			_points = new List<PointLatLng>();
		}

		private void gMapControl1_Load(object sender, EventArgs e)
		{
			// Настройки для компонента GMap
			gmap.Bearing = 0;
			// Перетаскивание правой кнопки мыши
			gmap.CanDragMap = true;
			gmap.DragButton = MouseButtons.Middle;

			gmap.GrayScaleMode = true;

			// Все маркеры будут показаны
			gmap.MarkersEnabled = true;
			// Максимальное приближение
			gmap.MaxZoom = 17;
			// Минимальное приближение
			gmap.MinZoom = 3;
			// Курсор мыши в центр карты
			gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;

			// Отключение нигативного режима
			gmap.NegativeMode = false;
			// Разрешение полигонов
			gmap.PolygonsEnabled = true;
			// Разрешение маршрутов
			gmap.RoutesEnabled = true;
			// Скрытие внешней сетки карты
			gmap.ShowTileGridLines = false;
			// При загрузке 10-кратное увеличение
			gmap.Zoom = 5;
			// Отключение красного крестика по центру
			gmap.ShowCenter = true;

			// Изменение размеров
			// gmap.Dock = DockStyle.Fill;

			// Чья карта используется
			gmap.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;

			// Загрузка этой точки на карте
			GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
			gmap.Position = new GMap.NET.PointLatLng(59.9311, 30.3609);

			// Создаём новый список маркеров
			GMapOverlay markersOverlay = new GMapOverlay("markers");

			// Инициализация красного маркера с указанием его коордиант
			GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(59.9311, 30.3609), GMarkerGoogleType.red);
			marker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);

			// Текст отображаемый с маркером
			marker.ToolTipText = "The capital of culture";
			// Добавляем маркер в список маркеров
			markersOverlay.Markers.Add(marker);
			gmap.Overlays.Add(markersOverlay);

		}

		private void btnAddPoint_Click(object sender, EventArgs e)
		{
			txtLat.Text = txtLat.Text.Replace(".", ",");
			txtLng.Text = txtLng.Text.Replace(".", ",");
			_points.Add(new PointLatLng(Convert.ToDouble(txtLat.Text), Convert.ToDouble(txtLng.Text)));
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// ЧАСТЬ ПЕРВАЯ. НАЧАЛО
			// enable logging.
			OsmSharp.Logging.Logger.LogAction = (o, level, message, parameters) =>
			{
				Console.WriteLine(string.Format("[{0}-{3}] {1} - {2}", o, level, message, DateTime.Now.ToString()));
			};

			// download and extract test-data if not already there.
			OsmSharp.Logging.Logger.Log("Program", TraceEventType.Information, "Downloading PBF...");
			Download_PBF.DownloadAll();

			// create a source.
			var source = new OsmSharp.Streams.PBFOsmStreamSource(File.OpenRead(Download_PBF.Local));

			// loop over all objects and count them.
			int nodes = 0, ways = 0, relations = 0;
			var testAction = new Action(() =>
			{
				foreach (var osmGeo in source)
				{
					if (osmGeo.Type == OsmGeoType.Node)
					{
						nodes++;
					}
					if (osmGeo.Type == OsmGeoType.Way)
					{
						ways++;
					}
					if (osmGeo.Type == OsmGeoType.Relation)
					{
						relations++;
					}
				}
			});

			testAction.TestPerf("Test counting objects.");
			OsmSharp.Logging.Logger.Log("Program", TraceEventType.Information, "Counted {0} nodes, {1} ways and {2} relations.",
				nodes, ways, relations);

			// write a compressed PBF.
			source.Reset();
			testAction = new Action(() =>
			{
				using (var output = File.Open("output.osm.pbf", FileMode.Create))
				{
					var target = new OsmSharp.Streams.PBFOsmStreamTarget(output, true);
					target.RegisterSource(source);
					target.Pull();
				}
			});
			testAction.TestPerf("Test writing a PBF.");
			OsmSharp.Logging.Logger.Log("Program", TraceEventType.Information, "Written PBF.");

			// test converting to complete.
			source.Reset();
			testAction = new Action(() =>
			{
				var filteredQuery = from osmGeo in source
									where osmGeo.Type == OsmGeoType.Way
									&& osmGeo.Tags.ContainsKey("highway")
									&& !osmGeo.Tags.Contains("highway", "cycleway")
									&& !osmGeo.Tags.Contains("highway", "bus_stop")
									&& !osmGeo.Tags.Contains("highway", "street_lamp")
									&& !osmGeo.Tags.Contains("highway", "path")
									&& !osmGeo.Tags.Contains("highway", "turning_cycle")
									&& !osmGeo.Tags.Contains("highway", "traffic_signals")
									&& !osmGeo.Tags.Contains("highway", "stops")
									&& !osmGeo.Tags.Contains("highway", "pedestrian")
									&& !osmGeo.Tags.Contains("highway", "footway")
									|| osmGeo.Type == OsmGeoType.Node
									select osmGeo;

				var collectionComplete = filteredQuery.ToComplete();
				var completeWays = collectionComplete.Where(x => x.Type == OsmGeoType.Way).ToList();
				OsmSharp.Logging.Logger.Log("Program", TraceEventType.Information, "Found {0} complete ways.",
					completeWays.Count);
			});
			testAction.TestPerf("Test converting to complete ways.");
			OsmSharp.Logging.Logger.Log("Program", TraceEventType.Information, "Converted completed ways.");

			// regression test for indexing names.
			source.Reset();
			testAction = new Action(() =>
			{
				var completeSource = new OsmSimpleCompleteStreamSource(source);
				var namesDictionary = completeSource
					.Where(o => string.IsNullOrWhiteSpace(o.Tags.GetValue("name")) == false)
					.GroupBy(o => o.Tags.GetValue("name"))
					.ToDictionary(g => g.Key, g => g.ToList());
				OsmSharp.Logging.Logger.Log("Program", TraceEventType.Information, "Indexed {0} names.",
					namesDictionary.Count);
			});
			testAction.TestPerf("Test indexing names.");
			OsmSharp.Logging.Logger.Log("Program", TraceEventType.Information, "Indexed names.");

			OsmSharp.Logging.Logger.Log("Program", TraceEventType.Information, "Testing finished.");
#if DEBUG
			Console.ReadLine();
#endif

			//Itinero itinero = new Itinero();
			//itinero.func();
		}

		private void btnLoadMap_Click(object sender, EventArgs e)
		{
			txtLat.Text = txtLat.Text.Replace(".", ",");
			txtLng.Text = txtLng.Text.Replace(".", ",");

			double lat = Convert.ToDouble(txtLat.Text);
			double lng = Convert.ToDouble(txtLng.Text);
			gmap.Position = new PointLatLng(lat, lng);
			gmap.MinZoom = 3;
			gmap.MaxZoom = 100;
			gmap.Zoom = 10;

			PointLatLng point = new PointLatLng(lat, lng);
			GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.orange_dot);

			GMapOverlay markers = new GMapOverlay("markers");
			markers.Markers.Add(marker);
			gmap.Overlays.Add(markers);
		}

		private void btnClearList_Click(object sender, EventArgs e)
		{
			_points.Clear();
		}

		private void btnGetRoute_Click(object sender, EventArgs e)
		{
			var route = OpenStreetMapProvider.Instance.GetRoute(_points[0], _points[1], false, false, 14);
			var r = new GMapRoute(route.Points, "Путь");

			//{
			//	Stroke = new Pen(Color.Red, 5);
			//};

			var routes = new GMapOverlay("routes");
			routes.Routes.Add(r);
			gmap.Overlays.Add(routes);
		}
	}
}
