# Implementation

Wir wollten mit C# etwas neues lernen mit diesem Projekt, darum haben wir uns für ASP.NET Core entschieden.
Es war Schwer mit der Dokumentation von ASP.NET Core umzugehen. Wir haben uns zuerst überhabut nicht zu Recht gefunden.
Als es uns klarer wurde haben wir mit dem Generator ein Neues ASP.NET Core welches auch das Entity- und Identity-Framework verwendet.

Darauf haben wir das Tagebuch aufgebaut. Wir haben als nächstes mit dem Entity-Framework eine SQLite Datenbank configueriert. Dazu die Modele und Migration für den User, Post und Tag erstellt. Dank der Einführung im Untericht wurden wir in der Dokumentation von Entity-Framework schneller fündig und konnten es einfach Umsetzten.

Das grosse Problem gab es beim PostsController. Wir haben zuerst nicht verstanden wie das Routing der HTTP Requests vom ASP.NET Core funktioniert. Nach dem Suchen und Testen haben wir es verstanden. Doch leider haben wir mit der CRUD implementation vom Post hatten wir grosse Probleme, weil wir nicht verstanden wie die Validation und Pages funktionieren.
Nach dem wir im Gesamten für dieses Feature Acht Stunden versucht haben es mit der Suche und der Dokumentation zu Lösen.
Es hat Leidernicht geklapt darum habe ich mich einen ASP.NET Core gefragt, dieser hat dann geholfen und es erklärt warum es nicht fuktioniert hat. Dadurch haben wir gelernt ViewModel für den Post zu machen für die Formulare und Validation zu machen. Das validierte PostViewModel wird dan in das Post abgefühlt.

Zeitlich hat es uns nicht gereicht die Filter funktionen einzubauen und den Bilder Upload für den Post.

# Anhang
