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





