using System.IO;
using System.Net;

namespace Project_transport_optimisation.Download
{
    /// <summary>
    /// Downloads all data needed for testing.
    /// </summary>
    public static class Download_PBF
    {
        public static string PBF = "http://download.openstreetmap.fr/extracts/russia/northwestern_federal_district/saint_petersburg-latest.osm.pbf";
        public static string Local = "saint_petersburg-latest.osm.pbf";

        /// <summary>
        /// Downloads the Saint-Petersburg data.
        /// </summary>
        public static void DownloadAll()
        {
            if (!File.Exists(Download_PBF.Local))
            {
                var client = new WebClient();
                client.DownloadProgressChanged += (sender, e) =>
                { // Displays the operation identifier, and the transfer progress.
                    OsmSharp.Logging.Logger.Log("Download", OsmSharp.Logging.TraceEventType.Information,
                        "{0}    downloaded {1} of {2} bytes. {3} % complete...",
                        (string)e.UserState, e.BytesReceived, e.TotalBytesToReceive, e.ProgressPercentage);
                };
                client.DownloadFile(Download_PBF.PBF,
                    Download_PBF.Local);
            }
        }
    }
}
