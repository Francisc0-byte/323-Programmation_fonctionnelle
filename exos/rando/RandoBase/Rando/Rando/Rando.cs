using Gpx;

namespace Rando
{
    public partial class Rando : Form
    {
        string gpxFile = @"..\..\..\..\..\..\gpx\Ballade_châtaignère.gpx";
        List<TrackPoint> trackPoints = new();

        public Rando()
        {
            InitializeComponent();
            if (!File.Exists(gpxFile))
            {
                MessageBox.Show($"Fichier {gpxFile} pas trouvé");
            }

            StreamReader stream = new StreamReader(gpxFile);

            using (GpxReader reader = new GpxReader(stream.BaseStream))
            {
                while (reader.Read())
                {
                    switch (reader.ObjectType)
                    {
                        case GpxObjectType.Track:
                        var gpxPoints = reader.Track.ToGpxPoints();
                            /*
                                //fonctionne mais uniquement si on a qu'une track puisque elle 
                                //ecrase à chaque fois
                                points = gpxPoints.Select(gpxPoint => new TrackPoint()
                                {
                                    Elevation = gpxPoint.Elevation,
                                    Latitute = gpxPoint.Latitude,
                                    Longitute = gpxPoint.Longitude

                                }).ToList();
                            */
                            var converted = gpxPoints.Select(gpxPoint => new TrackPoint()
                            {
                                Elevation = gpxPoint.Elevation,
                                Latitude = gpxPoint.Latitude,
                                Longitude = gpxPoint.Longitude

                            }).ToList();
                            //AddRange permet d'ajouter plusieurs point
                            trackPoints.AddRange(converted.ToList());
                            break;
                    }
                }
            }

        }

        private void Rando_Form_Paint(object sender, PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Red);
            myPen.Width = 2;

            //Point[] points = new Point[4] { new Point(30,50), new Point(50,10), new Point(80,50), new Point(111,400) };

            var minLat = trackPoints.Min(tp => tp.Latitude);
            var maxLat = trackPoints.Max(tp => tp.Latitude);

            var minLon = trackPoints.Min(tp => tp.Longitude);
            var maxLon = trackPoints.Max(tp => tp.Longitude);
            // De trackpoint vers POINT
            Point[] points = trackPoints.Select(trackPoint => new Point()
            {
                X = Convert.ToInt32(trackPoint.Longitude),
                Y = Convert.ToInt32(trackPoint.Latitude)
            }).ToArray();

            this.CreateGraphics().DrawLines(myPen, points);

            
        }
    }
}
