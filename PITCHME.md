
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
<!--<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">-->

---

### 2.1 Simulateur:
Modélisation du bras réalisée à l’aide de l’algorithme d’`intersection des cercles`
<br><br><br><br><br>

<p class="fragment"> <br>
<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">
</p>


+++?code=01code/intCerc.cs&lang=cs 

`circlesIntersect()`
@[5-7](find the distance between the centers)
@[9-14](No solution case 1: $\quad$ circles too far apart)
@[16-21](No solution case 2: $\quad$ one circle $\subset$ the other)
@[23-28](No solution case 3: $\quad$ circle 1 $\equiv$ circle 2)
@[30-30](Else: $\quad$ there is at least one solution)
@[32-33](Find $\large a $ and $\large h $)
@[35-36](Find P2)
@[38-43](Get the points P3)
@[45-48](Another solution?)

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


+++?code=01code/nearestPoint.cs&lang=cs

$ \rightarrow $ `nearestPoint()`
@[4-5](smallestDistance initialisation)
@[7-13](loop over point list & compute distances)
@[15-27](find the smallest distance and return it to sortByDist())


+++?code=01code/sortByDist.cs&lang=cs

$ \rightarrow $ `sortByDist()`
@[12-18](sorting coords list)


+++

### 2.2 Déplacement du bras du <span style="color:#E49436">robot</span>
<br>
Classement des points dans un ordre qui optimise le chemin du bras (algo approximatif)

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

+++

### 2.2 Déplacement du bras du <span style="color:#E49436">robot</span>
<br>
<ol>
    <li>
        **[**<span style="color:green">**v**</span>**]** Précalcule des points
    </li>
    <li>
        **[**<span style="color:green">**v**</span>**]** Temps de chargement
    </li>
</ol>

Amélioration possible: <span class="fragment" style="color:#E49436">dijkstra</span>
    - solution approximée |
    - démarrage du dessin instantané |



+++

### 2.3 Gestion <span style="color:#E49436"> temps réel </span> des données 

- Liste d’objets contenant des coordonnées |
- Etat du stylo (levé/baissé) |

+++

### 2.4 Tramage 

- Analyse de l’image
    - définition d'un dégradé de 4 gris |
    - application grâce à un tramage. |

**Exemple dans la démonstration**

+++

### 2.5 Bluetooth 

- feet32 
- Synchronisation via Windows tool

---

## 3. Gestion de projet

+++

### 3.1 Méthodologie

- Partage de documentation/ressources
    - Google drive
- Communicatioon
    - Whatsapp
- Versionning 
    - Forge
    - GitHub depuis mars 2017
