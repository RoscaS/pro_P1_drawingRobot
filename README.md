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

> public List<PixelPointF> DrawPointList = new List<PixelPointF>();





* Tramage : analyse de l’image pour définir un dégradé de 4 gris appliqués au dessin grâce à un tramage. (Exemple dans la démo)

> ToGreyLevels



* Bluetooth : feet32 utilisé et sync grace à l’outil windows

<span style="color:red"> T'ES SUR DE ÇA? </span>


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







### github

* **distributed** version control system
<br>
<br>
<br>
* push: send (big confusion here, pull and push where meaning the opposit a couple of years ago)

* pull: bring down last version eg:
    * git pull origin master: will pull down the last version of the master the hosted on GH.

`git pull origin master`

if sombody else have done some changes, using `git diff HEAD` will sho the differences between the last local version and the one just pulled

after using `git add` we can use `git diff --staged` to see the modification made

* HEAD: The HEAD is a pointer that holds your position within all your different commits. By default HEAD points to your most recent commit,


*Branching:*
When developers are working on a feature or bug they'll often create a copy (aka. branch) of their code they can make separate commits to. Then when they're done they can merge this branch back into their main master branch.

Branches are what naturally happens when you want to work on multiple features at the same time. You wouldn't want to end up with a master branch which has Feature A half done and Feature B half done.

Rather you'd separate the code base into two "snapshots" (branches) and work on and commit to them separately. As soon as one was ready, you might merge this branch back into the master branch and push it to the remote server.  

`git branch branche_name`: new branch  
`git branch`: shows project branches
`git push --set-upstream origin new_branch` create this new_branch on gh server

You can use:

`git checkout -b new_branch`

to checkout and create a branch at the same time. This is the same thing as doing:

`git branch new_branch`  
`git checkout new_branch`

once the job is done on the branch we can use `git merge branch_name` to merge it into a lower branch. for example, from the master we could merge the new_branch branch by doing `git merge new\_newbranch`. Once the merge is done, we can delete the branch with `git branch -d new_branch`

`git push` push the work on github

>Merge Conflicts

>Merge Conflicts can occur when changes are made to a file at the same time. A lot of people get really scared when a conflict happens, but fear not! They aren't that scary, you just need to decide which code to keep.

[git-doc on merge conflicts](https://git-scm.com/docs/git-merge#_how_conflicts_are_presented)

>Force delete

>What if you have been working on a feature branch and you decide you really don't want this feature anymore? You might decide to delete the branch since you're scrapping the idea. You'll notice that git branch -d bad_feature doesn't work. This is because -d won't let you delete something that hasn't been merged.

>You can either add the --force (-f) option or use -D which combines -d -f together into one command.




wtf?
>Pull Requests
>
>If you're hosting your repo on GitHub, you can do something called a >pull request.
>
>A pull request allows the boss of the project to look through your >changes and make comments before deciding to merge in the change. It's >a really great feature that is used all the time for remote workers and open-source projects.
>
>Check out the pull request help page for more information.




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