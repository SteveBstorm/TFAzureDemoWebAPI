/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO Pizza (Name, Price) VALUES ('Hawai', 12)
INSERT INTO Pizza (Name, Price) VALUES ('Margarita', 10)
INSERT INTO Pizza (Name, Price) VALUES ('Capriccioza', 12)
INSERT INTO Pizza (Name, Price) VALUES ('4 Saisons', 13)