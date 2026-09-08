CREATE TABLE IF NOT EXISTS "Games"
(
    "Id" SERIAL PRIMARY KEY,
    "Title" VARCHAR(200) NOT NULL,
    "Genre" VARCHAR(100) NOT NULL,
    "Developer" VARCHAR(200) NOT NULL,
    "Platform" VARCHAR(100) NOT NULL,
    "ReleaseDate" DATE NOT NULL,
    "Description" TEXT NOT NULL
);

INSERT INTO "Games"
    ("Title", "Genre", "Developer", "Platform", "ReleaseDate", "Description")
VALUES
    (
        'Mass Effect 2',
        'Action RPG',
        'BioWare',
        'PC',
        '2010-01-26',
        'A science fiction action RPG about Commander Shepard and the Normandy crew.'
    ),
    (
        'Sekiro: Shadows Die Twice',
        'Action Adventure',
        'FromSoftware',
        'PC',
        '2019-03-22',
        'A challenging action game focused on sword combat and stealth.'
    ),
    (
        'Stellar Blade',
        'Action',
        'Shift Up',
        'PlayStation 5',
        '2024-04-26',
        'An action game following Eve as she fights to reclaim Earth.'
    ),
    (
        'Honkai: Star Rail',
        'Turn-Based RPG',
        'HoYoverse',
        'PC',
        '2023-04-26',
        'A turn-based RPG following the Astral Express and its journey across different worlds.'
    );