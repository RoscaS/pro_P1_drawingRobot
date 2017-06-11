
## 4. Etat de l'<span style="color:#E49436">implémentation</span>

<p class="fragment" align="left"> Programme fonctionnel mais pas encore foolproof </p>


<p class="fragment" align="left" style="display:inline; text-align:left; vertical-align: middle;"> Simulateur</p>
<img class="fragment" src="/00illustrations/ok.png" height="40" style="border: none; box-shadow: 0px 0px 0px #000; display:inline; vertical-align: middle; ; padding-left:60px">

<p class="fragment" align="left" style="display:inline; text-align:left; display:inline; vertical-align: middle;">Lecteur d'images</p>
<img class="fragment" src="/00illustrations/ok.png" height="40" style="border: none; box-shadow: 0px 0px 0px #000; display:inline; vertical-align: middle; ; padding-left:60px">

<p class="fragment" align="left" style="display:inline; text-align:left; display:inline; vertical-align: middle;">Dessin à la souris</p>
<img class="fragment" src="/00illustrations/ok.png" height="40" style="border: none; box-shadow: 0px 0px 0px #000; display:inline; vertical-align: middle; ; padding-left:60px">

<p class="fragment" align="left" style="display:inline; text-align:left; display:inline; vertical-align: middle;">Sauvegarde de liste: Problèmes de scaling</p>
<img class="fragment" src="/00illustrations/close.png" height="40" style="border: none; box-shadow: 0px 0px 0px #000; display:inline; vertical-align: middle; ; padding-left:60px">

<p class="fragment" align="left" style="display:inline; text-align:left; display:inline; vertical-align: middle;">Webcam: Pas implémentée</p>
<img class="fragment" src="/00illustrations/nok.png" height="40" style="border: none; box-shadow: 0px 0px 0px #000; display:inline; vertical-align: middle; ; padding-left:60px">










---


## $ Vinci$ <span style="color:#E49436"> $ Code $</span>
<br>
###Projet P1 <span style="color:#DC0062">DLM</span> 2016-2017
<br>

**Groupe 5**
Erwan Bueche – Sol Rosca  
Fabien Mottier – Damian Petroff

---


## Introduction

<img src="/00illustrations/robot.jpg" align="" height="400">

---



## 1. Cahier des <span style="color:#E49436">charges</span>

<br>
<br>

<ul>
    <li class="fragment">
        **[**<span style="color:green">**v**</span>**]** Dessiner une liste de points préenregistrés
    </li>
    <li class="fragment">
        **[**<span style="color:green">**v**</span>**]** Reproduire une image
    </li>
    <li class="fragment">
        **[**<span style="color:red">**x**</span>**]** Dessiner une capture de la webcam
    </li>
    <li class="fragment">
        **[**<span style="color:green">**v**</span>**]** Reproduire un dessin de l’utilisateur
    </li>
</ul>

---



## 2. Analyse et <span style="color:#E49436">solutions</span>

<p class="fragment"> <br>
<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">
</p>

+++

### 2.1 Simulateur:
Modélisation du bras réalisée à l’aide de l’algorithme d'**intersection des cercles**
<br>

<p class="fragment">
<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">
</p>



+++?code=01code/intCerc.cs&lang=cs 

$ \rightarrow $ `circlesIntersect()`
@[5-7](Find distance between centers)
@[9-14](No solution case 1: $\quad$ circles too far apart)
@[16-21](No solution case 2: $\quad$ one circle $\subset$ the other)
@[23-28](No solution case 3: $\quad$ circle 1 $\equiv$ circle 2)
@[30-30](Else: $\quad$ there is at least one solution)
@[32-33](Find $\large a $ and $\large h $)
@[35-36](Find P2)
@[38-43](Get the points P3)
@[45-48](Another solution?)

<p class="fragment">
<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">
</p>

+++



### 2.2 Déplacement du bras du <span style="color:#E49436">robot</span>
<br>
Classement des points dans une liste ordonnée qui optimise le déplacement du bras (_algo approximatif_).

<ol>
    <li class="fragment">
        Précalcule des points
    </li>
</ol>

<p class="fragment"> <br>
<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">
</p>



+++?code=01code/sortByDist.cs&lang=cs

$ \rightarrow $ `sortByDist()`
@[3-4](List declaration)
@[6-8](Appending coords)

<p class="fragment">
<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">
</p>



+++?code=01code/nearestPoint.cs&lang=cs

$ \rightarrow $ `nearestPoint()`
@[4-5](smallestDistance initialisation)
@[7-13](loop over point list & compute distances)
@[15-27](find the smallest distance and return it to sortByDist())

<p class="fragment">
<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">
</p>



+++?code=01code/sortByDist.cs&lang=cs

$ \rightarrow $ `sortByDist()`

@[10-16](sorting coords list)

<p class="fragment">
<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">
</p>

+++



### 2.2 Déplacement du bras du <span style="color:#E49436">robot</span>
<br>
Classement des points dans une liste ordonnée qui optimise le déplacement du bras (_algo approximatif_).

<ol>
    <li>
        **[**<span style="color:green">**v**</span>**]** Précalcule des points
    </li>
    <li class="fragment">
        Temps de chargement
    </li>
</ol>

<p class="fragment"> <br>
<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">
</p>



+++?code=01code/sortByDist.cs&lang=cs

$ \rightarrow $ `sortByDist()`
@[18-19](computing progress bar value)
@[21-21](updating progress bar display)

<p class="fragment">
<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">
</p>

+++




### 2.2 Déplacement du bras du <span style="color:#E49436">robot</span>
<br>
Classement des points dans une liste ordonnée qui optimise le déplacement du bras (_algo approximatif_).

<ol>
    <li>
        **[**<span style="color:green">**v**</span>**]** Précalcule des points
    </li>
    <li>
        **[**<span style="color:green">**v**</span>**]** Temps de chargement
    </li>
</ol>

<p align="left">Amélioration possible: <span class="fragment" style="color:#E49436">**Dijkstra**</span></p>

- Solution approximée |
- Démarrage du dessin instantané |

<p class="fragment">
<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">
</p>

+++



### 2.3 Gestion <span style="color:#E49436"> temps réel </span> des données 

Liste d'objets de type `PixelPointF`

<br>

```cs
List<PixelPointF> DrawPointList = new List<PixelPointF>();
```

```cs
    public class PixelPointF
    {
        #region Attributes
        private PointF coordinates;
        private bool penEngaged;
        // ...
    }
```

<p class="fragment">
<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">
</p>

+++

### 2.4 Tramage 

<p align="left">Analyse de l’image:</p>

<ul>
    <li class="fragment">
        Définition d'un dégradé de 4 gris
    </li>
    <li class="fragment">
        Application grâce à un tramage
    </li>
</ul>

<p class="fragment" align="right" style="color:#E49436">**Exemple dans la démonstration**</p>

<p class="fragment">
<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">
</p>

+++

<h3><span class="fragment">2.5 </span><span style="color:#3c8eb3">Blue</span><span class="fragment">tooth</span></h3>

<br>
- feet32 |
- Synchronisation via Windows tool |
<br>
<br>

<p class="fragment">
<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">
</p>

+++?code=01code/bluethoot-co.cs&lang=cs
$ \rightarrow $ `btnBluetooth()`

@[3-6](Pairing)
@[8-10](Options)
@[12-15](Check if paired & authentificated)
@[17-18](Get device adress)
@[20-20](Initialise client)
@[22-24](Initialise endPoint)
@[26-31](Change cursor state & Try to connect to device)
@[33-36](If connection ok, enble ui send btn)
@[39-45](If connection faild, display error)
@[48-58](if pairing faild, display error)

<p class="fragment">
<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">
</p>

+++?code=01code/bluethoot-send.cs&lang=cs
$ \rightarrow $ `btnSendData_Click_1()`

@[3-9](setup send process)
@[11-12](initialising new thread)
@[22-27](read line in txt file)
@[29-37](find line that starts with ".")
@[1-1](A CONTINUER)

---


## 3. Gestion <span style="color:#E49436">de</span> projet
<br><br><br>
<p class="fragment">
<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">
</p>


+++

### 3.1 Work<span style="color:#E49436">flow</span>
<br>
<br>
<img class="fragment" src="/00illustrations/drive.png" height="60px" style="border: none; box-shadow: 0px 0px 0px #000">
<br>
<img class="fragment" src="/00illustrations/whatsapp.png" height="80px" style="border: none; box-shadow: 0px 0px 0px #000">
<br>
<img class="fragment" src="/00illustrations/github.png" height="70px" style="border: none; box-shadow: 0px 0px 0px #000">

<p class="fragment">
<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">
</p>

+++

### 3.2 Git<span style="color:#E49436">hub</span> network view

<img src="/00illustrations/gh-net.gif" style="border: none">

<p class="fragment">
<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">
</p>

+++

### 3.3 Github<span style="color:#E49436"> commit</span> frequency

<img src="/00illustrations/gh-com.gif" style="border: none">

---

## 4. Etat de l'<span style="color:#E49436">implémentation</span>

<p class="fragment" align="left"> Programme fonctionnel mais pas encore foolproof </p>


<ul>
    <li class="fragment">
        **[**<span style="color:green">**v**</span>**]** Simulateur
    </li>
    <li class="fragment">
        **[**<span style="color:green">**v**</span>**]** Lecture d'image
    </li>
    <li class="fragment">
        **[**<span style="color:green">**v**</span>**]** Dessin à la souris
    </li>
    <li class="fragment">
        **[**<span style="color:yellow">**-**</span>**]** Sauvegarde de liste: Problèmes de scaling
    </li>
    <li class="fragment">
        **[**<span style="color:red">**x**</span>**]** Webcam: Pas implémenté
    </li>
</ul>










---

## <span style="color:#E49436">Planning</span> futur

<br>
<img class="fragment" align="left" float="left" src="/00illustrations/ui2.png" height="50" style="border: none; box-shadow: 0px 0px 0px #000; padding-top: 17px">
<p class="fragment" align="left" float="left" style="padding-left: 100px; padding-top:10px"> <span style="color:#E49436"> Ergonomie</span> & gestion des exceptions</p>


<img class="fragment" align="left" float="left" src="/00illustrations/webcam2.png" height="50" style="border: none; box-shadow: 0px 0px 0px #000">
<p class="fragment" align="left" float="left" style="padding-left: 100px; padding-top:10px"> Implementation <span style="color:#E49436">web</span>cam</p>


<img class="fragment" align="left" float="left" src="/00illustrations/scale2.png" height="50" style="border: none; box-shadow: 0px 0px 0px #000">
<p class="fragment" align="left" float="left" style="padding-left: 100px; padding-top:10px"> Fine tuning du scaling via fichier <span style="color:#E49436">listes</span></p>

<br>


