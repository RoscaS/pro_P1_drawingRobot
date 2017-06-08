# PROJET P1: Présentation juin 2017

## Drawing Robot soon won't be a simulator anymore


### Algorithmes utilisés

* bresenham  
    * [Algorithme de tracé de segment de Bresenham](https://fr.wikipedia.org/wiki/Algorithme_de_trac%C3%A9_de_segment_de_Bresenham)
* dijkstra
    > ok
* intersection des cercles 
    > ok
    * [dermine where two circles intersect](http://csharphelper.com/blog/2014/09/determine-where-two-circles-intersect-in-c/)
* sortbydistance
    > nom de l'algo stp google est super vague sur le sujet


sortByDistance
```c#
private List<PixelPointF> SortByDistance(List<PixelPointF> lst)
{
    List<PixelPointF> output = new List<PixelPointF>();
    output.Add(lst[NearestPoint(new PixelPointF(new PointF(0, 0), false), lst)]);
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
```

nearestPoint
```c#
private int NearestPoint(PixelPointF srcPt, List<PixelPointF> lookIn)
{
    KeyValuePair<double, int> smallestDistance = new KeyValuePair<double, int>();
    for (int i = 0; i < lookIn.Count; i++)
    {
        double distance = Math.Sqrt(Math.Pow(srcPt.Coordinates.X - lookIn[i].Coordinates.X, 2) + 
                            Math.Pow(srcPt.Coordinates.Y - lookIn[i].Coordinates.Y, 2));
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
```