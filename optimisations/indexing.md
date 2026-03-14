##Optimisation des index de base de données
##Type

Optimisation au niveau de la base de données

##Objectif

La recherche d’incidents avec ILIKE '%text%' entraîne des scans complets de la table lorsque le volume de données devient important (100 000 lignes ou plus).

Pour améliorer les performances, des index trigrammes PostgreSQL ont été ajoutés à l’aide de l’extension pg_trgm, ce qui permet d’accélérer les recherches textuelles.

##Implémentation

Création d’index GIN sur les champs suivants :

incident.title

incident.description

champs de recherche liés à person

##Complexité

Moyenne