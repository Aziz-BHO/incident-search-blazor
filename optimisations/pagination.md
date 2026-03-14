##Optimisation de la pagination
##Type

Optimisation au niveau de l’application

##Objectif

Éviter de retourner de grands ensembles de résultats lors de la recherche d’incidents dans une base de données contenant environ 100 000 enregistrements.

##Complexité

Faible

##Implémentation

Ajout des paramètres page et pageSize à l’endpoint /incidents.
La pagination est ensuite appliquée via les méthodes Skip() et Take() d’Entity Framework afin de limiter le nombre d’enregistrements retournés par requête.