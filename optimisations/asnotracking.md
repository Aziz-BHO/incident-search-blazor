## 01 - Utilisation de AsNoTracking()

## Type d’optimisation :** EF Core – lecture seule

- Les entités récupérées ne sont pas suivies par le Change Tracker.
- Réduit la mémoire utilisée et accélère la lecture.
- Idéal pour les requêtes affichage de données (lecture seule) sur de gros volumes (100k lignes).
