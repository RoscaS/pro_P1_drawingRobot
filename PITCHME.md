
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

* Dessiner d’après une liste de points préenregistrés
* Reproduire une image |
* Dessiner une capture de la webcam |
* Reproduire un dessin de l’utilisateur |

---

## 2. Analyse et solutions retenues

---

<b aligne="left">2.1 Simulateur:</b>
* Bras sous forme de traits calculés à l’aide de l’algo d’intersection des cercles

```c#
int intCercles(cx0, cy0, r0, cx1, cy1, r1, 
               out PointF i1, out PointF i2) {
    // Find the distance between the centers.
    // ...
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
        // Find a and h.
        // Find P2.
        // Get the points P3.
        // See if we have 1 or 2 solutions.
    }
}
```

---


