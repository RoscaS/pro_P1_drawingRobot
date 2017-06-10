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

+++

<h3><span class="fragment">2.5 </span><span style="color:#3c8eb3">Blue</span><span class="fragment">tooth</span></h3>

<br>
- feet32 |
- Synchronisation via Windows tool |
<br>
<br>


+++?code=01code/bluethoot-co.cs&lang=cs
$ \rightarrow $ `btnBluetooth_Click_1()`

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
