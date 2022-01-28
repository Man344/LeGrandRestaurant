# Le Grand Restaurant

## SCOPES

### :heavy_check_mark: SCOPE Serveur

:heavy_check_mark: 
    ÉTANT DONNÉ un nouveau serveur
    QUAND on récupére son chiffre d'affaires
    ALORS celui-ci est à 0

-----

:heavy_check_mark: 
    ÉTANT DONNÉ un nouveau serveur
    QUAND il prend une commande
    ALORS son chiffre d'affaires est le montant de celle-ci

-----

:heavy_check_mark: 
    ÉTANT DONNÉ un serveur ayant déjà pris une commande
    QUAND il prend une nouvelle commande
    ALORS son chiffre d'affaires est la somme des deux commandes

### :heavy_check_mark: SCOPE DebutService

    :heavy_check_mark: ÉTANT DONNE un restaurant ayant 3 tables
    QUAND le service commence
    ALORS elles sont toutes affectées au Maître d'Hôtel

    ----------------

    :heavy_check_mark: ÉTANT DONNÉ un restaurant ayant 3 tables dont une affectée à un serveur
    QUAND le service débute
    ALORS la table éditée est affectée au serveur et les deux autres au maître d'hôtel

    ----------------

    :heavy_check_mark: ÉTANT DONNÉ un restaurant ayant 3 tables dont une affectée à un serveur
    QUAND le service débute
    ALORS il n'est pas possible de modifier le serveur affecté à la table

    ----------------

    :heavy_check_mark: ÉTANT DONNÉ un restaurant ayant 3 tables dont une affectée à un serveur
    ET ayant débuté son service
    QUAND le service se termine
    ET qu'une table est affectée à un serveur
    ALORS la table éditée est affectée au serveur et les deux autres au maître d'hôtel

### :heavy_check_mark: SCOPE Epinglage

    :heavy_check_mark: ÉTANT DONNE un serveur ayant pris une commande
    QUAND il la déclare comme non-payée
    ALORS cette commande est marquée comme épinglée

    ----------------

    :heavy_check_mark: ÉTANT DONNE un serveur ayant épinglé une commande
    QUAND elle date d'il y a au moins 15 jours
    ALORS cette commande est marquée comme à transmettre gendarmerie

    ----------------

    :heavy_check_mark: ÉTANT DONNE une commande à transmettre gendarmerie
    QUAND on consulte la liste des commandes à transmettre du restaurant
    ALORS elle y figure

    ----------------

    :heavy_check_mark: ÉTANT DONNE une commande à transmettre gendarmerie
    QUAND elle est marquée comme transmise à la gendarmerie
    ALORS elle ne figure plus dans la liste des commandes à transmettre du restaurant

### :heavy_check_mark: SCOPE Menus

    :heavy_check_mark: ÉTANT DONNE un restaurant ayant le statut de filiale d'une franchise
    ET une franchise définissant un menu ayant un plat
    QUAND la franchise modifie le prix du plat
    ALORS le prix du plat dans le menu du restaurant est celui défini par la franchise

    ----------------

    :heavy_check_mark: ÉTANT DONNE un restaurant appartenant à une franchise et définissant un menu ayant un plat
    ET une franchise définissant un menu ayant le même plat
    QUAND la franchise modifie le prix du plat
    ALORS le prix du plat dans le menu du restaurant reste inchangé

    ----------------

    :heavy_check_mark: ÉTANT DONNE un restaurant appartenant à une franchise et définissant un menu ayant un plat
    QUAND la franchise ajoute un nouveau plat
    ALORS la carte du restaurant propose le premier plat au prix du restaurant et le second au prix de la franchise

    ----------------

    :heavy_check_mark: ÉTANT DONNE un serveur dans un restaurant
    QUAND il prend une commande de nourriture
    ALORS cette commande apparaît dans la liste de tâches de la cuisine de ce restaurant

    ----------------

    :heavy_check_mark: ÉTANT DONNE un serveur dans un restaurant
    QUAND il prend une commande de boissons
    ALORS cette commande n'apparaît pas dans la liste de tâches de la cuisine de ce restaurant

### :heavy_check_mark: SCOPE Restaurant

    :heavy_check_mark: ÉTANT DONNÉ un restaurant ayant X serveurs
    QUAND tous les serveurs prennent une commande d'un montant Y
    ALORS le chiffre d'affaires de la franchise est X * Y
    CAS(X = 0; X = 1; X = 2; X = 100)
    CAS(Y = 1.0)

### :heavy_check_mark: SCOPE Franchise

    :x: ÉTANT DONNÉ une franchise ayant X restaurants de Y serveurs chacuns
    QUAND tous les serveurs prennent une commande d'un montant Z
    ALORS le chiffre d'affaires de la franchise est X * Y * Z
    CAS(X = 0; X = 1; X = 2; X = 1000)
    CAS(Y = 0; Y = 1; Y = 2; Y = 1000)
    CAS(Z = 1.0)

### :x: SCOPE Commande

	:x: ÉTANT DONNE un serveur dans un restaurant
	QUAND il prend une commande de nourriture
	ALORS cette commande apparaît dans la liste de tâches de la cuisine de ce restaurant

    ----------------

	:x: ÉTANT DONNE un serveur dans un restaurant
	QUAND il prend une commande de boissons
	ALORS cette commande n'apparaît pas dans la liste de tâches de la cuisine de ce restaurant