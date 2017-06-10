
---

## $$ Vinci\;Code $$

###Projet P1 INF DLM 2016-2017

**Groupe 5**

Erwan Bueche – Sol Rosca  
Fabien Mottier – Damian Petroff

---
## Introduction

<img src="/00illustrations/robot.jpg" align="" height="400">

---

## 1. Rappel du cahier des charges


Réaliser un programme capable de piloter un robot Scara qui pourra:

- Dessiner d’après une liste de points préenregistrés
- Reproduire une image |
- Dessiner une capture de la webcam |
- Reproduire un dessin de l’utilisateur |

---

## 2. Analyse et solutions retenues

+++

### 2.1 Simulateur:
- Bras sous forme de traits calculés à l’aide de l’algorithme **d’intersection des cercles**

```c#
// Find the distance between the centers.
// See how many solutions there are.
if (dist > r0 + r1) {
    // No solutions, the circles are too far apart.
}
else if (dist < Math.Abs(r0 - r1)) {
    // No solutions, one circle contains the other.
}
else if ((dist == 0) && (r0 == r1)) {
    // No solutions, the circles coincide.
}
else {
    // Find a and h, find P2, get the points P3.
    // See if we have 1 or 2 solutions.
```

+++

### 2.2 Trouver le chemin du bras du robot

- Classement des points dans un ordre qui optimise le chemin du bras (algo approximatif)
    - précalcule des points |
    - temps de chargement |

- Amélioration possible : dijkstra (pas implémenté) 
    - solution approximée |
    - démarrage du dessin instantané |

+++

### 2.3 Gestion temps réel des données 

- Liste d’objets contenant des coordonnées |
- Etat du stylo (levé/baissé) |