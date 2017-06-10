private int nearestPoint(PixelPointF srcPt, 
                         List<PixelPointF> lookIn)
{
    KeyValuePair<double, int> smallestDistance = 
        new KeyValuePair<double, int>();

    for (int i = 0; i < lookIn.Count; i++)
    {
        double distance = Math.Sqrt(Math.Pow(
            srcPt.Coordinates.X - 
            lookIn[i].Coordinates.X, 2) + 
            Math.Pow(srcPt.Coordinates.Y - 
            lookIn[i].Coordinates.Y, 2));
        
        if (i == 0) {
            smallestDistance = 
                new KeyValuePair<double, int>(distance, i);
        }

        else {
            if (distance < smallestDistance.Key) {
                smallestDistance = 
                    new KeyValuePair<double, int>(distance, i);
            }
        }
    }
    return smallestDistance.Value;
}