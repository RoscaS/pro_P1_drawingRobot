private List<PixelPointF> sortByDist(List<PixelPointF> lst)
{
    List<PixelPointF> output = 
        new List<PixelPointF>();

    output.Add(
        lst[nearestPoint(new PixelPointF(
            new PointF(0, 0), false), lst)]);

    int x = 0;
    for (int i = 0; i < lst.Count + x; i++) {
        output.Add(lst[nearestPoint(output[output.Count - 1], 
            lst)]);
        
        lst.Remove(output[output.Count - 1]);
        x++;

        progressBarProcessing.Maximum = lst.Count() + x + 1;
        progressBarProcessing.Value   = x;

        Application.DoEvents();
    }

    return output;
}

























// modifications:


private List<PixelPointF> sortByDist(List<PixelPointF> lst)
{
    List<PixelPointF> output = 
        new List<PixelPointF>();

    output.Add(
        lst[nearestPoint(new PixelPointF(
            new PointF(0, 0), false), lst)]);

    lst.Remove(output[0]); // removed this line to keep it simple for explenation

    int x = 0;
    for (int i = 0; i < lst.Count + x; i++) {
        output.Add(lst[nearestPoint(output[output.Count - 1], 
            lst)]);
        
        lst.Remove(output[output.Count - 1]);
        x++;

        progressBarProcessing.Maximum = lst.Count() + x + 1;
        progressBarProcessing.Value = x;

        Application.DoEvents();
    }

    return output;
}