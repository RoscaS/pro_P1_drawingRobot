# PROJET P1: Présentation juin 2017

## Drawing Robot soon won't be a simulator anymore


PRESENTATION: LUNDI 12.6.17 - 9:30

**RDV: Lundi 8:10 devant salle 320**

## TODO:


**Erwan** (1m)
* Intro
* Rappel du cahier des charges

**Sol** (3m)
* Analyse et solutions retenues
* Gestion de projet(méthodologie, communication interne, etc...)

**Fabien** (4m)
* Etat de l'implémentation / Respect du cahier des charges

**Erwan** (4m)
* demo

**Damian** (3m)
* Etat d'avancement et planning pour la phase d'intégration


**Erwan**: derniers bug-fixs et scaling + créer démo.




* Simulateur : bras sous forme de traits calculés à l’aide de l’algo d’intersection des cercles

* Trouver le chemin du bras du robot : classement des points dans un ordre qui optimise le chemin du bras (algo approximatif) amélioration possible : dijkstra (pas implémenté) actuellement le programme met quelque temps à calculer le chemin avant de commencer à dessiner. Dijkstra nous permettrait de commencer tout de suite avec une solution approximée.

* Gestion live des données : sous forme de liste d’objets contenant des coordonnées et un état de stylo (levé/baissé)

    public List<PixelPointF> DrawPointList = new List<PixelPointF>();





* Tramage : analyse de l’image pour définir un dégradé de 4 gris appliqués au dessin grâce à un tramage. (Exemple dans la démo)

        ToGreyLevels



* Bluetooth : feet32 utilisé et sync grace à l’outil windows




### Etat de l’implémentation

Programme fonctionnel mais pas encore foolproof (utilisable par les dévs)

Webcam : pas encore implémentée

Dessin user : OK

Sauvegarde de liste : buguée (scaling)

Lecture de liste : OK

Lecture d’image : OK

Simulateur : OK

### Planning futur :

Rendre le programme ergonomique et gérer tous les cas et exceptions

Implémeter la webcam

Régler les problèmes de mise à l’échelle sur la sauvegarde de fichier de listes



















<!--
### Algorithmes utilisés

* bressenham  
    * [Algorithme de tracé de segment de Bresenham](https://fr.wikipedia.org/wiki/Algorithme_de_trac%C3%A9_de_segment_de_Bresenham)
* dijkstra
    > ok
* intersection des cercles 
    > ok
    * [dermine where two circles intersect](http://csharphelper.com/blog/2014/09/determine-where-two-circles-intersect-in-c/)
* sortbydistance:


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



Circle intersection
```c#
private int FindCircleCircleIntersections(float cx0, float cy0, float radius0, float cx1, float cy1, float radius1, out PointF intersection1, out PointF intersection2)
{
    // Find the distance between the centers.
    float dx = cx0 - cx1;
    float dy = cy0 - cy1;
    double dist = Math.Sqrt(dx * dx + dy * dy);

    // See how many solutions there are.
    if (dist > radius0 + radius1)
    {
        // No solutions, the circles are too far apart.
        intersection1 = new PointF(float.NaN, float.NaN);
        intersection2 = new PointF(float.NaN, float.NaN);
        return 0;
    }
    else if (dist < Math.Abs(radius0 - radius1))
    {
        // No solutions, one circle contains the other.
        intersection1 = new PointF(float.NaN, float.NaN);
        intersection2 = new PointF(float.NaN, float.NaN);
        return 0;
    }
    else if ((dist == 0) && (radius0 == radius1))
    {
        // No solutions, the circles coincide.
        intersection1 = new PointF(float.NaN, float.NaN);
        intersection2 = new PointF(float.NaN, float.NaN);
        return 0;
    }
    else
    {
        // Find a and h.
        double a = (radius0 * radius0 - radius1 * radius1 + dist * dist) / (2 * dist);
        double h = Math.Sqrt(radius0 * radius0 - a * a);

        // Find P2.
        double cx2 = cx0 + a * (cx1 - cx0) / dist;
        double cy2 = cy0 + a * (cy1 - cy0) / dist;

        // Get the points P3.
        intersection1 = new PointF(
            (float)(cx2 + h * (cy1 - cy0) / dist),
            (float)(cy2 - h * (cx1 - cx0) / dist));
        intersection2 = new PointF(
            (float)(cx2 - h * (cy1 - cy0) / dist),
            (float)(cy2 + h * (cx1 - cx0) / dist));

        // See if we have 1 or 2 solutions.
        if (dist == radius0 + radius1) return 1;
        return 2;
    }
}
```-->