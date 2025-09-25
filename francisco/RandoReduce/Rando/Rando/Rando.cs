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
                                Latitude = gpxPoint.Latitude * 10000,
                                Longitude = gpxPoint.Longitude * 10000

                            });
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
            var rangeLat = maxLat - minLat;
            var ratioLat = rangeLat / Width;

            var minLong = trackPoints.Min(tp => tp.Longitude);
            var maxLong = trackPoints.Max(tp => tp.Longitude);
            var rangeLong = maxLong - minLong;
            var ratioLong = rangeLong / Height;
            // De trackpoint vers POINT avec normalisation
            Point[] points = trackPoints.Select(trackPoint => new Point()
            {
                Y = Convert.ToInt32((trackPoint.Longitude - minLong) * ratioLong),
                X = Convert.ToInt32((trackPoint.Latitude - minLat) * ratioLat)
            }).ToArray();

            this.CreateGraphics().DrawLines(myPen, points);
        }

        public double ComputeDistance(List<TrackPoint> trackpoints)
        {
            //initilisation de la distance
            double distance = 0;
            
            //On transforme chaque TrackPoint en un GpxPoint, en ne gardant que les cordonnées GPS (Latitude et Longitude)
            //Pourquoi? Parce que les méthode GetDistanceFrom est définie dans GpxPoint
            //Donc on a besoin de ce type pour faire le calcul
            trackpoints
                .Select(trackpoint=>new GpxPoint() { Latitude=trackpoint.Latitude,Longitude=trackpoint.Longitude})
               //Aggregate est une méthode de LINQ qui permet de parcourir une séquence en accumulant une valeur
               //Ici, on l'utilise pour parcouri les points deux par deux: tp1 est le point précédent, tp2 est le point courant
               //A chaque étape, on calcule la distance entre tp1 et tp2 avec GetDistanceFrom et on l'ajoute à distance
               //important: Aggregate ici ne retourne rien d'utile, on l'utilise uniquement pour son effet de bord (modifier distance)
               //
                .Aggregate((tp1, tp2) =>
                {
                    distance += tp1.GetDistanceFrom(tp2);
                    return tp2;
                });

            return distance;
        }
        //important il faut créer le bouton sur le forms en utilisant la toolbox
        //Cette méthode est déclenchée quand l'utilisateur clique sur le bouton button1
        //Elle appelle ComputeDistance en lui passant la liste trackPoints, qui contient tous les points du tracé
        private void button1_Click(object sender, EventArgs e)
        {
            var distance = ComputeDistance(trackPoints);

            //TODO gérer les unités
            label1.Text = $"Distance:{distance}";
        }
    }
}
