<style>
.poule {
    color: green;
    padding-right: 30px;
}
</style>


## $ Vinci$ <span style="color:#E49436"> $ Code $</span>
<br>
###Projet P1 <span style="color:#DC0062">DLM</span> 2016-2017
<br>

**Groupe 5**
Erwan Bueche – Sol Rosca  
Fabien Mottier – Damian Petroff

---

## Table des <span style="color:#E49436">matières</span>

<div class='poule'>Lalala</div>

1. Cahier des charges
2. Analyses et solutions
3. Gestion de projet
4. Etat de l'implémentation
5. Demonstration
6. Planning futur



---

## Introduction

<img src="/00illustrations/robot.jpg" align="" height="400">

---

## 1. Cahier des <span style="color:#E49436">charges</span>

<br>
<br>

<ul>
    <li class="fragment">
        **[**<span class="fragment" style="color:green">**v**</span>**]** Dessiner une liste de points préenregistrés
    </li>
    <li class="fragment">
        **[**<span class="fragment" style="color:green">**v**</span>**]** Reproduire une image
    </li>
    <li class="fragment">
        **[**<span class="fragment" style="color:red">**x**</span>**]** Dessiner une capture de la webcam
    </li>
    <li class="fragment">
        **[**<span class="fragment" style="color:green">**v**</span>**]** Reproduire un dessin de l’utilisateur
    </li>
</ul>


---



## 2. Analyse et <span style="color:#E49436">solutions</span>

<p class="fragment"> <br>
<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">
</p>

+++

### 2.1 Simulateur:
Modélisation articulation du bras réalisée à l’aide de l’algorithme d'**intersection des cercles**
<br>

<p class="fragment">
<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">
</p>

+++

![alt](https://i.stack.imgur.com/aUXMY.gif)

+++?code=01code/intCerc.cs&lang=cs 

$ \rightarrow $ `circlesIntersect()`
@[5-7](Find distance between centers)
@[9-14](No solution case 1: $\quad$ circles too far apart)
@[16-21](No solution case 2: $\quad$ one circle $\subset$ the other)
@[23-28](No solution case 3: $\quad$ circle 1 $\equiv$ circle 2)
@[30-30](Else: $\quad$ find first interesection)
@[32-33](Find $\large a $ and $\large h $)

+++

![alt](https://i.stack.imgur.com/aUXMY.gif)

+++?code=01code/intCerc.cs&lang=cs 

@[35-36](Find P2)
@[38-43](Get the points P3)

<p class="fragment">
<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">
</p>

+++



### 2.2 Déplacement du bras du <span style="color:#E49436">robot</span>
<br>
Classement des points dans une liste ordonnée qui optimise le déplacement du bras (_algo approximatif_).

<ol>
    <li class="fragment">
        **Précalcule des points**
    </li>
</ol>

<p class="fragment"> <br>
<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">
</p>



+++?code=01code/sortByDist.cs&lang=cs

$ \rightarrow $ `sortByDist()`
@[3-4](List declaration)
@[6-8](Adding coords)

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
        **[**<span class="fragment" style="color:green">**v**</span>**]** Précalcule des points
    </li>
    <li class="fragment">
        **Temps de chargement**
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
Classement des points dans une liste ordonnée qui optimise le déplacement du bras.

<ol>
    <li>
        **[**<span style="color:green">**v**</span>**]** Précalcule des points
    </li>
    <li>
        **[**<span class="fragment" style="color:green">**v**</span>**]** Temps de chargement
    </li>
</ol>


<p align="left">Amélioration possible: <span class="fragment" style="color:#E49436">**Dijkstra**</span></p>

- Vision d'ensemble des solutions possible |
- Démarrage du dessin instantané |

<p class="fragment">
<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">
</p>

+++



### 2.3 Gestion temps <span style="color:#E49436">réel</span> des données 

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

@[3-14](Select device)
@[17-18](Get device adress)
@[20-20](Initialise client)
@[22-24](Initialise endPoint)

<p class="fragment">
<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">
</p>


+++?code=01code/bluethoot-send.cs&lang=cs
$ \rightarrow $ `btnSendData_Click_1()`

@[11-11](New thread)
@[30-35](Writing)
@[36-37](Reading)
@[66-76](Invoke 1)

---

## 3. <span style="color:#E49436">Gestion</span> de projet
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

## 4. <span style="color:#E49436">Etat</span> de l'implémentation</span>

<p class="fragment" align="left"> Programme fonctionnel mais pas encore foolproof </p>


<ul>
    <li class="fragment">
        **[**<span class="fragment" style="color:green">**v**</span>**]** Simulateur
    </li>
    <li class="fragment">
        **[**<span class="fragment" style="color:green">**v**</span>**]** Lecture d'image et liste de points
    </li>
    <li class="fragment">
        **[**<span class="fragment" style="color:green">**v**</span>**]** Dessin à la souris
    </li>
    <li class="fragment">
        **[**<span class="fragment" style="color:#E49436">**-**</span>**]** Sauvegarde de liste: Problèmes de scaling
    </li>
    <li class="fragment">
        **[**<span class="fragment" style="color:red">**x**</span>**]** Webcam: Pas implémenté
    </li>
</ul>

---

## Planning <span style="color:#E49436">futur</span>

<br>
<img class="fragment" align="left" float="left" src="/00illustrations/ui2.png" height="50" style="border: none; box-shadow: 0px 0px 0px #000; padding-top: 17px">
<p class="fragment" align="left" float="left" style="padding-left: 100px; padding-top:10px"> <span style="color:#E49436"> Ergonomie</span> & gestion des exceptions</p>


<img class="fragment" align="left" float="left" src="/00illustrations/webcam2.png" height="50" style="border: none; box-shadow: 0px 0px 0px #000">
<p class="fragment" align="left" float="left" style="padding-left: 100px; padding-top:10px"> Implémentation <span style="color:#E49436">web</span>cam</p>


<img class="fragment" align="left" float="left" src="/00illustrations/scale2.png" height="50" style="border: none; box-shadow: 0px 0px 0px #000">
<p class="fragment" align="left" float="left" style="padding-left: 100px; padding-top:10px"> Fine tuning du scaling via fichier <span style="color:#E49436">listes</span></p>

<br>

---

## <span style="color:#DC0062">HES</span> d'été

<img src="/00illustrations/plan.png" style="border: none">

---

## Place à la <span style="color:#E49436">démo</span>nstration

---

### <span style="color:#E49436">Merci</span> pour votre attention
<br>
<br>
$$ Des\;questions\;? $$


