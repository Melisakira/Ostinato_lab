-- ============================================
-- OSTINATO LAB — Schéma de base de données
-- Prêt à importer dans MySQL Workbench :
-- File > Import > Reverse Engineer SQL Script
-- ============================================

CREATE TABLE UTILISATEUR (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(100) NOT NULL,
    email VARCHAR(150) NOT NULL UNIQUE,
    motDePasse VARCHAR(255) NOT NULL,
    role ENUM('APPRENANT','FORMATEUR','ADMINISTRATEUR') NOT NULL,
    statutActif BOOLEAN NOT NULL DEFAULT TRUE
);

CREATE TABLE FORMATION (
    id INT AUTO_INCREMENT PRIMARY KEY,
    titre VARCHAR(150) NOT NULL,
    description TEXT,
    niveau VARCHAR(50),
    dureeReference INT,
    etat ENUM('PREPARATION','DISPONIBLE') NOT NULL DEFAULT 'PREPARATION'
);

CREATE TABLE MODULE (
    id INT AUTO_INCREMENT PRIMARY KEY,
    titre VARCHAR(150) NOT NULL,
    ordre INT NOT NULL,
    formation_id INT NOT NULL,
    FOREIGN KEY (formation_id) REFERENCES FORMATION(id)
);

CREATE TABLE MICRO_ETAPE (
    id INT AUTO_INCREMENT PRIMARY KEY,
    titre VARCHAR(150) NOT NULL,
    type VARCHAR(50),
    contenu TEXT,
    module_id INT NOT NULL,
    FOREIGN KEY (module_id) REFERENCES MODULE(id)
);

CREATE TABLE SUIVRE (
    utilisateur_id INT NOT NULL,
    formation_id INT NOT NULL,
    active BOOLEAN NOT NULL DEFAULT FALSE,
    PRIMARY KEY (utilisateur_id, formation_id),
    FOREIGN KEY (utilisateur_id) REFERENCES UTILISATEUR(id),
    FOREIGN KEY (formation_id) REFERENCES FORMATION(id)
);

CREATE TABLE ATTRIBUER (
    formateur_id INT NOT NULL,
    formation_id INT NOT NULL,
    PRIMARY KEY (formateur_id, formation_id),
    FOREIGN KEY (formateur_id) REFERENCES UTILISATEUR(id),
    FOREIGN KEY (formation_id) REFERENCES FORMATION(id)
);

CREATE TABLE JALON (
    id INT AUTO_INCREMENT PRIMARY KEY,
    dateCible DATE NOT NULL,
    objectif VARCHAR(150),
    description TEXT,
    statut ENUM('ACTIF','ATTEINT','NON_ATTEINT') NOT NULL DEFAULT 'ACTIF',
    utilisateur_id INT NOT NULL,
    formation_id INT NOT NULL,
    FOREIGN KEY (utilisateur_id) REFERENCES UTILISATEUR(id),
    FOREIGN KEY (formation_id) REFERENCES FORMATION(id)
);

CREATE TABLE TENTATIVE (
    id INT AUTO_INCREMENT PRIMARY KEY,
    date DATETIME NOT NULL,
    resultat VARCHAR(100),
    statut ENUM('EN_COURS','TERMINEE') NOT NULL DEFAULT 'EN_COURS',
    utilisateur_id INT NOT NULL,
    microEtape_id INT NOT NULL,
    FOREIGN KEY (utilisateur_id) REFERENCES UTILISATEUR(id),
    FOREIGN KEY (microEtape_id) REFERENCES MICRO_ETAPE(id)
);

CREATE TABLE PROGRESSION (
    id INT AUTO_INCREMENT PRIMARY KEY,
    etapesRealisees INT NOT NULL DEFAULT 0,
    pourcentage FLOAT NOT NULL DEFAULT 0,
    utilisateur_id INT NOT NULL,
    formation_id INT NOT NULL,
    UNIQUE (utilisateur_id, formation_id),
    FOREIGN KEY (utilisateur_id) REFERENCES UTILISATEUR(id),
    FOREIGN KEY (formation_id) REFERENCES FORMATION(id)
);

CREATE TABLE VALORISATION_FINALE (
    id INT AUTO_INCREMENT PRIMARY KEY,
    dateGeneration DATETIME NOT NULL,
    utilisateur_id INT NOT NULL,
    formation_id INT NOT NULL,
    FOREIGN KEY (utilisateur_id) REFERENCES UTILISATEUR(id),
    FOREIGN KEY (formation_id) REFERENCES FORMATION(id)
);

CREATE TABLE RAPPEL (
    id INT AUTO_INCREMENT PRIMARY KEY,
    type VARCHAR(50) NOT NULL,
    dateGeneration DATETIME NOT NULL,
    utilisateur_id INT NOT NULL,
    FOREIGN KEY (utilisateur_id) REFERENCES UTILISATEUR(id)
);

CREATE TABLE IMPULSION_BIENVEILLANTE (
    id INT AUTO_INCREMENT PRIMARY KEY,
    message VARCHAR(255) NOT NULL,
    dateGeneration DATETIME NOT NULL,
    utilisateur_id INT NOT NULL,
    FOREIGN KEY (utilisateur_id) REFERENCES UTILISATEUR(id)
);

CREATE TABLE MESSAGE (
    id INT AUTO_INCREMENT PRIMARY KEY,
    contenu TEXT NOT NULL,
    dateEnvoi DATETIME NOT NULL,
    lu BOOLEAN NOT NULL DEFAULT FALSE,
    expediteur_id INT NOT NULL,
    destinataire_id INT NOT NULL,
    FOREIGN KEY (expediteur_id) REFERENCES UTILISATEUR(id),
    FOREIGN KEY (destinataire_id) REFERENCES UTILISATEUR(id)
);

CREATE TABLE PARAMETRES (
    id INT AUTO_INCREMENT PRIMARY KEY,
    theme VARCHAR(50) DEFAULT 'clair',
    taillePolice INT DEFAULT 14,
    notifications BOOLEAN DEFAULT TRUE,
    utilisateur_id INT NOT NULL UNIQUE,
    FOREIGN KEY (utilisateur_id) REFERENCES UTILISATEUR(id)
);
