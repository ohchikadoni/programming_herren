# Dokumentation

In diesem Dokument geht es um die Planung und Realisierung eines Pogrammes. Konkret soll ein "**Elektronisches Tagebuch**" mit Hilfe des "**roten Faden**" Ansatzes geplant beschrieben und programmiert werden. Die genaue Umschreibung der Aufgabenstellung finden sie hier:



> Elektronisches Tagebuch
>
>  Viele kennen es nur noch vom Hörensagen, das Tagebuch. Aber teilweise auch noch heute führen immer noch viele eine Erinnerungshilfe, in welcher sie das Erlebte Tag für Tag ablegen und es so bewahren.
>
>  
>
> Unsere Idee ist es nun eine aktuellere Version eines solchen Tagebuches zu erschaffen.
>
>  
>
> Bez. des Erfassens von Einträgen soll möglich sein:
>
>  
>
> ·     Erstellen von Einträgen pro gewähltes Datum
>
> ·     Erfassen von Freitext inkl. Sonderzeichen bis zu einer maximalen Länge von 1000 Zeichen 
>
> ·     Erfassen von 3 frei oder aus einer Domäne gewählten Identifikatoren (wie z.B. Ferien, Geburtstag, Familienfest…) für den Eintrag à «Tags»
>
> ·     Optional: Erfassen eines Bildes pro Eintrag (als sep. Punkt der Oberfläche)
>
>   
>
> Wir wollen bezüglich der Nutzung/Auswertung folgende Funktionen anbieten:
>
>  
>
> ·     Sicherung des Tagebuches mit einem Login (mittels Username und Passwort)
>
> ·     Ausgeben eines Eintrages via gewähltem Datum
>
> ·     Ausgeben aller Beiträge zu einem bestimmten Identifikator (z.B. alle Einträge, welche zu Geburtstagen zugeordnet sind)
>
> ·     Anzeigen zu welchen Tagen keine Einträge vorhanden sind
>
> Dazu wurden folgende Rahmenbedingungen platziert:



- Die Gestaltung der Oberfläche ist neben der Funktionalität ein wichtiger Aspekt.
- Es wird ein vollständiger Nachweis der Funktionalität in Form von geeigneten Tests erwartet. (Planung und Durchführung) --> Beweise mit Hilfe von Screenshots
- Es müssen maximal 100 Einträge verwaltet werden können. 



## Analyse

Die Analyse im Projekt "Elektronisches Tagebuch" wurde nach folgendem Schema gestaltet:

![](C:\Users\simsontux\GIT\programming_herren\documentation\roter_faden.png)

Wir werden also folgende Diagramme zur Planung (Konzept) aufzeichnen:

- Kontextdiagramm --> 3 Kontextdiagramme
- Use Case Diagramm
- Aktivitätsdiagramm
- Kommunikationsdiagramm
- Sequenzdiagramm
- Zustandsdiagramm
- Klassendiagramm





## Lösungsansatz

## Planung und Controlling

In diesem Abschnitt wird aufgelistet wieviele Stunden für das Projekt geplant wurden und wieviele Stunden effektiv gebraucht wurden. 

**Legende:**

- Aktivität: Hier wird beschrieben, wer was macht.
  - S --> steht für Simon
  - L --> steht für Livio
- Soll-Stunden: Die geplanten Stunden
- Ist-Stunden: Die effektiv verwendeten Stunden
- Differenz: Die Differenz der Soll und Ist-Zeit
- Erklärung: Beschreibung des Grundes, warum es einen Zeit Überzug oder zu wenig Zeit für den Task gebraucht hat. 

| Aktivität                                                    | Soll-Stunden | Ist-Stunden | Differenz | Erklärung des Zeitunterschieds                               |
| ------------------------------------------------------------ | ------------ | ----------- | --------- | ------------------------------------------------------------ |
|                                                              |              |             |           |                                                              |
| **L**: Dokument eröffnen                                     | 1            | 1.5         | 0.5       | Es wurde zusätzlich noch ein GIT Repository eröffnet, um die Zusammenarbeit zu vereinfachen. |
| **S**: Aufnahme des Auftrags, Beschreibung der Ausgangslage, etc. | 2            | 2.5         | 0.5       | Klonen und Pull Probleme der Dokumentation im GIT-Repo       |



## Klassendiagram

