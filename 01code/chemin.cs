private List<PixelPointF> SortByDist(List<PixelPointF> lst)
{
    List<PixelPointF> output = 
        new List<PixelPointF>();

    output.Add(
        lst[NearestPoint(new PixelPointF(
            new PointF(0, 0), false), lst)]);



    lst.Remove(output[0]);
    int x = 0;
    for (int i = 0; i < lst.Count + x; i++)
    {
        output.Add(lst[NearestPoint(output[output.Count - 1], lst)]);
        lst.Remove(output[output.Count - 1]);
        x++;

        progressBarProcessing.Maximum = lst.Count() + x + 1;
        progressBarProcessing.Value = x;

        Application.DoEvents();
    }
    return output;
}

private int NearestPoint(PixelPointF srcPt, List<PixelPointF> lookIn)
{
    KeyValuePair<double, int> smallestDistance = new KeyValuePair<double, int>();
    for (int i = 0; i < lookIn.Count; i++)
    {
        double distance = Math.Sqrt(Math.Pow(srcPt.Coordinates.X - lookIn[i].Coordinates.X, 2) + Math.Pow(srcPt.Coordinates.Y - lookIn[i].Coordinates.Y, 2));
        if (i == 0)
        {
            smallestDistance = new KeyValuePair<double, int>(distance, i);
        }
        else
        {
            if (distance < smallestDistance.Key)
            {
                smallestDistance = new KeyValuePair<double, int>(distance, i);
            }
        }
    }
    return smallestDistance.Value;
}