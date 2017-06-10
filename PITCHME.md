
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
<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">

---

### 2.1 Simulateur:
- Bras sous forme de traits calculés à l’aide de l’algorithme **d’intersection des cercles**

<img src="/00illustrations/down-arrow.png" height="auto" style="border: none">


+++?code=/01code/intCerc.cs&lang=c#

@[1-8](signature) @[10-12](Find the distance between the centers) @[14-34](No solution [3 cases]) @[15-20](case 1. Circles too far apart) @[22-27](case 2. One circle C the other) @[29-34](case 3. circle 1 = circle 2) @[36-50](else, there is at least one solution) @[38-39](Find a and h) @[41-42](Find P2) @[44-49](Get the points P3) @[51-54](Another solution?)

---

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
