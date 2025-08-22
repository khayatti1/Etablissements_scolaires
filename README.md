# Etablissements_scolaires

##  Description
**Etablissements_scolaires** est une application de bureau développée en **VB.NET** (Windows Forms), destinée à la gestion complète d'établissements scolaires. 
Elle permet d'administrer des données essentielles telles que les établissements, le matériel et les fournisseurs via une interface utilisateur intuitive.

## Fonctionnalités principales
- **Gestion des établissements** : ajouter, modifier, supprimer et consulter les informations des établissements scolaires.
- **Gestion du matériel** : administrer les équipements (ajout, suppression, mise à jour…).
- **Gestion des fournisseurs** : suivre les fournisseurs liés aux établissements et au matériel.
- **Navigation multi-formulaires** pour une expérience utilisateur fluide.
- **Opérations CRUD** (Créer, Lire, Mettre à jour, Supprimer) pour toutes les entités.
- **Export au format HTML** avec mise en forme (CSS) intégrée.
- **Validation des données** et gestion des erreurs pour une fiabilité accrue.

## Architecture & Technologies
- **Langage** : Visual Basic .NET (Windows Forms)
- **Solution** : `Khayatti-Projet.sln`
- **Base de données** : Access (`academie.accdb`)
- **Structure** :
  - Fichiers `.vb` pour la logique applicative.
  - Formulaires et ressources (images, etc.).
  - Modules pour la configuration (ex. : connexion à la base de données).

## Installation
1. Clonez ou téléchargez le projet :
    ```bash
    git clone <URL_DU_REPOSITORY>
    ```
2. Ouvrez `Khayatti-Projet.sln` avec **Visual Studio**.
3. Restaurez les packages **NuGet** si nécessaire.
4. Placez `academie.accdb` (la base de données Access) dans le dossier principal du projet.
5. Assurez-vous que la chaîne de connexion dans `Module1.vb` pointe vers ce fichier.
6. Compilez et exécutez l’application via Visual Studio.

## Utilisation
- Lancez l’application depuis Visual Studio.
- Naviguez entre les formulaires (Établissements, Matériel, Fournisseurs).
- Réalisez des opérations CRUD selon vos besoins.
- Exportez les données en HTML pour les partager ou les imprimer.


