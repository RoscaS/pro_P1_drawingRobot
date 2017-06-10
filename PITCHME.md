
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

## 1. Rappel du cahier des charges

Réaliser un programme capable de piloter un robot Scara qui pourra:

- <span style="color:green"> [_V_] <span/> Dessiner une liste de points préenregistrés 
- <span style="color:green"> [_V_] <span/> Reproduire une image  |
- [ ] Dessiner une capture de la webcam |
- <span style="color:green"> [_V_] <span/> Reproduire un dessin de l’utilisateur  |

---

## 2. Analyse et solutions retenues
<!--<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">-->

---

### 2.1 Simulateur:
Bras sous forme de traits calculés à l’aide de l’algorithme **d’intersection des cercles**
<br><br><br><br><br>
<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">



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

### 2.2 Trouver le chemin du bras du robot 1/3

Classement des points dans une liste dans un ordre qui optimise le chemin du bras (_algo approximatif_).

<p class="fragment">1. [ ] **Précalcule des points**<br>
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

### 2.2 Trouver le chemin du bras du robot 2/3

Classement des points dans un ordre qui optimise le chemin du bras (algo approximatif)
1. Précalcule des points <span style="color:green"> $V$ <span/>
2. Temps de chargement |

<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">

+++?code=01code/chemin.cs&lang=cs

$ \rightarrow $ `sortByDist()`
@[18-19](computing progress bar value)
@[21-21](updating progress bar display)

+++

### 2.2 Trouver le chemin du bras du robot 3/3

Classement des points dans un ordre qui optimise le chemin du bras (algo approximatif)
1. [x] Précalcule des points
2. [x] Temps de chargement
<br>
- Amélioration possible : dijkstra (pas implémenté) |
    - solution approximée |
    - démarrage du dessin instantané |

+++

### 2.3 Gestion temps réel des données 

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
